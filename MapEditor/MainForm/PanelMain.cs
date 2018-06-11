using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public class PanelMain : Control
    {
        private readonly Panel _panel;

        private Control _panelLeft;
        private Control _panelMiddle;
        private Control _panelRight;

        public PanelMain(MainForm parentForm)
        {
            ParentForm = parentForm;
            _panel = new Panel();
        }

        public override Panel Create(EventHandler[] handlers1, MouseEventHandler[] handlers2)
        {
            _panelLeft = new PanelLeft(ParentForm);
            Panel pnlLeft = _panelLeft.Create(new EventHandler[] { ParentForm.cboPalette_SelectedIndexChanged, ParentForm.picPalette_Click }, null);

            _panelMiddle = new PanelMiddle(ParentForm);
            Panel pnlMiddle = _panelMiddle.Create(null, new MouseEventHandler[] { ParentForm.picMap_MouseDown, ParentForm.picMap_MouseUp });

            _panelRight = new PanelRight(ParentForm);
            Panel pnlRight = _panelRight.Create(new EventHandler[] { ParentForm.radioButton_CheckedChanged, ParentForm.chkLayerVisible_CheckedChanged }, null);

            Resize();

            return _panel;
        }

        public IEnumerable<System.Windows.Forms.Control> Controls
        {
            get
            {
                yield return _panelLeft.AControl;
                yield return _panelMiddle.AControl;
                yield return _panelRight.AControl;
            }
        }

        public int Top
        {
            set
            {
                _panelLeft.Top = value;
                _panelMiddle.Top = value;
                _panelRight.Top = value;
            }
        }

        public bool Enabled
        {
            set
            {
                _panelLeft.Enabled = value;
                _panelMiddle.Enabled = value;
                _panelRight.Enabled = value;
            }
        }

        public void Resize()
        {
            _panelLeft.Resize();
            _panelMiddle.Resize();
            _panelRight.Resize();
        }
    }
}