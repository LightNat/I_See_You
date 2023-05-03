using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_See_You
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            
        }

        

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SetBackgroundGradient();

            var panel_menu = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logo\\business_people.png";
            panelmenu.BackgroundImage = Image.FromFile(panel_menu);
            panelmenu.BackgroundImageLayout = ImageLayout.Stretch;

            var uclm_logo = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logo\\I_See_You.png";
            image_logo.Image = Image.FromFile(uclm_logo);

            this.ActiveControl = image_logo;    //to focus on image first
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

        private void linkLabeledp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EDP.Login login = new EDP.Login();
            this.Visible = false;
            login.Show();
        }

        private void linkLabelpod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Prefect_of_Discipline.Login login = new Prefect_of_Discipline.Login();
            this.Visible = false;
            login.Show();
        }

        private void linkLabelsao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SAO.Login login = new SAO.Login();
            this.Visible = false;
            login.Show();
        }

        private void linkLabelaccounting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Accounting.Login login = new Accounting.Login();
            this.Visible = false;
            login.Show();
        }
    }
}
