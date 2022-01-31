using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace メモ帳君
{
    public partial class Form2 : Form
    {
        static string size = "11";
        public Form2()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
