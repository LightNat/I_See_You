using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_See_You.Prefect_of_Discipline
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void PoD_Login_Load(object sender, EventArgs e)
        {
            SetBackgroundGradient();
        }

        private void SetBackgroundGradient()
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, ColorTranslator.FromHtml("#C0E6F8"), ColorTranslator.FromHtml("#F3D2DD"), 50);
            BackgroundImage = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics graphics = Graphics.FromImage(BackgroundImage))
            {
                graphics.FillRectangle(gradientBrush, ClientRectangle);
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Visible = false;
            dashboard.Show();
        }
    }
}
