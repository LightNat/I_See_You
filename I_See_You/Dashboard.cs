using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_See_You
{
    public partial class Dashboard : Form
    {
        private static Dictionary<string, Image> imageCache = new Dictionary<string, Image>();
        private Bitmap backgroundBitmap;

        public Dashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (backgroundBitmap == null || backgroundBitmap.Size != ClientSize)
            {
                backgroundBitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
                using (Graphics g = Graphics.FromImage(backgroundBitmap))
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    ClientRectangle, ColorTranslator.FromHtml("#C0E6F8"), ColorTranslator.FromHtml("#F3D2DD"), 50))
                {
                    g.FillRectangle(brush, ClientRectangle);
                }
            }

            e.Graphics.DrawImage(backgroundBitmap, 0, 0);
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            LoadBackgroundImage();
            await LoadLogoImage();

            this.ActiveControl = image_logo; // Focus on the image first
        }

        private void LoadBackgroundImage()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            UpdateStyles();
        }

        private async Task LoadLogoImage()
        {
            var panel_menu = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logo\\business_people.png";
            panelmenu.BackgroundImage = await LoadImageFromCacheAsync(panel_menu);
            panelmenu.BackgroundImageLayout = ImageLayout.Stretch;

            var uclm_logo = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logo\\I_See_You.png";
            image_logo.Image = await LoadImageFromCacheAsync(uclm_logo);
        }

        private static async Task<Image> LoadImageFromCacheAsync(string imagePath)
        {
            if (imageCache.ContainsKey(imagePath))
            {
                return imageCache[imagePath];
            }

            Image image = await Task.Run(() => Image.FromFile(imagePath));
            imageCache.Add(imagePath, image);
            return image;
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
