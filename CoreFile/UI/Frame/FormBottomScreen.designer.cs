namespace Core.UI
{
    partial class FormBottomScreen
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
            this.panel_FormBorder = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_FormBorder
            // 
            this.panel_FormBorder.BackColor = System.Drawing.Color.Transparent;
            this.panel_FormBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel_FormBorder.Location = new System.Drawing.Point(0, 2);
            this.panel_FormBorder.Name = "panel_FormBorder";
            this.panel_FormBorder.Size = new System.Drawing.Size(198, 946);
            this.panel_FormBorder.TabIndex = 0;
            this.panel_FormBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_FormBorder_Paint);
            // 
            // FormBottomScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(200, 950);
            this.ControlBox = false;
            this.Controls.Add(this.panel_FormBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBottomScreen";
            this.Text = "Bottom Screen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_FormBorder;
    }
}