using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
using DiscUtils.Ewf;

namespace E01Helper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private string _currentFile = null;

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            if (GetFile())
                Go(false);
        }

        private bool GetFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "E01 Files|*.e01|All Files|*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _currentFile = ofd.FileName;
                return true;
            }
            return false;
        }

        private void DumpVolume(DiscUtils.Ewf.Section.Volume volume, DataTable dataTable)
        {
            PropertyInfo[] vInfo = volume.GetType().GetProperties();
            foreach (PropertyInfo pi in vInfo)
            {
                object o = pi.GetValue(volume, null);
                string val = IsNumber(o) ? string.Format("{0:n0}", o) : o.ToString();
                dataTable.Rows.Add(pi.Name, val);
            }
            long capacity = (long)volume.BytesPerSector * (long)volume.SectorCount;
            dataTable.Rows.Add("Capacity*", string.Format("{0:n0}", capacity));
            dataTable.Rows.Add("Friendly Capacity*", parseSize(capacity));
        }

        private void DumpHeader(DiscUtils.Ewf.Section.Header2 header, DataTable dataTable)
        {
            foreach (DiscUtils.Ewf.Section.Header2.Header2Category Cat in header.Categories)
            {
                foreach (KeyValuePair<string, string> info in Cat.Info)
                {
                    string val = IsNumber(info.Value) ? string.Format("{0:n0}", info.Value) : info.Value.ToString();
                    dataTable.Rows.Add(info.Key, info.Value);
                }
            }
        }

        private void bgwMain_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            string filePath = (string)args[0];
            bool resolveChain = (bool)args[1];

            DataTable dt = new DataTable();
            dt.Columns.Add("Item");
            dt.Columns.Add("Value");

            dt.Rows.Add("Source", filePath);

            try
            {
                if (resolveChain)
                {
                    using (Disk disk = new Disk(filePath))
                    {
                        DumpHeader((DiscUtils.Ewf.Section.Header2)disk.GetSection("header"), dt);
                        DumpVolume((DiscUtils.Ewf.Section.Volume)disk.GetSection("volume"), dt);
                        dt.Rows.Add("Segments", disk.Files.Count);
                    }
                }
                else
                {
                    EWFInfo ewfInfo = new EWFInfo(filePath);
                    DumpHeader(ewfInfo.HeaderSection, dt);
                    DumpVolume(ewfInfo.VolumeSection, dt);
                }                
            }
            //catch (Exception ex)
            catch(Exception ex)
            {
                dt.Rows.Add("Error", ex.Message);
                if (ex.InnerException != null)
                    dt.Rows.Add("More Info", ex.InnerException.Message);
            }

            e.Result = dt;
        }

        private void bgwMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result.GetType() == typeof(DataTable))
                {
                    dgvMain.DataSource = (DataTable)e.Result;
                }
            }

            enableGUI(true);
            tslblInfo.Text = string.Empty;
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            if (_currentFile == null)
            {
                if (GetFile())
                    Go(false);
            }
            else
                Go(false);
        }

        private bool IsNumber(object value)
        {
            if (value is int) return true;
            if (value is long) return true;
            return false;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            if (files.Length != 1)
            {
                MessageBox.Show("Only one file can be dropped at a time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _currentFile = files[0];
                Go(false);
            }
        }

        private void Go(bool resolveChain)
        {
            enableGUI(false);
            tslblInfo.Text = "Working...";
            bgwMain.RunWorkerAsync(new object[] { _currentFile, resolveChain });
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void tsbtnResolveChain_Click(object sender, EventArgs e)
        {
            if (_currentFile == null)
            {
                if (GetFile())
                    Go(true);
            }
            else
                Go(true);
        }

        private string parseSize(long size)
        {
            string[] suffix = { "bytes", "KB", "MB", "GB", "TB", "PB" };
            int tier = 0;

            double dSize = size;

            while (dSize >= 1024)
            {
                dSize /= 1024;
                tier++;
            }

            return string.Format("{0} {1}", Math.Round(dSize, 2), suffix[tier]);
        }

        private void enableGUI(bool value)
        {
            tsbtnOpen.Enabled = tsbtnRefresh.Enabled = tsbtnResolveChain.Enabled = tsbtnVerifyMD5.Enabled = value;
        }

        private void tsbtnVerifyMD5_Click(object sender, EventArgs e)
        {
            if (_currentFile == null)
                MessageBox.Show("You must load an E01 first.", "No File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                GoMD5();
        }

        private void GoMD5()
        {
            enableGUI(false);
            tslblInfo.Text = "Calculating MD5...";
            bgwMD5.RunWorkerAsync(_currentFile);
        }

        private void bgwMD5_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileName = (string)e.Argument;
            using (DiscUtils.Ewf.Disk disk = new DiscUtils.Ewf.Disk(fileName))
            {
                MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
                byte[] md5Bytes = md5Provider.ComputeHash(disk.Content);
                e.Result = Utils.ByteArrayToByteString(md5Bytes, 0, md5Bytes.Length);
            }
        }

        private void bgwMD5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                DataTable dt = (DataTable)dgvMain.DataSource;                
                dt.Rows.Add("Calc'd MD5", (string)e.Result);
            }

            tslblInfo.Text = string.Empty;
            enableGUI(true);
        }
    }
}
