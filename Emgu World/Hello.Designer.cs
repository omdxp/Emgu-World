namespace Emgu_World
{
    partial class Hello
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hello));
            this.handGestureTile = new MetroFramework.Controls.MetroTile();
            this.faceDetectionTile = new MetroFramework.Controls.MetroTile();
            this.textDetectionTile = new MetroFramework.Controls.MetroTile();
            this.shapeDetectionTile = new MetroFramework.Controls.MetroTile();
            this.morphologyTile = new MetroFramework.Controls.MetroTile();
            this.imageHistogramTile = new MetroFramework.Controls.MetroTile();
            this.imageBinrizationTile = new MetroFramework.Controls.MetroTile();
            this.edgeDetectionTile = new MetroFramework.Controls.MetroTile();
            this.slidesPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.slidesPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // handGestureTile
            // 
            this.handGestureTile.ActiveControl = null;
            this.handGestureTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.handGestureTile.Location = new System.Drawing.Point(190, 368);
            this.handGestureTile.Name = "handGestureTile";
            this.handGestureTile.Size = new System.Drawing.Size(191, 132);
            this.handGestureTile.TabIndex = 17;
            this.handGestureTile.Text = "Hand Gesture";
            this.handGestureTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.handGestureTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.handGestureTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.handGestureTile.UseSelectable = true;
            this.handGestureTile.UseTileImage = true;
            this.handGestureTile.Click += new System.EventHandler(this.handGestureTile_Click);
            // 
            // faceDetectionTile
            // 
            this.faceDetectionTile.ActiveControl = null;
            this.faceDetectionTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.faceDetectionTile.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.faceDetectionTile.Location = new System.Drawing.Point(23, 506);
            this.faceDetectionTile.Name = "faceDetectionTile";
            this.faceDetectionTile.Size = new System.Drawing.Size(304, 129);
            this.faceDetectionTile.TabIndex = 16;
            this.faceDetectionTile.Text = "Face Detection";
            this.faceDetectionTile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.faceDetectionTile.TileImage = global::Emgu_World.Properties.Resources.faceDetection;
            this.faceDetectionTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.faceDetectionTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.faceDetectionTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.faceDetectionTile.UseCustomForeColor = true;
            this.faceDetectionTile.UseSelectable = true;
            this.faceDetectionTile.UseTileImage = true;
            this.faceDetectionTile.Click += new System.EventHandler(this.faceDetectionTile_Click);
            // 
            // textDetectionTile
            // 
            this.textDetectionTile.ActiveControl = null;
            this.textDetectionTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textDetectionTile.ForeColor = System.Drawing.Color.Snow;
            this.textDetectionTile.Location = new System.Drawing.Point(458, 63);
            this.textDetectionTile.Name = "textDetectionTile";
            this.textDetectionTile.Size = new System.Drawing.Size(266, 70);
            this.textDetectionTile.TabIndex = 15;
            this.textDetectionTile.Text = "Text Detection";
            this.textDetectionTile.TileImage = global::Emgu_World.Properties.Resources.textDetection;
            this.textDetectionTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.textDetectionTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.textDetectionTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.textDetectionTile.UseCustomForeColor = true;
            this.textDetectionTile.UseSelectable = true;
            this.textDetectionTile.UseTileImage = true;
            this.textDetectionTile.Click += new System.EventHandler(this.textDetectionTile_Click);
            // 
            // shapeDetectionTile
            // 
            this.shapeDetectionTile.ActiveControl = null;
            this.shapeDetectionTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shapeDetectionTile.Location = new System.Drawing.Point(730, 368);
            this.shapeDetectionTile.Name = "shapeDetectionTile";
            this.shapeDetectionTile.Size = new System.Drawing.Size(279, 143);
            this.shapeDetectionTile.TabIndex = 14;
            this.shapeDetectionTile.Text = "Shape Detection";
            this.shapeDetectionTile.TileImage = global::Emgu_World.Properties.Resources.shapeDetection;
            this.shapeDetectionTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.shapeDetectionTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.shapeDetectionTile.UseCustomForeColor = true;
            this.shapeDetectionTile.UseSelectable = true;
            this.shapeDetectionTile.UseTileImage = true;
            this.shapeDetectionTile.Click += new System.EventHandler(this.shapeDetectionTile_Click);
            // 
            // morphologyTile
            // 
            this.morphologyTile.ActiveControl = null;
            this.morphologyTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.morphologyTile.ForeColor = System.Drawing.Color.Aqua;
            this.morphologyTile.Location = new System.Drawing.Point(730, 63);
            this.morphologyTile.Name = "morphologyTile";
            this.morphologyTile.Size = new System.Drawing.Size(279, 299);
            this.morphologyTile.TabIndex = 13;
            this.morphologyTile.Text = "Morphology";
            this.morphologyTile.TileImage = global::Emgu_World.Properties.Resources.morphology;
            this.morphologyTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.morphologyTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.morphologyTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.morphologyTile.UseCustomForeColor = true;
            this.morphologyTile.UseSelectable = true;
            this.morphologyTile.UseTileImage = true;
            this.morphologyTile.Click += new System.EventHandler(this.morphologyTile_Click);
            // 
            // imageHistogramTile
            // 
            this.imageHistogramTile.ActiveControl = null;
            this.imageHistogramTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageHistogramTile.ForeColor = System.Drawing.Color.Black;
            this.imageHistogramTile.Location = new System.Drawing.Point(190, 178);
            this.imageHistogramTile.Name = "imageHistogramTile";
            this.imageHistogramTile.Size = new System.Drawing.Size(262, 184);
            this.imageHistogramTile.TabIndex = 12;
            this.imageHistogramTile.Text = "Image Histogram";
            this.imageHistogramTile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.imageHistogramTile.TileImage = global::Emgu_World.Properties.Resources.imageHistogram;
            this.imageHistogramTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.imageHistogramTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.imageHistogramTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.imageHistogramTile.UseCustomForeColor = true;
            this.imageHistogramTile.UseSelectable = true;
            this.imageHistogramTile.UseTileImage = true;
            this.imageHistogramTile.Click += new System.EventHandler(this.imageHistogramTile_Click);
            // 
            // imageBinrizationTile
            // 
            this.imageBinrizationTile.ActiveControl = null;
            this.imageBinrizationTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBinrizationTile.ForeColor = System.Drawing.Color.DarkViolet;
            this.imageBinrizationTile.Location = new System.Drawing.Point(190, 63);
            this.imageBinrizationTile.Name = "imageBinrizationTile";
            this.imageBinrizationTile.Size = new System.Drawing.Size(262, 109);
            this.imageBinrizationTile.TabIndex = 11;
            this.imageBinrizationTile.Text = "Image Binarization";
            this.imageBinrizationTile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.imageBinrizationTile.TileImage = global::Emgu_World.Properties.Resources.imageBinarization;
            this.imageBinrizationTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.imageBinrizationTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.imageBinrizationTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.imageBinrizationTile.UseCustomForeColor = true;
            this.imageBinrizationTile.UseSelectable = true;
            this.imageBinrizationTile.UseTileImage = true;
            this.imageBinrizationTile.Click += new System.EventHandler(this.imageBinrizationTile_Click);
            // 
            // edgeDetectionTile
            // 
            this.edgeDetectionTile.ActiveControl = null;
            this.edgeDetectionTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edgeDetectionTile.ForeColor = System.Drawing.Color.AliceBlue;
            this.edgeDetectionTile.Location = new System.Drawing.Point(23, 63);
            this.edgeDetectionTile.Name = "edgeDetectionTile";
            this.edgeDetectionTile.Size = new System.Drawing.Size(161, 437);
            this.edgeDetectionTile.TabIndex = 10;
            this.edgeDetectionTile.Text = "Edge Detection";
            this.edgeDetectionTile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.edgeDetectionTile.TileImage = global::Emgu_World.Properties.Resources.edgeDetection;
            this.edgeDetectionTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edgeDetectionTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.edgeDetectionTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.edgeDetectionTile.UseCustomForeColor = true;
            this.edgeDetectionTile.UseSelectable = true;
            this.edgeDetectionTile.UseTileImage = true;
            this.edgeDetectionTile.Click += new System.EventHandler(this.edgeDetectionTile_Click);
            // 
            // slidesPicBox
            // 
            this.slidesPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slidesPicBox.Location = new System.Drawing.Point(20, 60);
            this.slidesPicBox.Name = "slidesPicBox";
            this.slidesPicBox.Size = new System.Drawing.Size(992, 578);
            this.slidesPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.slidesPicBox.TabIndex = 0;
            this.slidesPicBox.TabStop = false;
            // 
            // Hello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 658);
            this.ControlBox = false;
            this.Controls.Add(this.handGestureTile);
            this.Controls.Add(this.faceDetectionTile);
            this.Controls.Add(this.textDetectionTile);
            this.Controls.Add(this.shapeDetectionTile);
            this.Controls.Add(this.morphologyTile);
            this.Controls.Add(this.imageHistogramTile);
            this.Controls.Add(this.imageBinrizationTile);
            this.Controls.Add(this.edgeDetectionTile);
            this.Controls.Add(this.slidesPicBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Hello";
            this.Resizable = false;
            this.Text = "Hello";
            this.Load += new System.EventHandler(this.SlideShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slidesPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox slidesPicBox;
        private MetroFramework.Controls.MetroTile edgeDetectionTile;
        private MetroFramework.Controls.MetroTile imageBinrizationTile;
        private MetroFramework.Controls.MetroTile imageHistogramTile;
        private MetroFramework.Controls.MetroTile morphologyTile;
        private MetroFramework.Controls.MetroTile shapeDetectionTile;
        private MetroFramework.Controls.MetroTile textDetectionTile;
        private MetroFramework.Controls.MetroTile faceDetectionTile;
        private MetroFramework.Controls.MetroTile handGestureTile;
    }
}