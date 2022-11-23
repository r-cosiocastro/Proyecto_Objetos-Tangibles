using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace DDUP_Proyecto
{
    public partial class Nivel2 : MetroForm
    {
        List<Word> PendingWords = new List<Word>();
        Word ExpectedWord;
        string LastInstruction = "";
        int WordCount;

        Random rnd = new Random();
        SpeechSynthesizer TTS = new SpeechSynthesizer();

        SoundPlayer ErrorSound = new SoundPlayer(Properties.Resources.Error);
        SoundPlayer FoundSound = new SoundPlayer(Properties.Resources.Dada_1);
        SoundPlayer WinSound = new SoundPlayer(Properties.Resources.Clap);
        SoundPlayer HomeSound = new SoundPlayer(Properties.Resources.Home);

        public Nivel2(List<Word> words)
        {
            InitializeComponent();
            if (words != null)
                Init(words);
        }

        void Init(List<Word> words)
        {
            TTS.SetOutputToDefaultAudioDevice();

            foreach (Word word in words)
            {
                PendingWords.Add(word);
            }
            WordCount = PendingWords.Count;
            metroProgressBar1.Maximum = WordCount;

            NewWord();
        }

        private void ValidarOpcion(object sender, EventArgs e)
        {
            // TODO:
            Console.WriteLine((sender as Button).Text);

            if ((sender as Button).Text == ExpectedWord.WordName)
            {
                CorrectDialog(ExpectedWord);
                NewWord();
            }
            else
            {
                ErrorDialog(ExpectedWord);
            }
        }

        void NewWord()
        {
            if (PendingWords.Count <= 0)
            {
                metroProgressBar1.Value = metroProgressBar1.Maximum;
                TTS.Speak("Felicidades. Colocaste todas las palabras. Juego completado.");
                //TTS.Speak("Felicidades. Repetiste todas las palabras. Juego completado.");
            }
            else
            {

                HomeSound.Play();

                ExpectedWord = PendingWords.First();

                metroProgressBar1.Value = WordCount - PendingWords.Count;

                PendingWords.RemoveAt(0);

                //LabelLetter.Text = "Color actual: " + ExpectedColor.ColorName;

                NewWordDialog();

                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            //pictureBox1.Image = ExpectedWord.WordImage;
            labelPalabra.Text = ExpectedWord.WordName;
        }

        private void ErrorDialog(Word requested)
        {
            ErrorSound.Play();
            int dialog = rnd.Next(0, 3);
            switch (dialog)
            {
                case 0:
                    Speak("Coloca la palabra " + requested.WordPhonetic);
                    break;
                case 1:
                    //Speak("Busca la letra " + requiredLetter + ". " + nombre);
                    Speak("Busca la palabra " + requested.WordPhonetic + ". ");
                    break;
                case 2:
                    //Speak("Esa no es la letra " + requiredLetter + ". " + nombre);
                    Speak("Esa no es la palabra " + requested.WordPhonetic + ". ");
                    break;
            }
        }

        private void CorrectDialog(Word Word)
        {
            FoundSound.Play();
            int dialog = rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    TTS.Speak("Correcto, esa es la palabra " + Word.WordPhonetic);
                    break;
                case 1:
                    TTS.Speak("Muy bien, esa es la palabra " + Word.WordPhonetic);
                    break;
                case 2:
                    TTS.Speak("Bien hecho, encontraste la palabra " + Word.WordPhonetic);
                    break;
                case 3:
                    TTS.Speak("Perfecto, encontraste la palabra " + Word.WordPhonetic);
                    break;
            }
        }

        private void NewWordDialog()
        {
            int dialog = rnd.Next(0, 3);
            string dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = ("Coloca la palabra: " + ExpectedWord.WordPhonetic);
                    break;
                case 1:
                    dialogString = ("Busca la palabra: " + ExpectedWord.WordPhonetic + ".");
                    break;
                case 2:
                    dialogString = ("Necesitamos la palabra: " + ExpectedWord.WordPhonetic);
                    break;
            }
            LastInstruction = dialogString;
            Speak(dialogString);
        }

        void Speak(string text)
        {
            if (TTS.State == SynthesizerState.Speaking)
                TTS.SpeakAsyncCancelAll();

            TTS.SpeakAsync(text);
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            NewWord();
        }

        private void btnRepetir_Click(object sender, EventArgs e)
        {
            Speak(LastInstruction);
        }

        private void btnCorrecto_Click(object sender, EventArgs e)
        {
            //Correct2Dialog(ExpectedWord);
            //NewWordDialog2();
        }
    }
}
