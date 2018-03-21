using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor.MainForm
{
    public static class Helper
    {
        public static Label CreateLabel(Point location, string name, int tabIndex, string text)
        {
            var label = new Label
            {
                Text = text,
                //BorderStyle = BorderStyle.FixedSingle,
                Location = location,
                Name = name,
                TabIndex = tabIndex,
                AutoSize = true
            };

            return label;
        }

        public static ComboBox CreateComboBox(Point location, Size size, string name, int tabIndex, EventHandler eh)
        {
            var comboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FormattingEnabled = true,
                Location = location,
                Size = size,
                Name = name,
                TabIndex = tabIndex
            };
            if (eh != null) comboBox.SelectedIndexChanged += eh;

            return comboBox;
        }

        public static PictureBox CreatePictureBox(Point location, Size size, string name, PictureBoxSizeMode sizeMode,int tabIndex, EventHandler eh1, MouseEventHandler eh2, MouseEventHandler eh3)
        {
            var pictureBox = new PictureBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                //Dock = DockStyle.Fill,
                Location = location,
                Size = size,
                Name = name,
                SizeMode = sizeMode,
                TabIndex = tabIndex,
                TabStop = false
            };
            if (eh1 != null) pictureBox.Click += eh1;
            if (eh2 != null) pictureBox.MouseDown += eh2;
            if (eh3 != null) pictureBox.MouseUp += eh3;

            return pictureBox;
        }

        public static CheckBox CreateCheckbox(Point location, string name, int tabIndex, int tag, EventHandler eh)
        {
            var checkBox = new CheckBox
            {
                Location = location,
                Name = name,
                Checked = true,
                TabIndex = tabIndex,
                Tag = tag
            };
            if (eh != null) checkBox.CheckedChanged += eh;

            return checkBox;
        }

        public static RadioButton CreateRadioButton(Point location, string name, int tabIndex, string text, bool isChecked, int tag, EventHandler eh)
        {
            var radioButton = new RadioButton
            {
                Text = text,
                Location = location,
                Name = name,
                TabIndex = tabIndex,
                Checked = isChecked,
                Tag = tag
            };
            if (eh != null) radioButton.CheckedChanged += eh;

            return radioButton;
        }
    }
}