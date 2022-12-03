using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Linq;

namespace DDUP_Proyecto
{
    public partial class Colores : MetroForm
    {
        private readonly string TAG = "Braille.cs: ";
        PuertoSerial sp2;
        SpeechSynthesizer TTS = new SpeechSynthesizer();

        SoundPlayer ErrorSound = new SoundPlayer(Properties.Resources.Error);
        SoundPlayer FoundSound = new SoundPlayer(Properties.Resources.Dada_1);
        SoundPlayer WinSound = new SoundPlayer(Properties.Resources.Clap);
        SoundPlayer ClickSound = new SoundPlayer(Properties.Resources.Enter___Back);
        SoundPlayer EnterSound = new SoundPlayer(Properties.Resources.Popup___Run_Title);
        SoundPlayer WriteSound = new SoundPlayer(Properties.Resources.Select);
        SoundPlayer HomeSound = new SoundPlayer(Properties.Resources.Home);
        SoundPlayer NewsSound = new SoundPlayer(Properties.Resources.News);
        SoundPlayer BingSound = new SoundPlayer(Properties.Resources.Bing);
        SoundPlayer BorderSound = new SoundPlayer(Properties.Resources.Border);
        SoundPlayer DadaSound = new SoundPlayer(Properties.Resources.Dada_2);

        bool GameStarted = false;
        Image tilePlay = new Bitmap(Properties.Resources.icons8_circled_play_32__1_);
        Image tileStop = new Bitmap(Properties.Resources.icons8_stop_circled_32__1_);
        Random rnd = new Random();

        private class DefaultColors
        {
            public static Color Red = ColorTranslator.FromHtml("#d11141");
            public static Color Green = ColorTranslator.FromHtml("#00b159");
            public static  Color Blue = ColorTranslator.FromHtml("#00aedb");
            public static Color Yellow = ColorTranslator.FromHtml("#ffc425");
            public static Color Orange = ColorTranslator.FromHtml("#f37735");
            public static Color Violet = ColorTranslator.FromHtml("#7c4199");
            public static Color Turquoise = ColorTranslator.FromHtml("#00aaad");
        }

        List<Colour> Colors = new List<Colour>();
        List<Colour> PendingColors = new List<Colour>();

        Colour ExpectedColor;
        string UserName;
        int MaxProgress;

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
            if (data.Length < 11)
                return;

            string newData = data.Trim();
            if (data.Contains(";"))
            {
                newData = data.Substring(2, data.Length);
            }

            Colour result = Colors.Find(
            delegate (Colour letra)
            {
                return letra.ColorId == newData;
            }
            );

            if (result != null)
            {
                if (GameStarted)
                {
                    if (ExpectedColor == result)
                    {
                        CorrectDialog(ExpectedColor);
                        // TERMINAR JUEGO
                        if (PendingColors.Count <= 0)
                        {
                            metroProgressBar1.Value = MaxProgress - PendingColors.Count;
                            metroProgressSpinner1.Value = MaxProgress - PendingColors.Count;
                            EndGame(1);
                        }
                        else
                            NewColour();
                    }
                    else
                    {
                        ErrorSound.Play();
                        ErrorDialog(result, ExpectedColor);
                    }
                }
                else
                {

                    FoundDialog(result);
                    LabelLetter.Text = "Color actual: " + result.ColorName;

                    UpdateUI(result);
                }
            }
            else
            {
                ErrorSound.Play();

                LabelLetter.Text = "Color actual:";

            }
        }

        // Indicar que se colocó una letra errónea
        private void ErrorDialog(Colour actualLetter, Colour requested)
        {
            int dialog = rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    Speak("Coloca el color " + requested.ColorPhonetic);
                    break;
                case 1:
                    //Speak("Busca la letra " + requiredLetter + ". " + nombre);
                    Speak(UserName + ", busca el color " + requested.ColorPhonetic + ". ");
                    break;
                case 2:
                    //Speak("Esa no es la letra " + requiredLetter + ". " + nombre);
                    Speak(UserName + ", ese no es el color " + requested.ColorPhonetic + ". ");
                    break;
                case 3:
                    Speak("Ese es el color " + actualLetter.ColorPhonetic + ", necesitamos el color " + requested.ColorPhonetic);
                    break;
            }
        }

        // Indicar la letra que se colocó (modo aprendizaje)
        private void FoundDialog(Colour Color)
        {
            int dialog = rnd.Next(0, 3);
            string dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = "Ese es el color " + Color.ColorPhonetic;
                    break;
                case 1:
                    dialogString = "Colocaste el color " + Color.ColorPhonetic;
                    break;
                case 2:
                    dialogString = "Detecto el color " + Color.ColorPhonetic;
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " como " + Color.GiveExample(rnd);

            Speak(dialogString);
        }

        // Indicar que se colocó la letra esperada
        private void CorrectDialog(Colour Color)
        {
            FoundSound.Play();
            int dialog = rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    TTS.Speak("Correcto, " + UserName + ", ese es el color " + Color.ColorPhonetic);
                    break;
                case 1:
                    TTS.Speak("Muy bien, " + UserName + ", ese es el color " + Color.ColorPhonetic);
                    break;
                case 2:
                    TTS.Speak("Bien hecho, " + UserName + ", encontraste el color " + Color.ColorPhonetic);
                    break;
                case 3:
                    TTS.Speak("Perfecto, encontraste el color " + Color.ColorPhonetic);
                    break;
            }
        }

        public Colores()
        {
            InitializeComponent();
        }

        public Colores(PuertoSerial sp2, MetroThemeStyle theme)
        {
            InitializeComponent();
            CheckBoxExample.ResetText();
            HomeSound.Play();
            this.StyleManager = metroStyleManager1;
            this.metroStyleManager1.Theme = theme;

            this.sp2 = sp2;
            if (sp2 != null)
            {
                if (sp2.IsOpen())
                    sp2.WriteLine("1");

                this.sp2.LineReceived += new LineReceivedEventHandler(sp2_LineReceived);
            }



            TTS.SetOutputToDefaultAudioDevice();

            // Letras, códigos RFID y combinaciones de los puntos de Braille
            Colors.Add(new Colour() { ColorName = "Rojo", ColorPhonetic = "Rojo", ColorId = "80 48 08 A6", ColorColor = DefaultColors.Red, ColorExample = new string[] { "una manzana", "una fresa", "un corazón" } });
            Colors.Add(new Colour() { ColorName = "Verde", ColorPhonetic = "Verde", ColorId = "93 79 82 24", ColorColor = DefaultColors.Green, ColorExample = new string[] { "una rana", "un árbol", "un aguacate" } });
            Colors.Add(new Colour() { ColorName = "Azul", ColorPhonetic = "Azul", ColorId = "12 33 76 28", ColorColor = DefaultColors.Blue, ColorExample = new string[] { "el mar", "el cielo", "los pitufos" } });
            Colors.Add(new Colour() { ColorName = "Amarillo", ColorPhonetic = "Amarillo", ColorId = "93 9F 84 40", ColorColor = DefaultColors.Yellow, ColorExample = new string[] { "un plátano", "la miel de abeja", "el oro" } });
            Colors.Add(new Colour() { ColorName = "Naranja", ColorPhonetic = "Naranja", ColorId = "80 D9 8E 32", ColorColor = DefaultColors.Orange, ColorExample = new string[] { "una naranja", "una pelota de basquetball", "una calabaza" } });
            Colors.Add(new Colour() { ColorName = "Violeta", ColorPhonetic = "Violeta", ColorId = "70 C4 40 32", ColorColor = DefaultColors.Violet, ColorExample = new string[] { "una uva" } });
            Colors.Add(new Colour() { ColorName = "Turquesa", ColorPhonetic = "Turquesa", ColorId = "45 71 E8 2B", ColorColor = DefaultColors.Turquoise, ColorExample = new string[] { "una nieve de chicle" } });


        }

        private void StartGameTile_Click(object sender, EventArgs e)
        {
            if (TextBoxName.Text.Trim().Length >= 3)
            {
                EnterSound.Play();
                ChangeGameState();
            }
            else
                MessageBox.Show(this, "Ingrese el nombre real del usuario en el apartado \"nombre\".", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        void EndGame(int razon)
        {
            switch (razon)
            {
                case 0:
                    TTS.Speak("Terminando juego");
                    metroProgressBar1.Value = 0;
                    
                    break;

                case 1:
                    WinSound.Play();
                    TTS.Speak("Felicidades " + UserName + ". Colocaste todos los colores. Juego completado.");
                    break;
            }
            metroProgressSpinner1.Visible = false;
            UpdateStyle(MetroColorStyle.Black);
            panel1.BackColor = Color.Transparent;
            LabelLetter.Text = "Color actual: ";
            TileStartStopGame.TileImage = tilePlay;
            TileStartStopGame.Text = "COMENZAR JUEGO";
            TileSkipColor.Visible = false;
            TextBoxName.Enabled = true;
            GameStarted = false;
            metroProgressSpinner1.Spinning = false;

            LockCheckboxes(false);
        }

        void LockCheckboxes(bool locked)
        {
            foreach (Control control in PanelCheckBox.Controls)
            {
                if (control.GetType().Name == "CheckBox")
                    control.Enabled = !locked;
            }
        }

        void StartGame()
        {
            TTS.Speak("Comenzando juego. ");
            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Spinning = true;
            //PendingColors = new List<Colour> (Colors);
            PendingColors.Clear();

            foreach (Control control in PanelCheckBox.Controls)
            {
                // Return false if the control is a checkbox and it's not checked
                if ((control as CheckBox)?.Checked ?? false)
                    PendingColors.Add(Colors.Find(
                        delegate (Colour color)
                        {
                            return color.ColorName == (control as CheckBox).Text;
                        }
                   ));
            }

            MaxProgress = PendingColors.Count;
            metroProgressBar1.Maximum = MaxProgress;
            metroProgressSpinner1.Maximum = MaxProgress;

            PendingColors.Shuffle();

            foreach (Colour c in PendingColors)
            {
                Console.WriteLine(c.ColorName);
            }

            StartMainGame();
            NewColour();
        }



        void StartMainGame()
        {
            LockCheckboxes(true);
            TileStartStopGame.TileImage = tileStop;
            TileStartStopGame.Text = "TERMINAR JUEGO";
            TileSkipColor.Visible = true;

            UserName = TextBoxName.Text;
            TextBoxName.Enabled = false;
        }

        void ChangeGameState()
        {
            GameStarted = !GameStarted;
            if (GameStarted)
            {
                StartGame();
            }
            else
            {
                EndGame(0);
            }
        }

        void NewColour()
        {
            HomeSound.Play();

            ExpectedColor = PendingColors.First();

            metroProgressBar1.Value = MaxProgress - PendingColors.Count;
            metroProgressSpinner1.Value = MaxProgress - PendingColors.Count;

            PendingColors.RemoveAt(0);

            LabelLetter.Text = "Color actual: " + ExpectedColor.ColorName;

            NewColourDialog(ExpectedColor);

            UpdateUI(ExpectedColor);
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            WriteSound.Play();
        }

        private void NewColourDialog(Colour ExpectedColor)
        {
            int dialog = rnd.Next(0, 3);
            string dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = ("Coloca el color: " + ExpectedColor.ColorPhonetic);
                    break;
                case 1:
                    dialogString = (UserName + ", busca el color: " + ExpectedColor.ColorPhonetic + ".");
                    break;
                case 2:
                    dialogString = ("Necesitamos el color: " + ExpectedColor.ColorPhonetic);
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " como el de " + ExpectedColor.GiveExample(rnd);
            Speak(dialogString);
        }

        void UpdateUI(Colour color)
        {
            panel1.BackColor = color.ColorColor;

            Color c = color.ColorColor;

            if (c == DefaultColors.Red)
                UpdateStyle(MetroColorStyle.Red);
            else if (c == DefaultColors.Green)
                UpdateStyle(MetroColorStyle.Green);
            else if (c == DefaultColors.Blue)
                UpdateStyle(MetroColorStyle.Blue);
            else if (c == DefaultColors.Yellow)
                UpdateStyle(MetroColorStyle.Yellow);
            else if (c == DefaultColors.Orange)
                UpdateStyle(MetroColorStyle.Orange);
            else if (c == DefaultColors.Violet)
                UpdateStyle(MetroColorStyle.Purple);
            else if (c == DefaultColors.Turquoise)
                UpdateStyle(MetroColorStyle.Teal);
        }

        void UpdateStyle(MetroColorStyle style)
        {
            metroStyleManager1.Style = style;
            metroStyleManager1.Update();
        }

        void Speak(string text)
        {
            if (TTS.State == SynthesizerState.Speaking)
                TTS.SpeakAsyncCancelAll();

            TTS.SpeakAsync(text);

            subtitulo.Text = "Transcripción: " + text;
        }

        private void Braille_FormClosing(object sender, FormClosingEventArgs e)
        {
            ErrorSound.Dispose();
        }

        private void metroCheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            ClickSound.Play();
        }

        private void CheckBoxExample_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxExample.Checked)
            {
                ExamplesStatus.Text = "Sí";
                BingSound.Play();
            }
            else
            {
                BorderSound.Play();
                ExamplesStatus.Text = "No";
            }
        }

        private void TileSkipLetter_Click(object sender, EventArgs e)
        {
            
            NewsSound.Play();
            if (PendingColors.Count <= 0)
            {
                metroProgressBar1.Value = MaxProgress - PendingColors.Count;
                metroProgressSpinner1.Value = MaxProgress - PendingColors.Count;
                EndGame(0);
            }
            else
                NewColour();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    static class MyExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class Colour : IEquatable<Colour>
    {
        public string ColorName { get; set; }
        public string ColorId { get; set; }
        public string[] ColorExample { get; set; }
        public string ColorPhonetic { get; set; }
        public Color ColorColor { get; set; }


        public override string ToString()
        {
            return "ID: " + ColorId + "   Name: " + ColorName + "     Phonetic: " + ColorPhonetic;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Colour objAsPart = obj as Colour;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public bool Equals(Colour other)
        {
            if (other == null) return false;
            return (this.ColorId.Equals(other.ColorId));
        }

        public string GiveExample(Random rnd) => ColorExample[rnd.Next(0, ColorExample.Length)];
    }
}

