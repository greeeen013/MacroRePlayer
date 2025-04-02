using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRePlayer
{
    public static class EventDisplayFunctionCreater
    {
        public static void AddTextBox(Panel panel, string labelText, string text, int x)
        {
            // Přidání labelu
            var label = new Label
            {
                Text = labelText,
                AutoSize = false,
                Size = new Size(37, 15), //37 kvůli slovu "Delay:"
                Location = new Point(x - 3, 6), // Posunutí labelu doleva
                TextAlign = ContentAlignment.MiddleRight
            };

            panel.Controls.Add(label);

            // Přidání textboxu
            var textBox = new System.Windows.Forms.TextBox
            {
                Text = text,
                Size = new Size(40, 20),
                Location = new Point(x + 35, 4) // Posunutí textboxu vedle labelu
            };

            panel.Controls.Add(textBox);
        }

        public static void AddComboBox(Panel panel, string labelText, string selectedButton, int x)
        {
            // Přidání labelu
            var label = new Label
            {
                Text = labelText,
                AutoSize = false,
                Size = new Size(42, 15), //42 kvůli slovu "Button:"
                Location = new Point(x + 13, 7), // Posunutí labelu doleva
            };

            panel.Controls.Add(label);

            // Přidání dropdown menu
            var comboBox = new System.Windows.Forms.ComboBox
            {
                Size = new Size(80, 20),
                Location = new Point(x + 55, 4), // Posunutí dropdown menu vedle labelu
                DropDownStyle = ComboBoxStyle.DropDownList // Zakázání editace
            };

            // Přidání možností do dropdown menu
            comboBox.Items.AddRange(new string[] { "Left", "Right", "Middle" });

            // Nastavení vybrané hodnoty
            comboBox.SelectedItem = selectedButton;

            panel.Controls.Add(comboBox);
        }
    }
}
