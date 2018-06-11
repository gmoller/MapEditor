using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public class PanelNewGame : Control
    {
        private readonly Panel _panel;

        private int Height => 100;

        public PanelNewGame(MainForm parentForm)
        {
            ParentForm = parentForm;
            _panel = new Panel();
        }

        public override Panel Create(EventHandler[] handlers1, MouseEventHandler[] handlers2)
        {
            Label lblName = Helper.CreateLabel(new Point(0, 0), "lblName", 0, "Name:");
            TextBox txtName = Helper.CreateTextBox("txtName", 1);
            Label lblWidth = Helper.CreateLabel(new Point(0, 0), "lblWidth", 2, "Wifth:");
            TextBox txtWidth = Helper.CreateTextBox("txtWidth", 3);
            Label lblHeight = Helper.CreateLabel(new Point(0, 0), "lblHeight", 4, "Height:");
            TextBox txtHeight = Helper.CreateTextBox("txtHeight", 5);
            Button btnOk = Helper.CreateButton("btnOk", "Ok");
            Button btnCancel = Helper.CreateButton("btnCancel", "Cancel");

            _panel.SuspendLayout();

            _panel.BorderStyle = BorderStyle.Fixed3D;
            _panel.Controls.Add(lblName);
            _panel.Controls.Add(txtName);
            _panel.Controls.Add(lblWidth);
            _panel.Controls.Add(txtWidth);
            _panel.Controls.Add(lblHeight);
            _panel.Controls.Add(txtHeight);
            _panel.Controls.Add(btnOk);
            _panel.Controls.Add(btnCancel);
            _panel.Location = new Point(0, 0);
            _panel.Name = "pnlNewGame";
            _panel.Size = new Size(0, 0);
            _panel.TabIndex = 0;

            Resize();

            return _panel;
        }

        public override void Resize()
        {
            _panel.Enabled = Enabled;

            _panel.Location = new Point(0, Top + MenuHeight); // top left, below menu
            _panel.Size = new Size(ParentForm.ClientSize.Width, Height);

            Label lblName = _panel.Controls.Find("lblName", true).First() as Label;
            if (lblName == null) throw new Exception("Control [lblName] not found on form.");
            lblName.Location = new Point(0 + 10, 0 + 5);

            Label lblWidth = _panel.Controls.Find("lblWidth", true).First() as Label;
            if (lblWidth == null) throw new Exception("Control [lblWidth] not found on form.");
            lblWidth.Location = new Point(0 + 10, lblName.Bottom + 5);

            Label lblHeight = _panel.Controls.Find("lblHeight", true).First() as Label;
            if (lblHeight == null) throw new Exception("Control [lblHeight] not found on form.");
            lblHeight.Location = new Point(0 + 10, lblWidth.Bottom + 5);
        }
    }
}