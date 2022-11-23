using System;
using System.Windows.Forms;

namespace DDUP_Proyecto
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Biblioteca2());

            /* */
            var main_form = new Conexion();
            main_form.Show();
            Application.Run();
            /**/
        }
    }
}
