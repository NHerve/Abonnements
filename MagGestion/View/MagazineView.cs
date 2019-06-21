using MagGestion.Controls.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class MagazineForm : Form
    {
        private Control _control;
        private readonly string _id;
        public MagazineForm(Control control, string id)
        {
            InitializeComponent();
            _control = control;
            _id = id;
            _control.Parent.Parent.Enabled = false;
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void BTQuit_Click(object sender, EventArgs e)
        {
            _control.Parent.Parent.Enabled = true;

            this.Close();
        }

        private void BTSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {

                dlg.Title = "Choisir couverture";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PicturePhoto.Image = new Bitmap(dlg.FileName);
                    PicturePhoto.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }
        private void Initialize(int id)
        {
            //  Magazine magazine = new MagazineDataService().GetMagazine(id);
        }
    }
}
