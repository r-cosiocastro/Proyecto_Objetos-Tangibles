using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DDUP_Proyecto
{
    public partial class RegistroTarjetas : MetroForm
    {
        Cereal sp2;
        bool CellValueChanged = false;
        // event handler method
        void sp2_LineReceived(object sender, LineReceivedEventArgs Args)
        {
            Console.WriteLine(TAG + Args.LineData);

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(delegate () { metroLabel1.Text = Args.LineData; }));
            }
        }

        private readonly string TAG = "RegistroTarjetas.cs: ";
        public RegistroTarjetas(Cereal sp2, MetroThemeStyle theme)
        {
            this.sp2 = sp2;
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            this.metroStyleManager1.Theme = theme;
            this.sp2.LineReceived += new LineReceivedEventHandler(sp2_LineReceived);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistroTarjetas_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.sp2.LineReceived -= new LineReceivedEventHandler(sp2_LineReceived);
        }

        private void RegistroTarjetas_Load(object sender, EventArgs e)
        {
            //Fetch All Data
            ObjectDB database = new ObjectDB();
            IDataReader reader = database.getAllData();

            while (reader.Read())
            {
                ObjectEntity entity = new ObjectEntity(reader.GetString(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4));
                objectEntityBindingSource1.Add(entity);
            }
            database.close();
        }

        private void metroGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Console.WriteLine("CellValueChanged");
                CellValueChanged = true;
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

        }

        private void radio_Todos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                FiltrarResultados(0);
        }

        void FiltrarResultados(int filtro)
        {
            ObjectDB database = new ObjectDB();
            IDataReader reader = null;
            objectEntityBindingSource1.Clear();
            switch (filtro)
            {
                case 0:
                    Console.WriteLine("Mostrar todos");
                    reader = database.getAllData();
                    break;
                case 1:
                    Console.WriteLine("Mostrar basura");
                    reader = database.getDataByType("Basura");
                    break;
                case 2:
                    Console.WriteLine("Mostrar números");
                    reader = database.getDataByType("Numero");
                    break;
                case 3:
                    Console.WriteLine("Mostrar letras");
                    reader = database.getDataByType("Letra");
                    break;
            }
            while (reader.Read())
            {
                ObjectEntity entity = new ObjectEntity(reader.GetString(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4));
                objectEntityBindingSource1.Add(entity);
            }
            database.close();
        }

        private void radio_Basura_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                FiltrarResultados(1);
        }

        private void radio_Num_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                FiltrarResultados(2);
        }

        private void radio_Letras_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                FiltrarResultados(3);
        }

        private void metroGrid1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (CellValueChanged)
            {
                DialogResult dr = MessageBox.Show(this, "¿Desea aplicar los cambios a " + metroGrid1.CurrentRow.Cells[2].Value + "?", "Cambios pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ObjectDB objectDB = new ObjectDB();
                    ObjectEntity objectEntity = (ObjectEntity)metroGrid1.CurrentRow.DataBoundItem;
                    objectDB.addOrReplaceData(objectEntity);

                    CellValueChanged = false;

                    objectDB.close();
                }
                else
                {
                    CellValueChanged = false;
                    this.metroGrid1.CancelEdit();
                }
            }
        }
    }
}
