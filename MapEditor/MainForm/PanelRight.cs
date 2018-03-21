using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public class PanelRight : Control
    {
        private readonly Panel _panel;

        private int Width => 150;

        public PanelRight(Form parentForm)
        {
            ParentForm = parentForm;
            _panel = new Panel();
        }

        public override Panel Create(EventHandler[] handlers1, MouseEventHandler[] handlers2)
        {
            Label lblVisible = Helper.CreateLabel(new Point(0, 0), "lblVisible", 0, "Visible?");
            RadioButton radLayer0 = Helper.CreateRadioButton(new Point(0, 0), "radLayer0", 1, "Layer 0", true, 0, handlers1[0]);
            RadioButton radLayer1 = Helper.CreateRadioButton(new Point(0, 0), "radLayer1", 2, "Layer 1", false, 1, handlers1[0]);
            RadioButton radLayer2 = Helper.CreateRadioButton(new Point(0, 0), "radLayer2", 3, "Layer 2", false, 2, handlers1[0]);
            RadioButton radLayer3 = Helper.CreateRadioButton(new Point(0, 0), "radLayer3", 4, "Layer 3", false, 3, handlers1[0]);

            CheckBox chkLayer0Visible = Helper.CreateCheckbox(new Point(0, 0), "chkLayer0Visible", 5, 0, handlers1[1]);
            CheckBox chkLayer1Visible = Helper.CreateCheckbox(new Point(0, 0), "chkLayer1Visible", 6, 1, handlers1[1]);
            CheckBox chkLayer2Visible = Helper.CreateCheckbox(new Point(0, 0), "chkLayer2Visible", 7, 2, handlers1[1]);
            CheckBox chkLayer3Visible = Helper.CreateCheckbox(new Point(0, 0), "chkLayer3Visible", 8, 3, handlers1[1]);

            _panel.SuspendLayout();

            _panel.BorderStyle = BorderStyle.Fixed3D;
            _panel.Controls.Add(lblVisible);
            _panel.Controls.Add(radLayer0);
            _panel.Controls.Add(radLayer1);
            _panel.Controls.Add(radLayer2);
            _panel.Controls.Add(radLayer3);
            _panel.Controls.Add(chkLayer0Visible);
            _panel.Controls.Add(chkLayer1Visible);
            _panel.Controls.Add(chkLayer2Visible);
            _panel.Controls.Add(chkLayer3Visible);
            _panel.Location = new Point(0, 0);
            _panel.Name = "pnlRight";
            _panel.Size = new Size(0, 0);
            _panel.TabIndex = 3;
            
            Resize();

            return _panel;
        }

        public override void Resize()
        {
            _panel.Enabled = Enabled;

            _panel.Location = new Point(ParentForm.ClientSize.Width - Width, Top + MenuHeight); // top right, below menu
            _panel.Size = new Size(150, ParentForm.ClientSize.Height - 24);

            Label lblVisible = _panel.Controls.Find("lblVisible", true).First() as Label;
            if (lblVisible == null) throw new Exception("Control [lblVisible] not found on form.");
            lblVisible.Location = new Point(_panel.Width - 55, 0 + 5);

            RadioButton radLayer0 = _panel.Controls.Find("radLayer0", true).First() as RadioButton;
            if (radLayer0 == null) throw new Exception("Control [radLayer0] not found on form.");
            radLayer0.Location = new Point(0 + 10, 0 + 20);

            RadioButton radLayer1 = _panel.Controls.Find("radLayer1", true).First() as RadioButton;
            if (radLayer1 == null) throw new Exception("Control [radLayer1] not found on form.");
            radLayer1.Location = new Point(0 + 10, radLayer0.Top + 20);

            RadioButton radLayer2 = _panel.Controls.Find("radLayer2", true).First() as RadioButton;
            if (radLayer2 == null) throw new Exception("Control [radLayer2] not found on form.");
            radLayer2.Location = new Point(0 + 10, radLayer1.Top + 20);

            RadioButton radLayer3 = _panel.Controls.Find("radLayer3", true).First() as RadioButton;
            if (radLayer3 == null) throw new Exception("Control [radLayer3] not found on form.");
            radLayer3.Location = new Point(0 + 10, radLayer2.Top + 20);

            CheckBox chkLayer0Visible = _panel.Controls.Find("chkLayer0Visible", true).First() as CheckBox;
            if (chkLayer0Visible == null) throw new Exception("Control [chkLayer0Visible] not found on form.");
            chkLayer0Visible.Location = new Point(radLayer0.Right, radLayer0.Top);

            CheckBox chkLayer1Visible = _panel.Controls.Find("chkLayer1Visible", true).First() as CheckBox;
            if (chkLayer1Visible == null) throw new Exception("Control [chkLayer1Visible] not found on form.");
            chkLayer1Visible.Location = new Point(radLayer1.Right, radLayer1.Top);

            CheckBox chkLayer2Visible = _panel.Controls.Find("chkLayer2Visible", true).First() as CheckBox;
            if (chkLayer2Visible == null) throw new Exception("Control [chkLayer2Visible] not found on form.");
            chkLayer2Visible.Location = new Point(radLayer2.Right, radLayer2.Top);

            CheckBox chkLayer3Visible = _panel.Controls.Find("chkLayer3Visible", true).First() as CheckBox;
            if (chkLayer3Visible == null) throw new Exception("Control [chkLayer3Visible] not found on form.");
            chkLayer3Visible.Location = new Point(radLayer3.Right, radLayer3.Top);
        }
    }
}