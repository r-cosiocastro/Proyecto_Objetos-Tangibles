using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace DDUP_Proyecto
{
    public partial class Biblioteca2 : MetroForm
    {
        Cereal sp2;
        SpeechSynthesizer tts = new SpeechSynthesizer();
        SoundPlayer errorSound;
        SoundPlayer foundSound;

        void sp2_LineReceived(object sender, LineReceivedEventArgs Args)
        {
            Console.WriteLine(TAG + Args.LineData);

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(delegate () { UpdateUI(Args.LineData); }));
            }
        }

        void UpdateUI(string data)
        {
            ObjectDB database = new ObjectDB();
            string newData = data.Trim();
            if (data.Contains(";"))
            {
                newData = data.Substring(2, data.Length);
            }
            IDataReader reader = database.getDataByString(newData);
            bool found = false;

            while (reader.Read())
            {
                found = true;
                ObjectEntity entity = new ObjectEntity(reader.GetString(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4));

                Console.WriteLine("id: " + entity.ID + ", type: " + entity.Tipo + ", name: " + entity.Nombre + ", description: " + entity.Descripcion + ", typeID: " + entity.TipoID);

                lblTitle.Text = entity.Nombre;
                lblDescription.Text = entity.Descripcion;

                string toSpeak = entity.Nombre + ". " + entity.Descripcion;

                Speak(toSpeak);

                Image picture = Image.FromFile(@"Assets\Images\noimage.jpg");

                if (File.Exists(@"Assets\Images\" + entity.ID + ".png"))
                {
                    picture = Image.FromFile(@"Assets\Images\" + entity.ID + ".png");
                }
                else if (File.Exists(@"Assets\Images\" + entity.ID + ".jpg"))
                {
                    picture = Image.FromFile(@"Assets\Images\" + entity.ID + ".jpg");
                }
                else if (File.Exists(@"Assets\Images\" + entity.ID + ".jpeg"))
                {
                    picture = Image.FromFile(@"Assets\Images\" + entity.ID + ".jpeg");
                }
                else if (File.Exists(@"Assets\Images\" + entity.ID + ".bmp"))
                {
                    picture = Image.FromFile(@"Assets\Images\" + entity.ID + ".bmp");
                }

                pictureBox1.Image = picture;
            }
            database.close();

            if (found)
            {
                // SystemSounds.Question.Play();

                foundSound.Play();
            }
            else
            {
                // SystemSounds.Hand.Play();

                errorSound.Play();
            }
        }

        private readonly string TAG = "Biblioteca2.cs: ";

        void Speak(string text)
        {
            if (readToggle.Checked)
            {
                if (tts.State == SynthesizerState.Speaking)
                    tts.SpeakAsyncCancelAll();

                tts.SpeakAsync(text);
            }
            else
            {
                return;
            }

        }


        public Biblioteca2(Cereal sp2, MetroThemeStyle theme)
        {
            this.sp2 = sp2;
            InitializeComponent();
            tabDescripcion.Select();
            this.StyleManager = metroStyleManager1;
            this.metroStyleManager1.Theme = theme;
            if (sp2 != null)
            {
                if (sp2.IsOpen())
                    sp2.WriteLine("1");

                this.sp2.LineReceived += new LineReceivedEventHandler(sp2_LineReceived);
            }

            errorSound = new SoundPlayer(Properties.Resources.Error);
            foundSound = new SoundPlayer(Properties.Resources.Found);

            tts.SetOutputToDefaultAudioDevice();
        }

        public Biblioteca2()
        {
            InitializeComponent();
        }

        private void Biblioteca2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.sp2.LineReceived -= new LineReceivedEventHandler(sp2_LineReceived);
            if (tts.State == SynthesizerState.Speaking)
                tts.SpeakAsyncCancelAll();

            tts.Dispose();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void readToggle_CheckedChanged(object sender, EventArgs e)
        {
            MetroToggle toggle = (MetroToggle)sender;
            if (toggle.Checked)
            {
                Speak(lblTitle.Text + ". " + lblDescription.Text);
            }
            else
            {
                if (tts.State == SynthesizerState.Speaking)
                    tts.SpeakAsyncCancelAll();
            }
        }
    }
}
