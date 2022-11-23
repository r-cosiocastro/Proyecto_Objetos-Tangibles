using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Windows.Forms;

namespace DDUP_Proyecto
{
    public partial class Conexion : MetroForm
    {

        Cereal sp1 = new Cereal(); // like this command passed LineReceivedEvent or LineReceived

        // event handler method
        void sp1_LineReceived(object sender, LineReceivedEventArgs Args)
        {
            //do things with line
            Console.WriteLine(TAG + Args.LineData);
        }

        private readonly string TAG = "Conexion.cs: ";

        public Conexion()
        {
            InitializeComponent();

            themeSelector.SelectedIndex = 0;
            //SerialHelper.SerialPort.DataReceived += SerialPort_DataReceived;
            sp1.LineReceived += new LineReceivedEventHandler(sp1_LineReceived);

            //Fetch All Data
            ObjectDB objectDB2 = new ObjectDB();
            IDataReader reader = objectDB2.getAllData();

            int fieldCount = reader.FieldCount;
            List<ObjectEntity> myList = new List<ObjectEntity>();
            while (reader.Read())
            {
                ObjectEntity entity = new ObjectEntity(reader.GetString(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4));

                Console.WriteLine("id: " + entity.ID + ", type: " + entity.Tipo + ", name: " + entity.Nombre + ", description: " + entity.Descripcion + ", typeID: " + entity.TipoID);
                myList.Add(entity);

            }
        }

        private void Conexion_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            updateCOMPorts();
            metroToolTip1.ShowAlways = true;
            metroToolTip1.SetToolTip(tileBiblioteca, "  Conecta el dispositivo en la aplicación para acceder a la biblioteca.  ");
        }

        private void updateCOMPorts()
        {
            var ports = SerialPort.GetPortNames();
            metroComboBox1.DataSource = ports;

            btnConectar.Enabled = ports.Length > 0;
        }

        private void initCOMSerial()
        {
            if (!sp1.IsOpen())
            {
                try
                {
                    sp1.Open(metroComboBox1.SelectedItem.ToString(), 115200);
                    sp1.WriteLine("0");
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this, "No se pudo realizar la conexión, reinserte el dispositivo y vuelva a intentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                sp1.WriteLine("0");
                sp1.Close();
            }

            lblStatus.Style = sp1.IsOpen() ? MetroColorStyle.Green : MetroColorStyle.Red;
            lblStatus.Text = sp1.IsOpen() ? "Conectado" : "Desconectado";
            btnConectar.Text = sp1.IsOpen() ? "Desconectar" : "Conectar";
            tileBiblioteca.Enabled = sp1.IsOpen();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateCOMPorts();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            initCOMSerial();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {

            Braille br = new Braille(sp1, metroStyleManager1.Theme);
            br.ShowDialog(this);
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            RegistroTarjetas rt = new RegistroTarjetas(sp1, metroStyleManager1.Theme);
            rt.ShowDialog(this);
        }

        private void Conexion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sp1.IsOpen())
                sp1.WriteLine("0");
            sp1.Close();

            sp1.Dispose();
            this.Dispose();
            Application.Exit();
        }

        private void themeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (themeSelector.SelectedIndex == 0)
            {
                metroStyleManager1.Theme = MetroThemeStyle.Light;
            }
            else if (themeSelector.SelectedIndex == 1)
            {
                metroStyleManager1.Theme = MetroThemeStyle.Dark;
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (sp1.IsOpen())
            {
                Biblioteca2 bb = new Biblioteca2(sp1, metroStyleManager1.Theme);
                bb.ShowDialog(this);
            }
            else
            {
                MetroMessageBox.Show(this, "\n\nPara acceder a esta sección se necesita conectar al dispositivo.", "Necesita conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            Colores br = new Colores(sp1, metroStyleManager1.Theme);
            br.ShowDialog(this);
        }
    }
}
