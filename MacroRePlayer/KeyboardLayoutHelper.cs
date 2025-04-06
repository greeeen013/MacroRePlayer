using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRePlayer
{
    internal class KeyboardLayoutHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern long GetKeyboardLayoutName(StringBuilder pwszKLID);

        public static string GetKeyboardLayoutText()
        {
            // Získáme název layoutu jako hex string (např. "00000405")
            StringBuilder layoutName = new StringBuilder(9);
            GetKeyboardLayoutName(layoutName);

            string keyPath = $@"SYSTEM\CurrentControlSet\Control\Keyboard Layouts\{layoutName}";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    object layoutText = key.GetValue("Layout Text");
                    if (layoutText != null)
                        return layoutText.ToString(); // Např. "Czech" nebo "US"
                }
            }

            return layoutName.ToString(); // fallback: hex kód
        }
    }
}
