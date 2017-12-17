using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pkpass2cal
{
    public partial class Form1 : Form
    {
        AppManager manager;

        public Form1()
        {
            InitializeComponent();
            AllowDrop = true;
            manager = new AppManager();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
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
    }
}
