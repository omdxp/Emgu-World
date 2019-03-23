using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;

namespace Emgu_World
{
    public partial class Hello : MetroForm
    {
        Menu menu;

        public Hello()
        {
            InitializeComponent();
        }

        private async void SlideShow_Load(object sender, EventArgs e)
        {
            string[] fileNames = Directory.GetFiles(Path.GetFullPath("../../Slides"));
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();

            foreach (var file in fileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }

            while (true)
            {
                for (int i = 0; i < listImages.Count - 1; i++)
                {
                    for (double alpha = .0; alpha < 1.0; alpha += .01)
                    {
                        slidesPicBox.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, (1 - alpha), 0).Bitmap;
                        await Task.Delay(25);
                    }
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(0);
            menu.Show();
            Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(1);
            menu.Show();
            Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(2);
            menu.Show();
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(3);
            menu.Show();
            Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(4);
            menu.Show();
            Close();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(5);
            menu.Show();
            Close();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(6);
            menu.Show();
            Close();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            menu = new Menu();
            menu.ChangeTab(7);
            menu.Show();
            Close();
        }
    }
}
