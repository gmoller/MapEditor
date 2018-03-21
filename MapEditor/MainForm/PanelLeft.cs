using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public class PanelLeft : Control
    {
        private readonly Panel _panel;

        private int Width => 200;

        public PanelLeft(Form parentForm)
        {
            ParentForm = parentForm;
            _panel = new Panel();
        }

        public override Panel Create(EventHandler[] handlers1, MouseEventHandler[] handlers2)
        {
            Label lblSelectedPalette = Helper.CreateLabel(new Point(0, 0), "lblSelectedPalette", 0, "Palette:");
            ComboBox cboPalette = Helper.CreateComboBox(new Point(0, 0), new Size(0, 0), "cboPalette", 1, handlers1[0]);
            PictureBox picPalette = Helper.CreatePictureBox(new Point(0, 0), new Size(0, 0), "picPalette", PictureBoxSizeMode.Normal, 2, handlers1[1], null, null);
            PictureBox picSelectedImage = Helper.CreatePictureBox(new Point(0, 0), new Size(0, 0), "picSelectedImage", PictureBoxSizeMode.StretchImage, 3, null, null, null);
            Label lblSelectedImage = Helper.CreateLabel(new Point(0, 0), "lblSelectedImage", 4, "Test");

            _panel.SuspendLayout();

            _panel.BorderStyle = BorderStyle.Fixed3D;
            _panel.Controls.Add(lblSelectedPalette);
            _panel.Controls.Add(cboPalette);
            _panel.Controls.Add(picPalette);
            _panel.Controls.Add(picSelectedImage);
            _panel.Controls.Add(lblSelectedImage);

            _panel.Location = new Point(0, 0);
            _panel.Name = "pnlLeft";
            _panel.Size = new Size(0, 0);
            _panel.TabIndex = 1;

            Resize();

            return _panel;
        }

        public override void Resize()
        {
            _panel.Enabled = Enabled;

            _panel.Location = new Point(0, Top + MenuHeight); // top left, below menu
            _panel.Size = new Size(Width, ParentForm.ClientSize.Height - MenuHeight);

            Label lblSelectedPalette = _panel.Controls.Find("lblSelectedPalette", true).First() as Label;
            if (lblSelectedPalette == null) throw new Exception("Control [lblSelectedPalette] not found on form.");
            lblSelectedPalette.Location = new Point(0 + 10, 0 + 5);

            ComboBox cboPalette = _panel.Controls.Find("cboPalette", true).First() as ComboBox;
            if (cboPalette == null) throw new Exception("Control [cboPalette] not found on form.");
            cboPalette.Size = new Size(130, 21);
            cboPalette.Location = new Point(_panel.Right - cboPalette.Width - 10, lblSelectedPalette.Top);

            PictureBox picPalette = _panel.Controls.Find("picPalette", true).First() as PictureBox;
            if (picPalette == null) throw new Exception("Control [picPalette] not found on form.");
            picPalette.Size = new Size(_panel.Width - 10 - 10, _panel.Height - 80);
            picPalette.Location = new Point(0 + 10, cboPalette.Bottom + 5);

            PictureBox picSelectedImage = _panel.Controls.Find("picSelectedImage", true).First() as PictureBox;
            if (picSelectedImage == null) throw new Exception("Control [picSelectedImage] not found on form.");
            picSelectedImage.Size = new Size(32, 32);
            picSelectedImage.Location = new Point(0 + 10, _panel.Bottom - MenuHeight - picSelectedImage.Height - 4 - 5);

            Label lblSelectedImage = _panel.Controls.Find("lblSelectedImage", true).First() as Label;
            if (lblSelectedImage == null) throw new Exception("Control [lblSelectedImage] not found on form.");
            lblSelectedImage.Location = new Point(picSelectedImage.Right + 10, picSelectedImage.Top + 10);
        }
    }
}