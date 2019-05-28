using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetroFramework.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

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
            try
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
            catch (Exception)
            {
                
            }
        }

        private void edgeDetectionTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(0);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
               
            }
        }

        private void imageBinrizationTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(1);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
                
            }
        }

        private void imageHistogramTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(2);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
                
            }
        }

        private void morphologyTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(3);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
                
            } 
        }

        private void shapeDetectionTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(4);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
                
            }
        }

        private void textDetectionTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(5);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
                
            }
        }

        private void faceDetectionTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(6);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
                
            }   
        }

        private void handGestureTile_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new Menu();
                menu.ChangeTab(7);
                menu.Show();
                Hide();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
