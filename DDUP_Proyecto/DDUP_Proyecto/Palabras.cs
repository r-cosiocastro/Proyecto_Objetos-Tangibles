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
    public partial class Palabras : MetroForm
    {
        private readonly string TAG = "Palabras.cs: ";
        Cereal sp2;
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

        List<Word> Words = new List<Word>();
        List<Word> PendingWords = new List<Word>();

        Word ExpectedWord;
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

            Word result = Words.Find(
            delegate (Word letra)
            {
                return letra.WordId == newData;
            }
            );

            if (result != null)
            {
                if (GameStarted)
                {
                    if (ExpectedWord == result)
                    {
                        CorrectDialog(ExpectedWord);
                        // TERMINAR JUEGO
                        if (PendingWords.Count <= 0)
                        {
                            metroProgressBar1.Value = MaxProgress - PendingWords.Count;
                            metroProgressSpinner1.Value = MaxProgress - PendingWords.Count;
                            EndGame(1);
                        }
                        else
                            NewColour();
                    }
                    else
                    {
                        ErrorSound.Play();
                        ErrorDialog(result, ExpectedWord);
                    }
                }
                else
                {

                    FoundDialog(result);
                    //LabelLetter.Text = "Color actual: " + result.ColorName;

                    UpdateUI(result.WordName);
                }
            }
            else
            {
                ErrorSound.Play();

                //LabelLetter.Text = "Color actual:";

            }
        }

        // Indicar que se colocó una letra errónea
        private void ErrorDialog(Word actualLetter, Word requested)
        {
            int dialog = rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    Speak("Coloca la palabra " + requested.WordPhonetic);
                    break;
                case 1:
                    //Speak("Busca la letra " + requiredLetter + ". " + nombre);
                    Speak(UserName + ", busca la palabra " + requested.WordPhonetic + ". ");
                    break;
                case 2:
                    //Speak("Esa no es la letra " + requiredLetter + ". " + nombre);
                    Speak(UserName + ", esa no es la palabra " + requested.WordPhonetic + ". ");
                    break;
                case 3:
                    Speak("Esa es la palabra " + actualLetter.WordPhonetic + ", necesitamos la palabra " + requested.WordPhonetic);
                    break;
            }
        }

        // Indicar la letra que se colocó (modo aprendizaje)
        private void FoundDialog(Word Palabra)
        {
            int dialog = rnd.Next(0, 3);
            string dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = "Ese es el color " + Palabra.WordPhonetic;
                    break;
                case 1:
                    dialogString = "Colocaste la palabra " + Palabra.WordPhonetic;
                    break;
                case 2:
                    dialogString = "Detecto la palabra " + Palabra.WordPhonetic;
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " como " + Palabra.GiveExample(rnd);

            Speak(dialogString);
        }

        // Indicar que se colocó la letra esperada
        private void CorrectDialog(Word Word)
        {
            FoundSound.Play();
            int dialog = rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    TTS.Speak("Correcto, " + UserName + ", esa es la palabra " + Word.WordPhonetic);
                    break;
                case 1:
                    TTS.Speak("Muy bien, " + UserName + ", esa es la palabra " + Word.WordPhonetic);
                    break;
                case 2:
                    TTS.Speak("Bien hecho, " + UserName + ", encontraste la palabra " + Word.WordPhonetic);
                    break;
                case 3:
                    TTS.Speak("Perfecto, encontraste la palabra " + Word.WordPhonetic);
                    break;
            }
        }

        public Palabras()
        {
            InitializeComponent();

            TTS.SetOutputToDefaultAudioDevice();

            // Letras, códigos RFID y combinaciones de las palabras
            Words.Add(new Word() { WordName = "Mamá", WordPhonetic = "Mamá", WordId = "80 48 08 A6", WordImage = Properties.Resources.Mama });
            Words.Add(new Word() { WordName = "Papá", WordPhonetic = "Papá", WordId = "93 79 82 24", WordImage = Properties.Resources.Papa });
            Words.Add(new Word() { WordName = "Hermano", WordPhonetic = "Hermano", WordId = "12 33 76 28", WordImage = Properties.Resources.Hermano });
            Words.Add(new Word() { WordName = "Hermana", WordPhonetic = "Hermana", WordId = "93 9F 84 40", WordImage = Properties.Resources.Hermana });
            Words.Add(new Word() { WordName = "Abuelo", WordPhonetic = "Abuelo", WordId = "80 D9 8E 32", WordImage = Properties.Resources.Abuelo });
            Words.Add(new Word() { WordName = "Abuela", WordPhonetic = "Abuela", WordId = "70 C4 40 32", WordImage = Properties.Resources.Abuela });
            Words.Add(new Word() { WordName = "Tío", WordPhonetic = "Tío", WordId = "45 71 E8 2B" });
            Words.Add(new Word() { WordName = "Tía", WordPhonetic = "Tía", WordId = "45 71 E8 2E" });
        }

        public Palabras(Cereal sp2, MetroThemeStyle theme)
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

            // Letras, códigos RFID y combinaciones de las palabras
            Words.Add(new Word() { WordName = "Mamá", WordPhonetic = "Mamá", WordId = "80 48 08 A6", WordImage = Properties.Resources.Mama});
            Words.Add(new Word() { WordName = "Papá", WordPhonetic = "Papá", WordId = "93 79 82 24", WordImage = Properties.Resources.Papa });
            Words.Add(new Word() { WordName = "Hermano", WordPhonetic = "Hermano", WordId = "12 33 76 28", WordImage = Properties.Resources.Hermano });
            Words.Add(new Word() { WordName = "Hermana", WordPhonetic = "Hermana", WordId = "93 9F 84 40", WordImage = Properties.Resources.Hermana });
            Words.Add(new Word() { WordName = "Abuelo", WordPhonetic = "Abuelo", WordId = "80 D9 8E 32", WordImage = Properties.Resources.Abuelo });
            Words.Add(new Word() { WordName = "Abuela", WordPhonetic = "Abuela", WordId = "70 C4 40 32", WordImage = Properties.Resources.Abuela });
            Words.Add(new Word() { WordName = "Tío", WordPhonetic = "Tío", WordId = "45 71 E8 2B"});
            Words.Add(new Word() { WordName = "Tía", WordPhonetic = "Tía", WordId = "45 71 E8 2E" });

        }

        private void StartGameTile_Click(object sender, EventArgs e)
        {
            //if (TextBoxName.Text.Trim().Length >= 3)
            //{
                EnterSound.Play();
                ChangeGameState();
            //}
            //else
                //MessageBox.Show(this, "Ingrese el nombre real del usuario en el apartado \"nombre\".", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    TTS.Speak("Felicidades " + UserName + ". Colocaste todas las palabras. Juego completado.");
                    break;
            }
            metroProgressSpinner1.Visible = false;
            //LabelLetter.Text = "Color actual: ";
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
            PendingWords.Clear();

            Console.WriteLine(Words.Count);

            foreach (Word c in Words)
            {
                Console.WriteLine(c.WordName);
            }

            

            foreach (Control control in PanelCheckBox.Controls)
            {
                // Return false if the control is a checkbox and it's not checked
                if ((control as CheckBox)?.Checked ?? false)
                    PendingWords.Add(Words.Find(
                        delegate (Word word)
                        {
                            return word.WordName == (control as CheckBox).Text;
                        }
                   ));
            }

            MaxProgress = PendingWords.Count;
            metroProgressBar1.Maximum = MaxProgress;
            metroProgressSpinner1.Maximum = MaxProgress;

            PendingWords.Shuffle();

            foreach (Word c in PendingWords)
            {
                Console.WriteLine(c.WordName);
            }

            //StartMainGame();
            //NewColour();
            
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

            ExpectedWord = PendingWords.First();

            metroProgressBar1.Value = MaxProgress - PendingWords.Count;
            metroProgressSpinner1.Value = MaxProgress - PendingWords.Count;

            PendingWords.RemoveAt(0);

            //LabelLetter.Text = "Color actual: " + ExpectedColor.ColorName;

            NewColourDialog(ExpectedWord);

            UpdateUI(ExpectedWord.WordName);
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            WriteSound.Play();
        }

        private void NewColourDialog(Word ExpectedWord)
        {
            int dialog = rnd.Next(0, 3);
            string dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = ("Coloca la palabra: " + ExpectedWord.WordPhonetic);
                    break;
                case 1:
                    dialogString = (UserName + ", busca la palabra: " + ExpectedWord.WordPhonetic + ".");
                    break;
                case 2:
                    dialogString = ("Necesitamos la palabra: " + ExpectedWord.WordPhonetic);
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " como el de " + ExpectedWord.GiveExample(rnd);
            Speak(dialogString);
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
            if (PendingWords.Count <= 0)
            {
                metroProgressBar1.Value = MaxProgress - PendingWords.Count;
                metroProgressSpinner1.Value = MaxProgress - PendingWords.Count;
                EndGame(0);
            }
            else
                NewColour();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            StartGame();
            Nivel1 br = new Nivel1(PendingWords);
            br.ShowDialog(this);
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            StartGame();
            Nivel2 br = new Nivel2(PendingWords);
            br.ShowDialog(this);
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            StartGame();
            Nivel3 br = new Nivel3(PendingWords);
            br.ShowDialog(this);
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            StartGame();
            Nivel4 br = new Nivel4(PendingWords);
            br.ShowDialog(this);
        }
    }

    public class Word : IEquatable<Colour>
    {
        public string WordName { get; set; }
        public string WordId { get; set; }
        public string[] WordExamples { get; set; }
        public string WordPhonetic { get; set; }
        public Image WordImage { get; set; }


        public override string ToString()
        {
            return "ID: " + WordId + "   Name: " + WordName + "     Phonetic: " + WordPhonetic;
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
            return (this.WordId.Equals(other.ColorId));
        }

        public string GiveExample(Random rnd) => WordExamples[rnd.Next(0, WordExamples.Length)];
    }
}

