using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRePlayer
{
    public static class EventDisplayHelper
    {
        
        internal static void DisplayEvents(List<IInputEvent> events)  // Můžeš použít i `Control`, pokud je to obecnější prvek
        {
            
            int yOffset = 0; // Počáteční pozice Y
            foreach (var inputEvent in events)
            {
                var panel = new Panel
                {
                    Size = new Size(420, 30), // Zvětšení šířky panelu kvůli labelům
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Location = new Point(0, yOffset) // Zarovnání doleva
                };

                var label = new Label
                {
                    Text = $"{inputEvent.Type}:",
                    AutoSize = false,
                    Size = new Size(80, 20),
                    Location = new Point(5, 5)
                };
                panel.Controls.Add(label);
                // Panel panel = new Panel(); // Vytvoříš nový Panel (nebo jiný Control)

                var dragLabel = new Label
                {
                    Text = "≡",
                    AutoSize = false,
                    Size = new Size(20, 20),
                    Location = new Point(400, 5), // Posunutí dragLabel kvůli větší šířce panelu
                    Cursor = Cursors.Hand // Změna kurzoru na ruku
                };

                // Přidání dragLabel do Panelu
                panel.Controls.Add(dragLabel);

                switch (inputEvent)
                {
                    case DelayEvent delayEvent:
                        EventDisplayFunctionCreater.AddTextBox(panel, "Delay:", delayEvent.Duration.ToString(), 90);
                        break;

                    case MouseDownEvent mouseDownEvent:
                        EventDisplayFunctionCreater.AddTextBox(panel, "X:", mouseDownEvent.X.ToString(), 90); // TextBox pro X
                        EventDisplayFunctionCreater.AddTextBox(panel, "Y:", mouseDownEvent.Y.ToString(), 170); // TextBox pro Y
                        EventDisplayFunctionCreater.AddComboBox(panel, "Button:", mouseDownEvent.Button, 250); // Dropdown pro tlačítko myši
                        break;

                    case MouseUpEvent mouseUpEvent:
                        EventDisplayFunctionCreater.AddTextBox(panel, "X:", mouseUpEvent.X.ToString(), 90); // TextBox pro X
                        EventDisplayFunctionCreater.AddTextBox(panel, "Y:", mouseUpEvent.Y.ToString(), 170); // TextBox pro Y
                        EventDisplayFunctionCreater.AddComboBox(panel, "Button:", mouseUpEvent.Button, 250); // Dropdown pro tlačítko myši
                        break;

                    case KeyDownEvent keyDownEvent:
                        EventDisplayFunctionCreater.AddTextBox(panel, "Key:", keyDownEvent.Key, 90); // TextBox pro klávesu
                        break;

                    case KeyUpEvent keyUpEvent:
                        EventDisplayFunctionCreater.AddTextBox(panel, "Key:", keyUpEvent.Key, 90); // TextBox pro klávesu
                        break;
                }

                // Povolení drag-and-drop pro dragLabel
                
                


                Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.GetEditorEventPanel().Controls.Add(panel);
                    
                }
                


                yOffset += 35; // Posunutí pozice Y pro další panel (30 výška panelu + 5 mezera)

            }
        }
    }
}
