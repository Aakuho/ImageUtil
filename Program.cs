using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageUtil
{
    static class Program
    {
        // Register new formats here, only if they are supported by the Image library
        public static List<String> formats = new List<String>
        {
            "jpg",
            "png",
            "bmp",
            "tga"
        };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }
    }
}
