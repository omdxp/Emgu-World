using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Properties;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Emgu_World
{
    public partial class Menu : MetroForm
    {
        OpenFileDialog ofd;
        Image<Bgr, byte> imgInput;
        Image<Gray, byte> imgOutput;
        VideoCapture capture;
        CannyParameters cannyParameters;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Turn off visibility to all buttons
            TurnVisibilityOffToAllButtons();
        }

        public void ChangeTab(int tabNo)
        {
            metroTabControl1.SelectTab(tabNo);
        }

        #region Edge Detection
        double thresh = 50.0, threshlink = 20.0;

        public void SetThreshParameters(double t, double tl)
        {
            thresh = t;
            threshlink = tl;
        }

        public double GetThresh() { return thresh; }
        public double GetThreshLink() { return threshlink; }

        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgInput == null)
            {
                capture = null;
                ed_imgInputPicBox.Image = null;
                ed_imgOutputPicBox.Image = null;
                ed_detectEdgeButt.Visible = true;
                ed_stopCameraButt.Visible = false;
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    ed_imgInputPicBox.Image = imgInput.Bitmap;
                }
            }
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                imgInput = null;
                ed_imgInputPicBox.Image = null;
                ed_imgOutputPicBox.Image = null;
                ed_detectEdgeButt.Visible = false;
                ed_stopCameraButt.Visible = true;
                capture = new VideoCapture(0);
            }
            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                ed_imgInputPicBox.Image = m.ToImage<Bgr, byte>().Bitmap;
                imgOutput = m.ToImage<Gray, byte>()
                    .Canny(thresh, threshlink);
                ed_imgOutputPicBox.Image = imgOutput.Bitmap;
            }
            catch (Exception)
            {

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            cannyParameters = new CannyParameters(this);
            cannyParameters.Show();
        }

        public void ApplyCanny(double thresh, double threshLink)
        {
            if (imgInput == null)
                return;

            Image<Gray, byte> _imgCanny = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray(0));
            _imgCanny = imgInput.Canny(thresh, threshLink);

            ed_imgOutputPicBox.Image = _imgCanny.Bitmap;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Stop();
                capture.Dispose();
                capture = null;
                ed_imgInputPicBox.Image = null;
                ed_imgOutputPicBox.Image = null;
            }
        }

        #endregion

        #region Image Binarization
        #endregion

        #region Image Histogram
        #endregion

        #region Morphology
        #endregion

        #region Shape Detection
        #endregion

        #region Text Detection
        #endregion

        #region Face Detection
        #endregion

        #region Hand Gesture
        #endregion

        #region Exit & Other events
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && MetroMessageBox.Show(this, "\nAre you sure to quit?", "Emgu World",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            if (MetroMessageBox.Show(this, "\nAre you sure to quit?", "Emgu World",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void creatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            ShowCreator();
        }
        
        private void ShowCreator()
        {
            MetroMessageBox.Show(this, "\nOmar Belghaouti\n\n" +
                "Master student\n" +
                "Abou Bekr Belkaid University", "Creator",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void metroTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TurnVisibilityOffToAllButtons();
            DeletePictureBoxes();
        }

        #endregion

        #region Helper methods
        /// <summary>
        /// This method is called at the load method and when selecting a tab.
        /// It turns off the visibility to all form buttons
        /// </summary>
        private void TurnVisibilityOffToAllButtons()
        {
            ed_detectEdgeButt.Visible = false;
            ed_stopCameraButt.Visible = false;
            ib_binarizeButt.Visible = false;
        }
        /// <summary>
        /// This method deletes all picture boxes. It's called on the tab selected event
        /// </summary>
        private void DeletePictureBoxes()
        {
            ed_imgInputPicBox.Image = null;
            ed_imgOutputPicBox.Image = null;
        }
        #endregion
    }
}
