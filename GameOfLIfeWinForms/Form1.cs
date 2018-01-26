using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLIfeWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Presenter(this);
            timer1.Enabled = false;
        }

        public event EventHandler startEvent = null;

        private void button1_Click(object sender, EventArgs e)
        {
            startEvent.Invoke(sender, e);
        }

        public event EventHandler tickEvent = null;

        private void timer1_Tick(object sender, EventArgs e)
        {
            tickEvent.Invoke(sender, e);
        }

        public event EventHandler startCustomEvent = null;

        private void button2_Click(object sender, EventArgs e)
        {
            startCustomEvent.Invoke(sender, e);
        }

        public event MouseEventHandler fieldClick = null;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            fieldClick.Invoke(sender, e);
        }
    }
}
