using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DDUP_Proyecto
{
    public partial class Biblioteca : MetroForm
    {
        private String connectionString;
        private SQLiteConnection connection;
        private const String query = "SELECT * FROM registros WHERE uid = ?";

        public Biblioteca()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);

            search();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        private void search()
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = query;

            command.Parameters.AddWithValue("uid", "20020");

            // Creamos un nuevo DataTable y un DataAdapter a partir de la SELECT.
            // A continuación, rellenamos la tabla con el DataAdapter
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("Se encontraron valores");
                DataRow dataRow = dt.Rows[0];
                String uid = dataRow[0].ToString();
                lblName.Text = dataRow[1].ToString();
                lblDesc.Text = dataRow[2].ToString();

                Image picture = Image.FromFile(@"Assets\Images\" + uid + ".png");

                if (picture == null)
                {
                    picture = Image.FromFile(@"Assets\Images\" + uid + ".jpg");

                    if (picture == null)
                    {
                        picture = Image.FromFile(@"Assets\Images\" + uid + ".jpeg");
                        if (picture == null)
                        {
                            picture = Image.FromFile(@"Assets\Images\noimage.jpg");
                        }
                    }
                }
                pictureBox1.Image = picture;
            }
            else
            {
                Console.WriteLine("No se encontraron valores");
            }

            StringBuilder output = new StringBuilder();
            foreach (DataRow rows in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    output.AppendFormat("{0} ", rows[col]);
                }

                output.AppendLine();
            }

            Console.WriteLine(output);

            connection.Close();
        }
    }
}
