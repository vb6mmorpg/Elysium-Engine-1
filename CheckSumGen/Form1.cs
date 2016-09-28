using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace CheckSumGen {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog ofile = new OpenFileDialog();

            ofile.InitialDirectory = Application.StartupPath;
            ofile.Multiselect = false;

            var result = ofile.ShowDialog();

            if (result == DialogResult.Cancel) { return; }

            var md5 = MD5.Create();

            textBox1.Text  = BitConverter.ToString(md5.ComputeHash(File.ReadAllBytes(ofile.FileName)));

        }
    }
}
