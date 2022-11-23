using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace DDUP_Proyecto
{
    /// <summary>
    ///  Esta clase se encarga de crear la ventana para la configuración y uso de la aplicación de Braille
    /// </summary>
    public partial class Braille : MetroForm
    {
        private readonly string TAG = "Braille.cs: ";

        #region Inicialización y constructores

        // Inicializar variables

        Cereal sp2;
        SpeechSynthesizer TTS = new SpeechSynthesizer();

        Random rnd = new Random();
        GameMode SelectedMode = GameMode.Alphabet;

        List<Letter> Letters = new List<Letter>();
        Letter[] TempArray = new Letter[30];
        Letter ExpectedLetter;
        List<Letter> PendingLetters = new List<Letter>();

        bool GameStarted = false;
        string UserName;

        // Sonidos

        SoundPlayer ErrorSound = new SoundPlayer(Properties.Resources.Error);
        SoundPlayer FoundSound = new SoundPlayer(Properties.Resources.Dada_1);
        SoundPlayer WinSound = new SoundPlayer(Properties.Resources.Clap);
        SoundPlayer ClickSound = new SoundPlayer(Properties.Resources.Enter___Back);
        SoundPlayer EnterSound = new SoundPlayer(Properties.Resources.Popup___Run_Title);
        SoundPlayer HomeSound = new SoundPlayer(Properties.Resources.Home);
        SoundPlayer NewsSound = new SoundPlayer(Properties.Resources.News);
        SoundPlayer BingSound = new SoundPlayer(Properties.Resources.Bing);
        SoundPlayer BorderSound = new SoundPlayer(Properties.Resources.Border);
        SoundPlayer DadaSound = new SoundPlayer(Properties.Resources.Dada_2);

        // Iconos

        Image tilePlay = new Bitmap(Properties.Resources.icons8_circled_play_32__1_);
        Image tileStop = new Bitmap(Properties.Resources.icons8_stop_circled_32__1_);

        enum GameMode
        {
            Alphabet,
            Vowels
        }

        public Braille()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El constructor Braille(sp2, theme) se encarga de crear la ventana de Braille.
        /// </summary>
        /// <param name="sp2">Objeto para continuar la comunicación Serial con el tablero establecida en la ventana principal.</param>
        /// <param name="theme">Tema elegido por el usuario en la ventana principal.</param>
        public Braille(Cereal sp2, MetroThemeStyle theme)
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            this.metroStyleManager1.Theme = theme;

            if (metroStyleManager1.Theme == MetroThemeStyle.Dark)
            {
                braille1.Image = new Bitmap(Properties.Resources.icons8_círculo_80_I);
                braille2.Image = new Bitmap(Properties.Resources.icons8_círculo_80_I);
                braille3.Image = new Bitmap(Properties.Resources.icons8_círculo_80_I);
                braille4.Image = new Bitmap(Properties.Resources.icons8_círculo_80_I);
                braille5.Image = new Bitmap(Properties.Resources.icons8_círculo_80_I);
                braille6.Image = new Bitmap(Properties.Resources.icons8_círculo_80_I);
            }

            this.sp2 = sp2;
            if (sp2 != null)
            {
                if (sp2.IsOpen())
                    sp2.WriteLine("1");

                this.sp2.LineReceived += new LineReceivedEventHandler(sp2_LineReceived);
            }

            TTS.SetOutputToDefaultAudioDevice();



            // Letras, códigos RFID y combinaciones de los puntos de Braille
            Letters.Add(new Letter() { LetterName = 'A', LetterPhonetic = "A", LetterId = "70 82 DD 32", BrailleEsp = "1", LetterExample = new string[] { "Árbol", "Ardilla", "Agua" } });
            Letters.Add(new Letter() { LetterName = 'B', LetterPhonetic = "B", LetterId = "A3 E9 01 40", BrailleEsp = "12", LetterExample = new string[] { "Barco", "Burro", "Brazo" } });
            Letters.Add(new Letter() { LetterName = 'C', LetterPhonetic = "C", LetterId = "45 5B 4D 2A", BrailleEsp = "14", LetterExample = new string[] { "Casa", "Comida", "Caballo" } });
            Letters.Add(new Letter() { LetterName = 'D', LetterPhonetic = "Dé", LetterId = "80 8D 3F 32", BrailleEsp = "145", LetterExample = new string[] { "Dedo", "Delfín", "Diente" } });
            Letters.Add(new Letter() { LetterName = 'E', LetterPhonetic = "E", LetterId = "80 3F 7E 32", BrailleEsp = "15", LetterExample = new string[] { "Estatua", "Elote", "Elefante" } });
            Letters.Add(new Letter() { LetterName = 'F', LetterPhonetic = "Efe", LetterId = "90 1F 2E 32", BrailleEsp = "124", LetterExample = new string[] { "Foca", "Fresa", "Frijol" } });
            Letters.Add(new Letter() { LetterName = 'G', LetterPhonetic = "Ge", LetterId = "93 9A D8 40", BrailleEsp = "1245", LetterExample = new string[] { "Guante", "Gato", "Gelatina" } });
            Letters.Add(new Letter() { LetterName = 'H', LetterPhonetic = "Ache", LetterId = "70 EB 4E 32", BrailleEsp = "125", LetterExample = new string[] { "Huevo", "Helado", "Hongo" } });
            Letters.Add(new Letter() { LetterName = 'I', LetterPhonetic = "I", LetterId = "90 3B B3 32", BrailleEsp = "24", LetterExample = new string[] { "Iglesia", "Iguana", "Isla" } });
            Letters.Add(new Letter() { LetterName = 'J', LetterPhonetic = "Jota", LetterId = "90 F9 5D 32", BrailleEsp = "245", LetterExample = new string[] { "Jeringa", "Jamón", "Jardín" } });
            Letters.Add(new Letter() { LetterName = 'K', LetterPhonetic = "Ca", LetterId = "C7 7F 37 19", BrailleEsp = "13", LetterExample = new string[] { "Kilo", "Koala", "Kiwi" } });
            Letters.Add(new Letter() { LetterName = 'L', LetterPhonetic = "L", LetterId = "70 86 15 32", BrailleEsp = "123", LetterExample = new string[] { "León", "Lagartija", "Lápiz" } });
            Letters.Add(new Letter() { LetterName = 'M', LetterPhonetic = "M", LetterId = "F4 5A 3B 2A", BrailleEsp = "134", LetterExample = new string[] { "Mundo", "Mariposa", "Mano" } });
            Letters.Add(new Letter() { LetterName = 'N', LetterPhonetic = "N", LetterId = "B7 17 C5 3B", BrailleEsp = "1345", LetterExample = new string[] { "Nariz", "Niño", "Nopal" } });
            Letters.Add(new Letter() { LetterName = 'O', LetterPhonetic = "O", LetterId = "04 6B D6 2B", BrailleEsp = "135", LetterExample = new string[] { "Ojo", "Oso", "Oreja" } });
            Letters.Add(new Letter() { LetterName = 'P', LetterPhonetic = "Pé", LetterId = "F4 CC 26 2A", BrailleEsp = "1234", LetterExample = new string[] { "Paleta", "Plato", "Pescado" } });
            Letters.Add(new Letter() { LetterName = 'Q', LetterPhonetic = "Cú", LetterId = "04 56 53 2B", BrailleEsp = "12345", LetterExample = new string[] { "Queso", "Quesadilla", "Química" } });
            Letters.Add(new Letter() { LetterName = 'R', LetterPhonetic = "Erre", LetterId = "B3 08 1B 40", BrailleEsp = "1235", LetterExample = new string[] { "Ratón", "Rama", "Rueda" } });
            Letters.Add(new Letter() { LetterName = 'S', LetterPhonetic = "Ese", LetterId = "04 8A 86 2B", BrailleEsp = "234", LetterExample = new string[] { "Sartén", "Serpiente", "Sopa" } });
            Letters.Add(new Letter() { LetterName = 'T', LetterPhonetic = "Té", LetterId = "04 2B 3E 2B", BrailleEsp = "2345", LetterExample = new string[] { "Taza", "Taco", "Tortuga" } });
            Letters.Add(new Letter() { LetterName = 'U', LetterPhonetic = "U", LetterId = "90 FB A0 32", BrailleEsp = "136", LetterExample = new string[] { "Uva", "Uña", "Unicornio" } });
            Letters.Add(new Letter() { LetterName = 'V', LetterPhonetic = "Uvé", LetterId = "04 0E 23 2B", BrailleEsp = "1236", LetterExample = new string[] { "Vaca", "Vuelta", "Vacío" } });
            Letters.Add(new Letter() { LetterName = 'W', LetterPhonetic = "DobleÚ", LetterId = "35 6E 84 2A", BrailleEsp = "2456", LetterExample = new string[] { "Whiskey", "Wi-Fi", "Waffle" } });
            Letters.Add(new Letter() { LetterName = 'X', LetterPhonetic = "Equis", LetterId = "04 B6 48 2B", BrailleEsp = "1346", LetterExample = new string[] { "Xilófono" } });
            Letters.Add(new Letter() { LetterName = 'Y', LetterPhonetic = "I griega", LetterId = "04 A7 77 2B", BrailleEsp = "13456", LetterExample = new string[] { "Yo-yó", "Yegua", "Yogurt" } });
            Letters.Add(new Letter() { LetterName = 'Z', LetterPhonetic = "Zeta", LetterId = "F4 6F 96 2A", BrailleEsp = "1356", LetterExample = new string[] { "Zanahoria", "Zapato", "Zoológico" } });
            Letters.Add(new Letter() { LetterName = 'M', LetterPhonetic = "Mario", LetterId = "71 CB 17 EC", BrailleEsp = "123456", LetterExample = new string[] { "Zanahoria", "Zapato", "Zoológico" } });


            Letters.CopyTo(TempArray);

            ComboBoxRangeA.Items.Clear();
            ComboBoxRangeB.Items.Clear();

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                Console.WriteLine(letter);
                ComboBoxRangeA.Items.Add(letter);
                ComboBoxRangeB.Items.Add(letter);
            }

            ComboBoxRangeA.SelectedIndex = 0;
            ComboBoxRangeB.SelectedIndex = ComboBoxRangeB.Items.Count - 1;

        }

        #endregion

        #region Dialogos

        /// <summary>
        /// El método ErrorDialog crea un diálogo de error aleatorio para hacerle saber al usuario que se ingresó una letra incorrecta. (Solo en el modo juego).
        /// </summary>
        /// <param name="actualLetter">La letra que el usuario ingresó en el tablero.</param>
        /// <param name="requested">La letra que se le pidió al usuario que ingresara.</param>
        private void ErrorDialog(Letter actualLetter, Letter requested)
        {
            int dialog = rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    Speak("Coloca la letra " + requested.LetterPhonetic);
                    break;
                case 1:
                    Speak(UserName + ", busca la letra " + requested.LetterPhonetic + ". ");
                    break;
                case 2:
                    Speak(UserName + ", esa no es la letra " + requested.LetterPhonetic + ". ");
                    break;
                case 3:
                    Speak("Esa es la letra " + actualLetter.LetterPhonetic + ", necesitamos la letra " + requested.LetterPhonetic);
                    break;
            }
        }

        /// <summary>
        /// El método FoundDialog crea un diálogo aleatorio para decirle al usuario qué letra es la que colocó en el tablero.
        /// </summary>
        /// <param name="letter">La letra que el usuario ingresó en el tablero.</param>
        private void FoundDialog(Letter letter)
        {
            int dialog = rnd.Next(0, 3);
            string dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = "Esa es la letra " + letter.LetterPhonetic;
                    break;
                case 1:
                    dialogString = "Colocaste la letra " + letter.LetterPhonetic;
                    break;
                case 2:
                    dialogString = "Detecto la letra " + letter.LetterPhonetic;
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " de " + letter.GiveExample(rnd);

            Speak(dialogString);
        }

        /// <summary>
        /// El método CorrectDialog crea un diálogo aleatorio para felicitar al usuario después de ingresar la letra que se le pidió. (Solo en el modo juego).
        /// </summary>
        /// <param name="letter">La letra que el usuario ingresó en el tablero.</param>
        private void CorrectDialog(Letter letter)
        {
            FoundSound.Play();
            int dialog = rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    TTS.Speak("Correcto, " + UserName + ", esa es la letra " + letter.LetterPhonetic);
                    break;
                case 1:
                    TTS.Speak("Muy bien, " + UserName + ", esa es la letra " + letter.LetterPhonetic);
                    break;
                case 2:
                    TTS.Speak("Bien hecho, " + UserName + ", encontraste la letra " + letter.LetterPhonetic);
                    break;
                case 3:
                    TTS.Speak("Perfecto, encontraste la letra " + letter.LetterPhonetic);
                    break;
            }
        }

        /// <summary>
        /// El método EndGame termina el juego en curso determinando una razón del termino del juego ya sea por el tutor o porque se acabaron las letras en el minijuego.
        /// </summary>
        /// <param name="razon">Razón por la cual se terminó el juego.</param>
        void EndGame(int razon)
        {
            switch (razon)
            {
                case 0:
                    TTS.Speak("Terminando juego");
                    break;

                case 1:
                    WinSound.Play();
                    TTS.Speak("Felicidades " + UserName + ". Colocaste todas las letras de la " + ComboBoxRangeA.SelectedItem + ", a la " + ComboBoxRangeB.SelectedItem + ", Juego completado.");
                    ChangeGameState();
                    break;

                case 2:
                    WinSound.Play();
                    TTS.Speak("Felicidades " + UserName + ". Colocaste todas las vocales, juego completado.");
                    ChangeGameState();
                    break;
            }
        }

        #endregion

        #region Iniciar juego

        /// <summary>
        /// Método para iniciar el juego con las letras del alfabeto elegidas.
        /// </summary>
        void StartGameAlphabet()
        {
            TTS.Speak("Comenzando juego de la " + ComboBoxRangeA.SelectedItem + ", a la " + ComboBoxRangeB.SelectedItem + ". ");
            StartMainGame();
            NewLetter();
        }

        /// <summary>
        /// Método para inicializar el juego principal.
        /// </summary>
        void StartMainGame()
        {
            PendingLetters.Clear();

            for (int x = ComboBoxRangeA.SelectedIndex; x < ComboBoxRangeB.SelectedIndex + 1; x++)
            {
                PendingLetters.Add(TempArray[x]);
            }

            if (RadioButtonVowels.Checked)
            {
                foreach (Letter c in Letters)
                {
                    if (!"AEIOU".Contains(c.LetterName))
                    {
                        PendingLetters.Remove(c);
                    }
                }
            }

            if (RadioButtonAleatorio.Checked)
                PendingLetters.Shuffle();

            foreach (Letter c in PendingLetters)
            {
                Console.WriteLine(c.LetterName);
            }
        }

        /// <summary>
        /// Método para iniciar el juego con las vocales.
        /// </summary>
        void StartGameVowels()
        {
            TTS.Speak("Comenzando juego con las vocales.");
            StartMainGame();
            NewLetter();
        }

        #endregion

        #region Otros

        /// <summary>
        /// El método sp2_LineReceived se encargará de manejar los datos que se reciban a través del puerto serial y se enviará la
        /// información al método UpdateUI para procesar los datos.
        /// </summary>
        /// <param name="sender">El objeto que envía el dato (puerto serial).</param>
        /// <param name="Args">Los datos recibidos a través del puerto serial.</param>
        void sp2_LineReceived(object sender, LineReceivedEventArgs Args)
        {
            Console.WriteLine(TAG + Args.LineData);

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(delegate () { UpdateUI(Args.LineData); }));
            }
        }

        /// <summary>
        /// El método UpdateUI actualiza la interfaz de acuerdo a los datos recibidos a través del parámetro enviado por el método sp2_LineReceived
        /// </summary>
        /// <param name="data">Los datos recibidos a través del puerto serial.</param>
        void UpdateUI(string data)
        {
            if (data.Length < 11)
                return;

            string newData = data.Trim();
            if (data.Contains(";"))
            {
                newData = data.Substring(2, data.Length);
            }

            Letter result = Letters.Find(
            delegate (Letter letra)
            {
                return letra.LetterId == newData;
            }
            );

            if (result != null)
            {
                if (GameStarted)
                {
                    if (ExpectedLetter == result)
                    {
                        CorrectDialog(ExpectedLetter);
                        if (SelectedMode == GameMode.Alphabet)
                        {
                            if (PendingLetters.Count <= 0)
                                EndGame(1);
                            else
                                NewLetter();
                        }
                        else if (SelectedMode == GameMode.Vowels)
                        {
                            if (PendingLetters.Count <= 0)
                                EndGame(2);
                            else
                                NewLetter();
                        }
                    }
                    else
                    {
                        ErrorSound.Play();
                        ErrorDialog(result, ExpectedLetter);
                    }
                }
                else
                {
                    HomeSound.Play();
                    FoundDialog(result);
                    LabelLetter.Text = "Letra actual: " + result.LetterName;
                    UpdateUI(result);
                }
            }
            else
            {
                if (!GameStarted)
                {
                    ErrorSound.Play();
                    LabelLetter.Text = "Letra actual:";
                    braille1.Visible = false;
                    braille2.Visible = false;
                    braille3.Visible = false;
                    braille4.Visible = false;
                    braille5.Visible = false;
                    braille6.Visible = false;
                }
            }
        }

        /// <summary>
        /// Método para cambiar el modo de juego de alfabeto a vocales o viceversa.
        /// </summary>
        void ChangeGameState()
        {
            GameStarted = !GameStarted;

            if (GameStarted)
            {
                UserName = TextBoxName.Text;

                switch (SelectedMode)
                {
                    case GameMode.Alphabet:
                        StartGameAlphabet();
                        break;

                    case GameMode.Vowels:
                        StartGameVowels();
                        break;
                }
            }
            else
            {
                EndGame(0);
            }

            TileStartStopGame.TileImage = GameStarted ? tileStop : tilePlay;
            TileStartStopGame.Text = GameStarted ? "TERMINAR JUEGO" : "COMENZAR JUEGO";
            TileSkipLetter.Visible = GameStarted;
            ComboBoxRangeA.Enabled = !GameStarted;
            ComboBoxRangeB.Enabled = !GameStarted;
            RadioButtonAlphabet.Enabled = !GameStarted;
            RadioButtonVowels.Enabled = !GameStarted;
            RadioButtonAleatorio.Enabled = !GameStarted;
            RadioButtonOrdenado.Enabled = !GameStarted;
            TextBoxName.Enabled = !GameStarted;
        }

        /// <summary>
        /// Método para cambiar la letra que se le pide al usuario en un minijuego.
        /// </summary>
        void NewLetter()
        {
            HomeSound.Play();
            ExpectedLetter = PendingLetters.First();
            PendingLetters.RemoveAt(0);
            NewLetterDialog(ExpectedLetter);
            UpdateUI(ExpectedLetter);
        }

        /// <summary>
        /// Método para hacerle saber al usuario que se le está pidiendo una nueva letra durante el minijuego.
        /// </summary>
        /// <param name="ExpectedLetter">Siguiente letra que se le pedirá al usuario.</param>
        private void NewLetterDialog(Letter ExpectedLetter)
        {
            int dialog = rnd.Next(0, 3);
            string dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = ("Coloca la letra: " + ExpectedLetter.LetterPhonetic);
                    break;
                case 1:
                    dialogString = (UserName + ", busca la letra: " + ExpectedLetter.LetterPhonetic + ".");
                    break;
                case 2:
                    dialogString = ("Necesitamos la letra: " + ExpectedLetter.LetterPhonetic);
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " de " + ExpectedLetter.GiveExample(rnd);
            Speak(dialogString);
        }

        /// <summary>
        /// Método para actualizar el texto y los puntos de Braille en la interfaz de usuario.
        /// </summary>
        /// <param name="letter">Letra que se le pide al usuario en el modo juego o que el usuario coloca en el modo práctica.</param>
        void UpdateUI(Letter letter)
        {
            LabelLetter.Text = "Letra actual: " + letter.LetterName;
            braille1.Visible = letter.BrailleEsp.Contains("1");
            braille2.Visible = letter.BrailleEsp.Contains("2");
            braille3.Visible = letter.BrailleEsp.Contains("3");
            braille4.Visible = letter.BrailleEsp.Contains("4");
            braille5.Visible = letter.BrailleEsp.Contains("5");
            braille6.Visible = letter.BrailleEsp.Contains("6");
        }

        /// <summary>
        /// Método para utilizar la función de texto a voz y que el usuario invidente escuche las instrucciones o avisos del programa.
        /// </summary>
        /// <param name="text">Texto con el diálogo que se escuchará a través de los altavoces o audífonos.</param>
        void Speak(string text)
        {
            if (TTS.State == SynthesizerState.Speaking)
                TTS.SpeakAsyncCancelAll();

            TTS.SpeakAsync(text);
        }

        /// <summary>
        /// Método para actualizar la interfaz de usuario cuando se cambia el modo de juego (alfabeto/vocales).
        /// </summary>
        void CambiarTipoJuego()
        {
            if (RadioButtonAlphabet.Checked)
            {
                SelectedMode = GameMode.Alphabet;
                metroLabel1.Text = "Desde: ";
                metroLabel2.Visible = true;
                ComboBoxRangeA.Visible = true;
                ComboBoxRangeB.Visible = true;
            }
            else if (RadioButtonVowels.Checked)
            {
                SelectedMode = GameMode.Vowels;
                metroLabel1.Text = "AEIOU";
                metroLabel2.Visible = false;
                ComboBoxRangeA.Visible = false;
                ComboBoxRangeB.Visible = false;
            }
        }

        #endregion

        #region Componentes

        /// <summary>
        /// Método para evitar un error de selección de rango de letras.
        /// </summary>
        private void ComboBoxRangeA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxRangeA.SelectedIndex > ComboBoxRangeB.SelectedIndex)
            {
                ComboBoxRangeB.SelectedIndex = ComboBoxRangeA.SelectedIndex < Letters.Count - 1 ? ComboBoxRangeA.SelectedIndex + 1 : ComboBoxRangeA.SelectedIndex;
            }

            if (ComboBoxRangeA.SelectedIndex == ComboBoxRangeB.SelectedIndex)
            {
                if (ComboBoxRangeB.SelectedIndex < Letters.Count - 1)
                {
                    ComboBoxRangeB.SelectedIndex = ComboBoxRangeB.SelectedIndex + 1;
                }
                else
                {
                    ComboBoxRangeA.SelectedIndex--;
                }
            }
        }

        /// <summary>
        /// Método para evitar un error de selección de rango de letras.
        /// </summary>
        private void ComboBoxRangeB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxRangeB.SelectedIndex < ComboBoxRangeA.SelectedIndex)
            {
                ComboBoxRangeA.SelectedIndex = ComboBoxRangeB.SelectedIndex > 0 ? ComboBoxRangeB.SelectedIndex - 1 : ComboBoxRangeB.SelectedIndex;
            }

            if (ComboBoxRangeB.SelectedIndex == ComboBoxRangeA.SelectedIndex)
            {
                if (ComboBoxRangeA.SelectedIndex > 0)
                {
                    ComboBoxRangeA.SelectedIndex = ComboBoxRangeA.SelectedIndex - 1;
                }
                else
                {
                    ComboBoxRangeB.SelectedIndex++;
                }
            }
        }

        /// <summary>
        /// Método para iniciar el juego de letras de Braille.
        /// </summary>
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
        private void RadioButtonAlphabet_CheckedChanged(object sender, EventArgs e)
        {
            CambiarTipoJuego();
        }

        private void RadioButtonVowels_CheckedChanged(object sender, EventArgs e)
        {
            CambiarTipoJuego();
        }

        private void Braille_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp2 != null)
            {
                if (sp2.IsOpen())
                    sp2.WriteLine("0");
            }
        }

        private void CheckBoxExample_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxExample.Checked)
            {
                BingSound.Play();
            }
            else
            {
                BorderSound.Play();
            }
        }

        private void PlayClickSound(object sender, EventArgs e)
        {
            ClickSound.Play();
        }

        private void PlayClickSound(object sender, MouseEventArgs e)
        {
            ClickSound.Play();
        }

        private void TileSkipLetter_Click(object sender, EventArgs e)
        {
            NewsSound.Play();
            if (PendingLetters.Count <= 0)
                EndGame(0);
            else
                NewLetter();
        }

        #endregion
    }

    /// <summary>
    ///  Esta clase se utiliza para guardar la información de los identificadores de las tarjetas RFID, 
    ///  cómo se pronuncian las letras de manera correcta, cuáles son los puntos de Braille que utiliza, etc.
    /// </summary>
    class Letter : IEquatable<Letter>
    {
        public char LetterName { get; set; }
        public string LetterId { get; set; }
        public string[] LetterExample { get; set; }
        public string LetterPhonetic { get; set; }
        public string BrailleEsp { get; set; }

        public override string ToString()
        {
            return "ID: " + LetterId + "   Name: " + LetterName + "     Phonetic: " + LetterPhonetic;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Letter objAsPart = obj as Letter;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return 0;
        }
        /// <summary>
        /// Método para comparar un objeto de tipo Letter con otro y saber si es la misma letra.
        /// </summary>
        /// <param name="other">La otra letra.</param>
        /// <returns>Verdadero si es la misma letra, Falso si es null o una letra distinta.</returns>
        public bool Equals(Letter other)
        {
            if (other == null) return false;
            return (this.LetterId.Equals(other.LetterId));
        }
        /// <summary>
        /// Método para dar un ejemplo de una palabra que comience con la letra creada.
        /// </summary>
        /// <param name="rnd">Variable aleatoria.</param>
        /// <returns>Un string con la palabra de ejemplo.</returns>
        public string GiveExample(Random rnd) => LetterExample[rnd.Next(0, LetterExample.Length)];
    }
}

