﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace pkpass2cal
{
    public partial class Form1 : Form
    {
        AppService manager;

        public Form1()
        {
            InitializeComponent();
            AllowDrop = true;
            manager = new AppService();
        }

        /// <summary>
        /// Constructor of the form used when the user drags a file directly to the application whenever it's not started.
        /// </summary>
        /// <param name="filePath">The local path for the pkpass file</param>
        public Form1(string filePath)
        {
            InitializeComponent();
            AllowDrop = true;
            manager = new AppService();
            if (Path.GetExtension(filePath) == ".pkpass")
            {
                manager.ProcessFile(filePath);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetFormats().Contains("UniformResourceLocator"))
                {
                    string url = e.Data.GetData("System.String").ToString();
                    manager.ProcessUrl(url);
                }
                else
                {
                    string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop, false));
                    foreach (string file in files)
                    {
                        if (Path.GetExtension(file) == ".pkpass")
                        {
                            manager.ProcessFile(file);
                        }
                    }
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
