using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Layers;

using static Core.Layers.DEF_UI;

namespace Core.UI
{
    public partial class FormBottomScreen : Form
    {
        
        private EFormType CurrentPage = EFormType.NONE;

        public FormBottomScreen()
        {
            InitializeComponent();

            InitializeForm();
        }


        protected virtual void InitializeForm()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.DesktopLocation = new Point(DEF_UI.BOT_POS_X, DEF_UI.BOT_POS_Y);
            this.Size = new Size(DEF_UI.BOT_SIZE_WIDTH, DEF_UI.BOT_SIZE_HEIGHT);
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void panel_FormBorder_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 2;
            Color borderColor = System.Drawing.ColorTranslator.FromHtml("#333333");

            
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
             borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,

            ButtonBorderStyle.Solid, borderColor, borderWidth,
             ButtonBorderStyle.Solid,

            borderColor, borderWidth, ButtonBorderStyle.Solid);
        }
    }
}
