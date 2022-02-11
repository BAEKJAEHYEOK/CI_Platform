namespace Core.UI
{
    partial class FormManualScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManualScreen));
            this.btn_AcquireImage = new System.Windows.Forms.Button();
            this.btn_RunRedTool = new System.Windows.Forms.Button();
            this.btn_LoadImage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rd_MainDisplay_Cam0 = new Cognex.VisionPro.CogRecordDisplay();
            this.btn_LiveOn = new System.Windows.Forms.Button();
            this.btn_LiveOff = new System.Windows.Forms.Button();
            this.lbl_Contrast = new System.Windows.Forms.Label();
            this.lbl_Brightness = new System.Windows.Forms.Label();
            this.lbl_Exposure = new System.Windows.Forms.Label();
            this.txt_Contrast = new System.Windows.Forms.TextBox();
            this.txt_Brightness = new System.Windows.Forms.TextBox();
            this.txt_Exposure = new System.Windows.Forms.TextBox();
            this.btn_CamSetApply = new System.Windows.Forms.Button();
            this.btn_RunBlueTool = new System.Windows.Forms.Button();
            this.btn_RunGreenTool = new System.Windows.Forms.Button();
            this.txt_BestTag = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rd_MainDisplay_Cam0)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AcquireImage
            // 
            this.btn_AcquireImage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AcquireImage.ForeColor = System.Drawing.Color.Black;
            this.btn_AcquireImage.Location = new System.Drawing.Point(1195, 8);
            this.btn_AcquireImage.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AcquireImage.Name = "btn_AcquireImage";
            this.btn_AcquireImage.Size = new System.Drawing.Size(128, 67);
            this.btn_AcquireImage.TabIndex = 47;
            this.btn_AcquireImage.Text = "Acquire Image";
            this.btn_AcquireImage.UseVisualStyleBackColor = true;
            this.btn_AcquireImage.Click += new System.EventHandler(this.btn_AcquireImage_Click);
            // 
            // btn_RunRedTool
            // 
            this.btn_RunRedTool.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RunRedTool.ForeColor = System.Drawing.Color.Black;
            this.btn_RunRedTool.Location = new System.Drawing.Point(1195, 248);
            this.btn_RunRedTool.Margin = new System.Windows.Forms.Padding(2);
            this.btn_RunRedTool.Name = "btn_RunRedTool";
            this.btn_RunRedTool.Size = new System.Drawing.Size(128, 67);
            this.btn_RunRedTool.TabIndex = 49;
            this.btn_RunRedTool.Text = "Run RedTool";
            this.btn_RunRedTool.UseVisualStyleBackColor = true;
            this.btn_RunRedTool.Click += new System.EventHandler(this.btn_RunRedTool_Click);
            // 
            // btn_LoadImage
            // 
            this.btn_LoadImage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadImage.ForeColor = System.Drawing.Color.Black;
            this.btn_LoadImage.Location = new System.Drawing.Point(1195, 79);
            this.btn_LoadImage.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LoadImage.Name = "btn_LoadImage";
            this.btn_LoadImage.Size = new System.Drawing.Size(128, 67);
            this.btn_LoadImage.TabIndex = 50;
            this.btn_LoadImage.Text = "Load Image";
            this.btn_LoadImage.UseVisualStyleBackColor = true;
            this.btn_LoadImage.Click += new System.EventHandler(this.btn_LoadImage_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.rd_MainDisplay_Cam0);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 931);
            this.panel2.TabIndex = 4;
            // 
            // rd_MainDisplay_Cam0
            // 
            this.rd_MainDisplay_Cam0.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.rd_MainDisplay_Cam0.ColorMapLowerRoiLimit = 0D;
            this.rd_MainDisplay_Cam0.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.rd_MainDisplay_Cam0.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.rd_MainDisplay_Cam0.ColorMapUpperRoiLimit = 1D;
            this.rd_MainDisplay_Cam0.DoubleTapZoomCycleLength = 2;
            this.rd_MainDisplay_Cam0.DoubleTapZoomSensitivity = 2.5D;
            this.rd_MainDisplay_Cam0.Location = new System.Drawing.Point(0, 0);
            this.rd_MainDisplay_Cam0.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.rd_MainDisplay_Cam0.MouseWheelSensitivity = 1D;
            this.rd_MainDisplay_Cam0.Name = "rd_MainDisplay_Cam0";
            this.rd_MainDisplay_Cam0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rd_MainDisplay_Cam0.OcxState")));
            this.rd_MainDisplay_Cam0.Size = new System.Drawing.Size(1182, 931);
            this.rd_MainDisplay_Cam0.TabIndex = 0;
            // 
            // btn_LiveOn
            // 
            this.btn_LiveOn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LiveOn.ForeColor = System.Drawing.Color.Black;
            this.btn_LiveOn.Location = new System.Drawing.Point(1195, 347);
            this.btn_LiveOn.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LiveOn.Name = "btn_LiveOn";
            this.btn_LiveOn.Size = new System.Drawing.Size(128, 67);
            this.btn_LiveOn.TabIndex = 51;
            this.btn_LiveOn.Text = "Live On";
            this.btn_LiveOn.UseVisualStyleBackColor = true;
            this.btn_LiveOn.Click += new System.EventHandler(this.btn_LiveOn_Click);
            // 
            // btn_LiveOff
            // 
            this.btn_LiveOff.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LiveOff.ForeColor = System.Drawing.Color.Black;
            this.btn_LiveOff.Location = new System.Drawing.Point(1327, 347);
            this.btn_LiveOff.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LiveOff.Name = "btn_LiveOff";
            this.btn_LiveOff.Size = new System.Drawing.Size(128, 67);
            this.btn_LiveOff.TabIndex = 52;
            this.btn_LiveOff.Text = "Live Off";
            this.btn_LiveOff.UseVisualStyleBackColor = true;
            this.btn_LiveOff.Click += new System.EventHandler(this.btn_LiveOff_Click);
            // 
            // lbl_Contrast
            // 
            this.lbl_Contrast.AutoSize = true;
            this.lbl_Contrast.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_Contrast.Location = new System.Drawing.Point(1196, 489);
            this.lbl_Contrast.Name = "lbl_Contrast";
            this.lbl_Contrast.Size = new System.Drawing.Size(52, 12);
            this.lbl_Contrast.TabIndex = 55;
            this.lbl_Contrast.Text = "Contrast";
            // 
            // lbl_Brightness
            // 
            this.lbl_Brightness.AutoSize = true;
            this.lbl_Brightness.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_Brightness.Location = new System.Drawing.Point(1196, 462);
            this.lbl_Brightness.Name = "lbl_Brightness";
            this.lbl_Brightness.Size = new System.Drawing.Size(65, 12);
            this.lbl_Brightness.TabIndex = 54;
            this.lbl_Brightness.Text = "Brightness";
            // 
            // lbl_Exposure
            // 
            this.lbl_Exposure.AutoSize = true;
            this.lbl_Exposure.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_Exposure.Location = new System.Drawing.Point(1197, 435);
            this.lbl_Exposure.Name = "lbl_Exposure";
            this.lbl_Exposure.Size = new System.Drawing.Size(59, 12);
            this.lbl_Exposure.TabIndex = 53;
            this.lbl_Exposure.Text = "Exposure";
            // 
            // txt_Contrast
            // 
            this.txt_Contrast.Location = new System.Drawing.Point(1267, 486);
            this.txt_Contrast.Name = "txt_Contrast";
            this.txt_Contrast.Size = new System.Drawing.Size(100, 21);
            this.txt_Contrast.TabIndex = 58;
            this.txt_Contrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Brightness
            // 
            this.txt_Brightness.Location = new System.Drawing.Point(1267, 459);
            this.txt_Brightness.Name = "txt_Brightness";
            this.txt_Brightness.Size = new System.Drawing.Size(100, 21);
            this.txt_Brightness.TabIndex = 57;
            this.txt_Brightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Exposure
            // 
            this.txt_Exposure.Location = new System.Drawing.Point(1267, 432);
            this.txt_Exposure.Name = "txt_Exposure";
            this.txt_Exposure.Size = new System.Drawing.Size(100, 21);
            this.txt_Exposure.TabIndex = 56;
            this.txt_Exposure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_CamSetApply
            // 
            this.btn_CamSetApply.Location = new System.Drawing.Point(1390, 484);
            this.btn_CamSetApply.Name = "btn_CamSetApply";
            this.btn_CamSetApply.Size = new System.Drawing.Size(75, 23);
            this.btn_CamSetApply.TabIndex = 59;
            this.btn_CamSetApply.Text = "Apply";
            this.btn_CamSetApply.UseVisualStyleBackColor = true;
            this.btn_CamSetApply.Click += new System.EventHandler(this.btn_CamSetApply_Click);
            // 
            // btn_RunBlueTool
            // 
            this.btn_RunBlueTool.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RunBlueTool.ForeColor = System.Drawing.Color.Black;
            this.btn_RunBlueTool.Location = new System.Drawing.Point(1327, 248);
            this.btn_RunBlueTool.Margin = new System.Windows.Forms.Padding(2);
            this.btn_RunBlueTool.Name = "btn_RunBlueTool";
            this.btn_RunBlueTool.Size = new System.Drawing.Size(128, 67);
            this.btn_RunBlueTool.TabIndex = 60;
            this.btn_RunBlueTool.Text = "Run BlueTool";
            this.btn_RunBlueTool.UseVisualStyleBackColor = true;
            this.btn_RunBlueTool.Click += new System.EventHandler(this.btn_RunBlueTool_Click);
            // 
            // btn_RunGreenTool
            // 
            this.btn_RunGreenTool.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RunGreenTool.ForeColor = System.Drawing.Color.Black;
            this.btn_RunGreenTool.Location = new System.Drawing.Point(1459, 248);
            this.btn_RunGreenTool.Margin = new System.Windows.Forms.Padding(2);
            this.btn_RunGreenTool.Name = "btn_RunGreenTool";
            this.btn_RunGreenTool.Size = new System.Drawing.Size(128, 67);
            this.btn_RunGreenTool.TabIndex = 61;
            this.btn_RunGreenTool.Text = "Run GreenTool";
            this.btn_RunGreenTool.UseVisualStyleBackColor = true;
            this.btn_RunGreenTool.Click += new System.EventHandler(this.btn_RunGreenTool_Click);
            // 
            // txt_BestTag
            // 
            this.txt_BestTag.Location = new System.Drawing.Point(1605, 248);
            this.txt_BestTag.Name = "txt_BestTag";
            this.txt_BestTag.Size = new System.Drawing.Size(100, 21);
            this.txt_BestTag.TabIndex = 62;
            this.txt_BestTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1720, 2);
            this.panel4.TabIndex = 63;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 948);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1720, 2);
            this.panel1.TabIndex = 64;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 950);
            this.panel3.TabIndex = 65;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(1718, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 950);
            this.panel5.TabIndex = 66;
            // 
            // FormManualScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1720, 950);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txt_BestTag);
            this.Controls.Add(this.btn_RunGreenTool);
            this.Controls.Add(this.btn_RunBlueTool);
            this.Controls.Add(this.btn_CamSetApply);
            this.Controls.Add(this.txt_Contrast);
            this.Controls.Add(this.txt_Brightness);
            this.Controls.Add(this.txt_Exposure);
            this.Controls.Add(this.lbl_Contrast);
            this.Controls.Add(this.lbl_Brightness);
            this.Controls.Add(this.lbl_Exposure);
            this.Controls.Add(this.btn_LiveOff);
            this.Controls.Add(this.btn_LiveOn);
            this.Controls.Add(this.btn_LoadImage);
            this.Controls.Add(this.btn_RunRedTool);
            this.Controls.Add(this.btn_AcquireImage);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormManualScreen";
            this.Text = "vAcquire Image";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rd_MainDisplay_Cam0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AcquireImage;
        private System.Windows.Forms.Button btn_RunRedTool;
        private System.Windows.Forms.Button btn_LoadImage;
        private System.Windows.Forms.Panel panel2;
        private Cognex.VisionPro.CogRecordDisplay rd_MainDisplay_Cam0;
        private System.Windows.Forms.Button btn_LiveOn;
        private System.Windows.Forms.Button btn_LiveOff;
        private System.Windows.Forms.Label lbl_Contrast;
        private System.Windows.Forms.Label lbl_Brightness;
        private System.Windows.Forms.Label lbl_Exposure;
        public System.Windows.Forms.TextBox txt_Contrast;
        public System.Windows.Forms.TextBox txt_Brightness;
        public System.Windows.Forms.TextBox txt_Exposure;
        private System.Windows.Forms.Button btn_CamSetApply;
        private System.Windows.Forms.Button btn_RunBlueTool;
        private System.Windows.Forms.Button btn_RunGreenTool;
        public System.Windows.Forms.TextBox txt_BestTag;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
    }
}