using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgentesRobots;

namespace Visual
{
    public partial class Form1 : Form
    {
        int size1;
        int size2;
        int countChildren;
        int countDirt;
        int countBlocking;
        ProactiveRobot project1;
        ReactiveRobot project2;
        public Form1()
        {
            InitializeComponent();
        }

        private void PbEnviroment1_Paint(object sender, PaintEventArgs e)
        {
            int width = PbEnviroment1.Width;
            int height = PbEnviroment1.Height;
            PbEnviroment1.Image = new Bitmap(width, height);
            Graphics graph = Graphics.FromImage(PbEnviroment1.Image);

            Pen pen = new Pen(Color.Black, 2);

            string temp = "";
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    temp = project1.board.things[i, j].ToString() + ".png";
                    graph.DrawImage(Image.FromFile("img/" + temp), i * width / size1, j * height / size2, width / size1, height / size2);
                }
            }

            for (int i = 1; i < size1; i++)
            {
                graph.DrawLine(pen, i * width / size1, 0, i * width / size1, height);
            }
            for (int i = 1; i < size2; i++)
            {
                graph.DrawLine(pen, 0, i * height / size2, width, i * height / size2);
            }

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            size1 = (int)NudSize1.Value;
            size2 = (int)NudSize2.Value;
            countChildren = (int)NudChildren.Value;
            countBlocking = (int)NudBlocking.Value;
            countDirt = (int)NudDirt.Value;
            project1 = new ProactiveRobot(size1, size2, countChildren, countBlocking, countDirt);
            project2 = new ReactiveRobot(size1, size2, countChildren, countBlocking, countDirt);
        }

        private void PbEnviroment2_Paint(object sender, PaintEventArgs e)
        {
            int width = PbEnviroment2.Width;
            int height = PbEnviroment2.Height;
            PbEnviroment2.Image = new Bitmap(width, height);
            Graphics graph = Graphics.FromImage(PbEnviroment2.Image);

            Pen pen = new Pen(Color.Black, 2);

            string temp = "";
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    temp = project2.board.things[i, j].ToString() + ".png";
                    graph.DrawImage(Image.FromFile("img/" + temp), i * width / size1, j * height / size2, width / size1, height / size2);
                }
            }

            for (int i = 1; i < size1; i++)
            {
                graph.DrawLine(pen, i * width / size1, 0, i * width / size1, height);
            }
            for (int i = 1; i < size2; i++)
            {
                graph.DrawLine(pen, 0, i * height / size2, width, i * height / size2);
            }
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            //project2.Move();
            LblResult1.Text = project1.board.report;
            LblResult2.Text = project2.board.report;
            PbEnviroment1.Refresh();
            LblResult1.Refresh();
            PbEnviroment2.Refresh();
            LblResult2.Refresh();
        }
    }
}
