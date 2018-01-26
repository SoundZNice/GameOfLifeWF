using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLIfeWinForms
{
    class Presenter
    {
        CellsField cellsField;
        Form1 myForm;
        Graphics g;
        SolidBrush space;
        SolidBrush cellColor;
        Rectangle cell;
        bool[,] prevSituation;

        public Presenter(Form1 f)
        {
            this.myForm = f;
            this.myForm.startEvent += mainForm_StartEvent;
            this.myForm.tickEvent += mainForm_TickEvent;
            this.myForm.startCustomEvent += mainForm_CustomStartEvent;
            this.myForm.fieldClick += drawSingleElement;


            g = myForm.pictureBox1.CreateGraphics();
            space = new SolidBrush(Color.White);
            cellColor = new SolidBrush(Color.Green);
            cell = new Rectangle();

            prevSituation = new bool[50, 50];

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    prevSituation[i, j] = false;
                }
            }

        }

        void mainForm_StartEvent(object sender, EventArgs e)
        {
            g.FillRectangle(space, 0, 0, myForm.pictureBox1.Width, myForm.pictureBox1.Height);
            this.cellsField = new CellsField();
            this.myForm.timer1.Enabled = true;
            drawWorld();
        }

        void mainForm_CustomStartEvent(object sender, EventArgs e)
        {
            if (!myForm.timer1.Enabled)
            {
                g.FillRectangle(space, 0, 0, myForm.pictureBox1.Width, myForm.pictureBox1.Height);
                cellsField = new CellsField(prevSituation);
                this.myForm.timer1.Enabled = true;
                drawWorld();
            }
            else
            {
                myForm.timer1.Enabled = false;
                prevSituation = cellsField.Field;
            }
        }

        void mainForm_TickEvent(object sender, EventArgs e)
        {
            drawWorld();
        }

        void drawSingleElement(object sender, MouseEventArgs e)
        {
            int x = e.X / 10;
            int y = e.Y / 10;

            if (e.Button == MouseButtons.Left)
            {
                prevSituation[x, y] = true;

                g.FillRectangle(cellColor, x * 10, y * 10, 10, 10);
            }
            else
            {
                prevSituation[x, y] = false;

                g.FillRectangle(space, x * 10, y * 10, 10, 10);
            }
        }

        void drawWorld()
        {
            bool[,] currentField = this.cellsField.GetStep();
            

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    //if (prevSituation[i,j] != currentField[i,j])
                    {
                        cell = new Rectangle(i * 10, j * 10, 10, 10);
                        if (currentField[i, j])
                            g.FillRectangle(cellColor, cell);
                        else
                            g.FillRectangle(space, cell);
                    }
                }
            }


            //prevSituation = currentField;
        }


    }
}
