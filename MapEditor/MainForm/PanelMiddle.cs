using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public class PanelMiddle : Control
    {
        private readonly Panel _panel;

        public PanelMiddle(Form parentForm)
        {
            ParentForm = parentForm;
            _panel = new Panel();
        }

        public override Panel Create(EventHandler[] handlers1, MouseEventHandler[] handlers2)
        {
            PictureBox picMap = Helper.CreatePictureBox(new Point(0, 0), new Size(0, 0), "picMap", PictureBoxSizeMode.AutoSize, 0, null, handlers2[0], handlers2[1]);

            _panel.SuspendLayout();

            _panel.AutoScroll = true;
            _panel.BorderStyle = BorderStyle.Fixed3D;
            _panel.Controls.Add(picMap);
            _panel.Location = new Point(0, 0);
            _panel.Name = "pnlLeft";
            _panel.Size = new Size(0, 0);
            _panel.TabIndex = 2;

            Resize();

            return _panel;
        }

        public override void Resize()
        {
            _panel.Enabled = Enabled;

            _panel.Location = new Point(201, Top + MenuHeight);
            _panel.Size = new Size(ParentForm.ClientSize.Width - 201 - 150, ParentForm.ClientSize.Height - MenuHeight);

            PictureBox picMap = _panel.Controls.Find("picMap", true).First() as PictureBox;
            if (picMap == null) throw new Exception("Control [picMap] not found on form.");
            picMap.Size = new Size(_panel.Width - 4, _panel.Height - 4);
            picMap.Location = new Point(0, 0);
        }
    }
}