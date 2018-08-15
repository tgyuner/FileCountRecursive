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

namespace FileCountRecursive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Tugay ÜNER 2018 © Agust
        }

        private void button1_Click(object sender, EventArgs e)
        {
            üstPath.Add("D:\\animals");
            int fileCount = DosyaSayısı(üstPath);
            MessageBox.Show(fileCount.ToString());
        }

        List<string> üstPath = new List<string>();
        List<string> astPath = new List<string>();
        List<string> temp = new List<string>();

        public int DosyaSayısı(List<string> üstPath)
        {
            astPath = new List<string>();
            temp = new List<string>();

            if (üstPath.Count == 0)
            {
                return listBox1.Items.Count;
            }
            else
            {
                foreach (var dosya in üstPath)
                {
                    DirectoryInfo di = new DirectoryInfo(dosya);
                    DirectoryInfo[] klasorler = di.GetDirectories();
                    foreach (DirectoryInfo klasor in klasorler)
                    {
                        temp.Add(klasor.FullName);
                        listBox1.Items.Add(klasor.Name);
                    }
                }

                astPath = temp;
                üstPath = astPath;

                return DosyaSayısı(üstPath);

            }
        }

    }
}
