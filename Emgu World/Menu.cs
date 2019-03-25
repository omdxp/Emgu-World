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
using System.IO;

namespace Emgu_World
{
    public partial class Menu : MetroForm
    {
        // Attributes
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
            try
            {
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                }
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
            catch (Exception)
            {

            }
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {

            }
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
            try
            {
                cannyParameters = new CannyParameters(this);
                cannyParameters.Show();
            }
            catch (Exception)
            {
                
            }
        }

        public void ApplyCanny(double thresh, double threshLink)
        {
            try
            {
                if (imgInput == null)
                    return;

                Image<Gray, byte> _imgCanny = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray(0));
                _imgCanny = imgInput.Canny(thresh, threshLink);

                ed_imgOutputPicBox.Image = _imgCanny.Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                
            } 
        }

        private void howToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "You can choose between using pictures or camera\n" +
                "- To choose picture go to File -> Open -> Picture\n" +
                "- To choose camera go to File -> Open -> Camera\n" +
                "- To change Edge threshold parameters for both picture or camera,\n" +
                "you click on the button 'Detect Edges' when chosing a picture\n" +
                "- It's a better practice to stop the camera when finished",
                "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }
        #endregion

        #region Image Binarization
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    ib_imgInputPicBox.Image = imgInput.Bitmap;
                }
                ib_binarizeButt.Visible = true;
            }
            catch (Exception)
            {
                
            }
        }

        private void ib_binarizeButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                imgOutput = imgInput.Convert<Gray, byte>();
                // Binarization using thresholding
                Image<Gray, byte> imgBinary = new Image<Gray, byte>(imgOutput.Width, imgOutput.Height, new Gray(0));
                CvInvoke.Threshold(imgOutput, imgBinary, 50, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);
                ib_imgOutputPicBox.Image = imgBinary.Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "You can choose a picture to binarize\n" +
                "- To choose a picture go to File -> Open\n" +
                "- Click on 'Binarize' button to binarize the picture",
                "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }
        #endregion

        #region Image Histogram
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    ih_imgInputPicBox.Image = imgInput.Bitmap;
                }
                ih_histogramButt.Visible = true;
                ih_redRadioButt.Visible = true;
                ih_greenRadioButt.Visible = true;
                ih_blueRadioButt.Visible = true;
            }
            catch (Exception)
            {
                
            }
        }

        private void ih_histogramButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                DenseHistogram hist = new DenseHistogram(256, new RangeF(0.0f, 255.0f));
                // accumelate for more than one picture
                // mask for some part of the image
                Image<Gray, byte> B = imgInput[0];
                Image<Gray, byte> G = imgInput[1];
                Image<Gray, byte> R = imgInput[2];

                if (ih_redRadioButt.Checked == true)
                {
                    hist.Calculate(new Image<Gray, byte>[] { R }, false, null);

                    Mat m = new Mat();
                    hist.CopyTo(m);

                    histogramBox.ClearHistogram();
                    histogramBox.AddHistogram("Red channel histogram", Color.Red, m, 256, new float[] { 0f, 255f });
                    histogramBox.Refresh();
                }
                else if (ih_greenRadioButt.Checked == true)
                {
                    hist.Calculate(new Image<Gray, byte>[] { G }, false, null);

                    Mat m = new Mat();
                    hist.CopyTo(m);

                    histogramBox.ClearHistogram();
                    histogramBox.AddHistogram("Green channel histogram", Color.Green, m, 256, new float[] { 0f, 255f });
                    histogramBox.Refresh();
                }
                else if (ih_blueRadioButt.Checked == true)
                {
                    hist.Calculate(new Image<Gray, byte>[] { B }, false, null);

                    Mat m = new Mat();
                    hist.CopyTo(m);

                    histogramBox.ClearHistogram();
                    histogramBox.AddHistogram("Blue channel histogram", Color.Blue, m, 256, new float[] { 0f, 255f });
                    histogramBox.Refresh();
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "You can choose a picture to show its histogram\n" +
                "- To choose a picture go to File -> Open\n" +
                "- Choos between channels (Red, Green, Blue)\n" +
                "- Click on 'Histogram' button to show a histogram for picture",
                "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }
        #endregion

        #region Morphology
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            try
            {
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    m_imgInputPicBox.Image = imgInput.Bitmap;
                }
                m_erosionButt.Visible = true;
                m_dilationButt.Visible = true;
                m_openButt.Visible = true;
                m_closeButt.Visible = true;
                m_gradientButt.Visible = true;
                m_topHatButt.Visible = true;
                m_blackHatButt.Visible = true;
                m_dilateOnBinaryButt.Visible = true;
                m_erodeOnBinaryButt.Visible = true;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_erosionButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                m_imgOutputPicBox.Image = imgInput.Erode(5).Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_dilationButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                m_imgOutputPicBox.Image = imgInput.Dilate(5).Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_openButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                    return;
                // -1 -1 for central element
                Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                m_imgOutputPicBox.Image = imgInput.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Open,
                        kernel,
                        new Point(-1, -1),
                        1,
                        Emgu.CV.CvEnum.BorderType.Default,
                        new MCvScalar(1.0)).Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_closeButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                    return;
                // -1 -1 for central element
                Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                m_imgOutputPicBox.Image = imgInput
                    .MorphologyEx(Emgu.CV.CvEnum.MorphOp.Close,
                        kernel,
                        new Point(-1, -1),
                        1,
                        Emgu.CV.CvEnum.BorderType.Default,
                        new MCvScalar(1.0)).Bitmap;
            }
            catch (Exception)
            {
                
            } 
        }

        private void m_gradientButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                    return;
                // -1 -1 for central element
                Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                m_imgOutputPicBox.Image = imgInput
                    .MorphologyEx(Emgu.CV.CvEnum.MorphOp.Gradient,
                        kernel,
                        new Point(-1, -1),
                        1,
                        Emgu.CV.CvEnum.BorderType.Default,
                        new MCvScalar(1.0)).Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_topHatButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                    return;
                // -1 -1 for central element
                Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                m_imgOutputPicBox.Image = imgInput
                    .MorphologyEx(Emgu.CV.CvEnum.MorphOp.Tophat,
                        kernel,
                        new Point(-1, -1),
                        1,
                        Emgu.CV.CvEnum.BorderType.Default,
                        new MCvScalar(1.0)).Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_blackHatButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                    return;
                // -1 -1 for central element
                Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                m_imgOutputPicBox.Image = imgInput.Convert<Gray, byte>()
                    .MorphologyEx(Emgu.CV.CvEnum.MorphOp.Blackhat,
                        kernel,
                        new Point(-1, -1),
                        1,
                        Emgu.CV.CvEnum.BorderType.Default,
                        new MCvScalar(1.0)).Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_dilateOnBinaryButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                imgOutput = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(120), new Gray(255)).Erode(2);
                m_imgOutputPicBox.Image = imgOutput.Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void m_erodeOnBinaryButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                imgOutput = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(120), new Gray(255)).Dilate(2);
                m_imgOutputPicBox.Image = imgOutput.Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "You can choose a picture to show different morphological processing operations\n" +
                "- To choose a picture go to File -> Open\n" +
                "- Click on different buttons to show output picture",
                "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }
        #endregion

        #region Shape Detection
        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                }
                capture = null;
                sd_imgInputPicBox.Image = null;
                sd_imgOutputPicBox.Image = null;
                sd_DetectShapeButt.Visible = true;
                sd_stopCameraButt.Visible = false;
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    sd_imgInputPicBox.Image = imgInput.Bitmap;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void sd_DetectShapeButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    throw new Exception("Please select an image");
                }

                var tmp = imgInput.SmoothGaussian(5).Convert<Gray, byte>()
                    .ThresholdBinaryInv(new Gray(230), new Gray(255)); // Inv because the background of the image is white, so remove it

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();

                CvInvoke.FindContours(tmp, contours,
                    hier,
                    Emgu.CV.CvEnum.RetrType.External,
                    Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                for (int i = 0; i < contours.Size; i++)
                {
                    double parameter = CvInvoke.ArcLength(contours[i], true);
                    VectorOfPoint approx = new VectorOfPoint();

                    CvInvoke.ApproxPolyDP(contours[i], approx, .04 * parameter, true);

                    CvInvoke.DrawContours(imgInput, contours, i, new MCvScalar(255, 0, 255), 2);

                    // Moments : concept for finding shaeps, area, measures...
                    // Here we want the center of the shape
                    var moments = CvInvoke.Moments(contours[i]);
                    int x = (int)(moments.M10 / moments.M00);
                    int y = (int)(moments.M01 / moments.M00);

                    if (approx.Size == 3) // Triangle
                    {
                        CvInvoke.PutText(imgInput, "Triangle",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    if (approx.Size == 4) // Rectangle
                    {
                        // Check for Square
                        Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                        double ar = (double)rect.Width / rect.Height;
                        if (ar >= .95 && ar <= 1.05)
                        {
                            CvInvoke.PutText(imgInput, "Square",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                        }
                        else
                        {
                            CvInvoke.PutText(imgInput, "Rectangle",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                        }
                    }

                    if (approx.Size == 5) // Pentagon
                    {
                        CvInvoke.PutText(imgInput, "Pentagon",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    if (approx.Size == 6) // Hexagon
                    {
                        CvInvoke.PutText(imgInput, "Hexagon",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    if (approx.Size > 6) // Circle
                    {
                        CvInvoke.PutText(imgInput, "Circle",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    sd_imgOutputPicBox.Image = imgInput.Bitmap;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture == null)
                {
                    imgInput = null;
                    sd_imgInputPicBox.Image = null;
                    sd_imgOutputPicBox.Image = null;
                    sd_DetectShapeButt.Visible = false;
                    sd_stopCameraButt.Visible = true;
                    capture = new VideoCapture(0);
                }
                capture.ImageGrabbed += Capture_ImageGrabbed1;
                capture.Start();
            }
            catch (Exception)
            {
                
            }
        }

        private void Capture_ImageGrabbed1(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                sd_imgInputPicBox.Image = m.ToImage<Bgr, byte>().Bitmap;

                var tmp = m.ToImage<Gray, byte>().SmoothGaussian(5)
                    .ThresholdBinaryInv(new Gray(230), new Gray(255)); // Inv because the background of the image is white, so remove it

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();

                CvInvoke.FindContours(tmp, contours,
                    hier,
                    Emgu.CV.CvEnum.RetrType.External,
                    Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                for (int i = 0; i < contours.Size; i++)
                {
                    double parameter = CvInvoke.ArcLength(contours[i], true);
                    VectorOfPoint approx = new VectorOfPoint();

                    CvInvoke.ApproxPolyDP(contours[i], approx, .04 * parameter, true);

                    CvInvoke.DrawContours(m.ToImage<Gray, byte>(), contours, i, new MCvScalar(255, 0, 255), 2);

                    // Moments : concept for finding shaeps, area, measures...
                    // Here we want the center of the shape
                    var moments = CvInvoke.Moments(contours[i]);
                    int x = (int)(moments.M10 / moments.M00);
                    int y = (int)(moments.M01 / moments.M00);

                    if (approx.Size == 3) // Triangle
                    {
                        CvInvoke.PutText(m.ToImage<Gray, byte>(), "Triangle",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    if (approx.Size == 4) // Rectangle
                    {
                        // Check for Square
                        Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                        double ar = (double)rect.Width / rect.Height;
                        if (ar >= .95 && ar <= 1.05)
                        {
                            CvInvoke.PutText(m.ToImage<Gray, byte>(), "Square",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                        }
                        else
                        {
                            CvInvoke.PutText(m.ToImage<Gray, byte>(), "Rectangle",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                        }
                    }

                    if (approx.Size == 5) // Pentagon
                    {
                        CvInvoke.PutText(m.ToImage<Gray, byte>(), "Pentagon",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    if (approx.Size == 6) // Hexagon
                    {
                        CvInvoke.PutText(m.ToImage<Gray, byte>(), "Hexagon",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    if (approx.Size > 6) // Circle
                    {
                        CvInvoke.PutText(m.ToImage<Gray, byte>(), "Circle",
                            new Point(x, y),
                            Emgu.CV.CvEnum.FontFace.HersheySimplex,
                            .5,
                            new MCvScalar(255, 0, 0),
                            2);
                    }

                    sd_imgOutputPicBox.Image = m.ToImage<Bgr, byte>().Bitmap;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void sd_stopCameraButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                    capture = null;
                    sd_imgInputPicBox.Image = null;
                    sd_imgOutputPicBox.Image = null;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "You can choose on using picture or camera\n" +
                "- To choose a picture go to File -> Open -> Picture\n" +
                "- To choose camera go to File -> Open -> Camera\n" +
                "- When choosing a picture click on 'Detect Shape' button to see output image\n" +
                "- When using camera it will detect and show output image automatically\n" +
                "- It's a better practice if you stop camera when finished",
                "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }

        #endregion

        #region Text Detection

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                }
                capture = null;
                td_imgInputPicBox.Image = null;
                td_imgOutputPicBox.Image = null;
                td_DetectTextButt.Visible = true;
                td_stopCameraButt.Visible = false;
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    td_imgInputPicBox.Image = imgInput.Bitmap;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture == null)
                {
                    imgInput = null;
                    td_imgInputPicBox.Image = null;
                    td_imgOutputPicBox.Image = null;
                    td_DetectTextButt.Visible = false;
                    td_stopCameraButt.Visible = true;
                    capture = new VideoCapture(0);
                }
                capture.ImageGrabbed += Capture_ImageGrabbed2;
                capture.Start();
            }
            catch (Exception)
            {
                
            } 
        }

        private async void Capture_ImageGrabbed2(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                DetectText(m.ToImage<Bgr, byte>());
                double fps = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                await Task.Delay(1000 / Convert.ToInt32(fps));

            }
            catch (Exception)
            {
                
            }
        }

        private void DetectText(Image<Bgr, byte> img)
        {
            /*
             * 1. Edge detection (sobel)
             * 2. Dilation (10, 1)
             * 3. FindContours
             * 4. Geometrical Constraints 
             */
            try
            {
                // Sobel
                Image<Gray, byte> sobel = img.Convert<Gray, byte>().Sobel(1, 0, 3)
                    .AbsDiff(new Gray(0.0)).Convert<Gray, byte>()
                    .ThresholdBinary(new Gray(50), new Gray(255));

                // Dilation
                Mat SE = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(10, 2),
                    new Point(-1, -1));

                sobel = sobel.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Dilate,
                    SE,
                    new Point(-1, -1),
                    1,
                    Emgu.CV.CvEnum.BorderType.Reflect,
                    new MCvScalar(255));

                // FindContours
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();

                CvInvoke.FindContours(sobel, contours,
                    hier,
                    Emgu.CV.CvEnum.RetrType.External,
                    Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                // Geometrical constraints
                List<Rectangle> list = new List<Rectangle>();

                for (int i = 0; i < contours.Size; i++)
                {
                    Rectangle brect = CvInvoke.BoundingRectangle(contours[i]);

                    double ar = brect.Width / brect.Height; // aspect ration (width > height)
                    if (ar > 2 && brect.Width > 30 && brect.Height > 8 && brect.Height < 100)
                    {
                        list.Add(brect);
                    }
                }

                Image<Bgr, byte> _imgOut = img.CopyBlank();
                foreach (var r in list)
                {
                    CvInvoke.Rectangle(img, r, new MCvScalar(0, 0, 255), 2);
                    CvInvoke.Rectangle(_imgOut, r, new MCvScalar(0, 255, 255), -1); // -1 filled rectangle
                }

                _imgOut._And(img); // Real Area will be copied to imgOut

                td_imgInputPicBox.Image = img.Bitmap;
                td_imgOutputPicBox.Image = _imgOut.Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void td_DetectTextButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                DetectText(imgInput);
            }
            catch (Exception)
            {
                
            }
        }

        private void td_stopCameraButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                    capture = null;
                    td_imgInputPicBox.Image = null;
                    td_imgOutputPicBox.Image = null;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "You can choose on using picture or camera\n" +
                "- To choose a picture go to File -> Open -> Picture\n" +
                "- To choose camera go to File -> Open -> Camera\n" +
                "- When choosing a picture click on 'Detect Text' button to see output image\n" +
                "- When using camera it will detect and show output image automatically\n" +
                "- It's a better practice if you stop camera when finished",
                "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }
        #endregion

        #region Face Detection

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                }
                capture = null;
                fd_imgInputPicBox.Image = null;
                fd_imgOutputPicBox.Image = null;
                fd_detectFaceButt.Visible = true;
                fd_stopCameraButt.Visible = false;
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    fd_imgInputPicBox.Image = imgInput.Bitmap;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture == null)
                {
                    imgInput = null;
                    fd_imgInputPicBox.Image = null;
                    fd_imgOutputPicBox.Image = null;
                    fd_detectFaceButt.Visible = false;
                    fd_stopCameraButt.Visible = true;
                    capture = new VideoCapture(0);
                }
                capture.ImageGrabbed += Capture_ImageGrabbed3;
                capture.Start();
            }
            catch (Exception)
            {
                
            } 
        }

        private void Capture_ImageGrabbed3(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                fd_imgInputPicBox.Image = m.ToImage<Bgr, byte>().Bitmap;
                DetectFaceLBP(m.ToImage<Bgr, byte>());
            }
            catch (Exception)
            {
                
            }
        }

        private void fd_detectFaceButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgInput == null)
                {
                    return;
                }
                DetectFaceLBP(imgInput);
            }
            catch (Exception)
            {
                
            }
        }
        /// <summary>
        /// local binary patterns method
        /// LBP is faster
        /// </summary>
        private void DetectFaceLBP(Image<Bgr, byte> img)
        {
            try
            {
                string facePath = Path.GetFullPath(@"../../LBPcascade classifiers/lbpcascade_frontalface.xml");

                // the following class is smart enough to know the type of classifier based from XML files
                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imgGray = img.Convert<Gray, byte>().Clone();
                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 2);
                foreach (var face in faces)
                {
                    img.Draw(face, new Bgr(255, 0, 0));
                }

                fd_imgOutputPicBox.Image = img.Bitmap;
            }
            catch (Exception)
            {
                
            }
        }

        private void fd_stopCameraButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                    capture = null;
                    fd_imgInputPicBox.Image = null;
                    fd_imgOutputPicBox.Image = null;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "You can choose on using picture or camera\n" +
                "- To choose a picture go to File -> Open -> Picture\n" +
                "- To choose camera go to File -> Open -> Camera\n" +
                "- When choosing a picture click on 'Detect Face' button to see output image\n" +
                "- When using camera it will detect and show output image automatically\n" +
                "- It's a better practice if you stop camera when finished",
                "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }
        #endregion

        #region Hand Gesture
        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "\n- To open camera go to File -> Open Camera\n" +
                "- Text will be shown when a gesture is detected\n" +
                "- It's a better practice to stop camera when finished", "How To?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }
        #endregion

        #region Exit & Other events

        private void ih_blueRadioButt_MouseClick(object sender, MouseEventArgs e)
        {
            ih_blueRadioButt.Checked = true;
        }

        private void ih_greenRadioButt_MouseClick(object sender, MouseEventArgs e)
        {
            ih_greenRadioButt.Checked = true;
        }

        private void ih_redRadioButt_MouseClick(object sender, MouseEventArgs e)
        {
            ih_redRadioButt.Checked = true;
        }
        private void ih_redRadioButt_CheckedChanged(object sender, EventArgs e)
        {
            ih_blueRadioButt.Checked = false;
            ih_greenRadioButt.Checked = false;
        }

        private void ih_greenRadioButt_CheckedChanged(object sender, EventArgs e)
        {
            ih_redRadioButt.Checked = false;
            ih_blueRadioButt.Checked = false;
        }

        private void ih_blueRadioButt_CheckedChanged(object sender, EventArgs e)
        {
            ih_redRadioButt.Checked = false;
            ih_greenRadioButt.Checked = false;
        }
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
        /// <summary>
        /// This method shows a metro message box for creator informations
        /// </summary>
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
            try
            {
                // Make sure to stop camera captures
                if (capture != null)
                {
                    capture.Stop();
                    capture.Dispose();
                }
                capture = null;
                // For better visualisation
                TurnVisibilityOffToAllButtons();
                DeletePictureBoxes();
            }
            catch (Exception)
            {
                
            }
        }

        #endregion

        #region Helper methods
        /// <summary>
        /// This method is called at the load method and when selecting a tab.
        /// It turns off the visibility to all form buttons
        /// </summary>
        private void TurnVisibilityOffToAllButtons()
        {
            try
            {
                ed_detectEdgeButt.Visible = false;
                ed_stopCameraButt.Visible = false;
                ib_binarizeButt.Visible = false;
                ih_histogramButt.Visible = false;
                ih_redRadioButt.Visible = false;
                ih_greenRadioButt.Visible = false;
                ih_blueRadioButt.Visible = false;
                m_erosionButt.Visible = false;
                m_dilationButt.Visible = false;
                m_openButt.Visible = false;
                m_closeButt.Visible = false;
                m_gradientButt.Visible = false;
                m_topHatButt.Visible = false;
                m_blackHatButt.Visible = false;
                m_dilateOnBinaryButt.Visible = false;
                m_erodeOnBinaryButt.Visible = false;
                sd_DetectShapeButt.Visible = false;
                sd_stopCameraButt.Visible = false;
                td_DetectTextButt.Visible = false;
                td_stopCameraButt.Visible = false;
                fd_detectFaceButt.Visible = false;
                fd_stopCameraButt.Visible = false;
                hg_stopCameraButt.Visible = false;
            }
            catch (Exception)
            {
                
            }
        }

        /// <summary>
        /// This method deletes all picture boxes. It's called on the tab selected event
        /// </summary>
        private void DeletePictureBoxes()
        {
            try
            {
                ed_imgInputPicBox.Image = null;
                ed_imgOutputPicBox.Image = null;
                ib_imgInputPicBox.Image = null;
                ib_imgOutputPicBox.Image = null;
                ih_imgInputPicBox.Image = null;
                histogramBox.ClearHistogram();
                m_imgInputPicBox.Image = null;
                m_imgOutputPicBox.Image = null;
                sd_imgInputPicBox.Image = null;
                sd_imgOutputPicBox.Image = null;
                td_imgInputPicBox.Image = null;
                td_imgOutputPicBox.Image = null;
                fd_imgInputPicBox.Image = null;
                fd_imgOutputPicBox.Image = null;
                hg_imgInputPicBox.Image = null;
                hg_imgOutputPicBox.Image = null;
            }
            catch (Exception)
            {
                
            }
        }
        #endregion
    }
}
