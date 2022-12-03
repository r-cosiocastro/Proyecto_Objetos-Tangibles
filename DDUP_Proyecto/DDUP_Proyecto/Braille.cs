using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Windows.Forms;
using DDUP_Proyecto.Properties;
using MetroFramework;
using MetroFramework.Forms;

namespace DDUP_Proyecto
{
    /// <summary>
    ///  Esta clase se encarga de crear la ventana para la configuración y uso de la aplicación de Braille
    /// </summary>
    public partial class Braille : MetroForm
    {
        private const string TAG = "Braille.cs: ";

        #region Inicialización y constructores

        // Inicializar variables

        private readonly PuertoSerial _sp2;
        private readonly SpeechSynthesizer _tts = new SpeechSynthesizer();

        private readonly Random _rnd = new Random();
        private GameMode _selectedMode = GameMode.Alphabet;

        private readonly List<Letra> _letras = new List<Letra>();
        private readonly Letra[] _tempArray = new Letra[30];
        private Letra _expectedLetra;
        private readonly List<Letra> _pendingLetters = new List<Letra>();

        private bool _gameStarted;
        private string _userName;

        // Sonidos

        private readonly SoundPlayer _errorSound = new SoundPlayer(Resources.Error);
        private readonly SoundPlayer _foundSound = new SoundPlayer(Resources.Dada_1);
        private readonly SoundPlayer _winSound = new SoundPlayer(Resources.Clap);
        private readonly SoundPlayer _clickSound = new SoundPlayer(Resources.Enter___Back);
        private readonly SoundPlayer _enterSound = new SoundPlayer(Resources.Popup___Run_Title);
        private readonly SoundPlayer _homeSound = new SoundPlayer(Resources.Home);
        private readonly SoundPlayer _newsSound = new SoundPlayer(Resources.News);
        private readonly SoundPlayer _bingSound = new SoundPlayer(Resources.Bing);
        private readonly SoundPlayer _borderSound = new SoundPlayer(Resources.Border);

        // Iconos

        private readonly Image _tilePlay = new Bitmap(Resources.icons8_circled_play_32__1_);
        private readonly Image _tileStop = new Bitmap(Resources.icons8_stop_circled_32__1_);

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
        public Braille(PuertoSerial sp2, MetroThemeStyle theme)
        {
            InitializeComponent();
            StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = theme;

            if (metroStyleManager1.Theme == MetroThemeStyle.Dark)
            {
                braille1.Image = new Bitmap(Resources.icons8_círculo_80_I);
                braille2.Image = new Bitmap(Resources.icons8_círculo_80_I);
                braille3.Image = new Bitmap(Resources.icons8_círculo_80_I);
                braille4.Image = new Bitmap(Resources.icons8_círculo_80_I);
                braille5.Image = new Bitmap(Resources.icons8_círculo_80_I);
                braille6.Image = new Bitmap(Resources.icons8_círculo_80_I);
            }

            _sp2 = sp2;
            if (sp2 != null)
            {
                if (sp2.IsOpen())
                    sp2.WriteLine("1");

                _sp2.LineReceived += sp2_LineReceived;
            }

            _tts.SetOutputToDefaultAudioDevice();



            // Letras, códigos RFID y combinaciones de los puntos de Braille
            _letras.Add(new Letra { Nombre = 'A', Fonetica = "A", ID = "70 82 DD 32", PuntosBraille = "1", Ejemplos = new[] { "Árbol", "Ardilla", "Agua" } });
            _letras.Add(new Letra { Nombre = 'B', Fonetica = "B", ID = "A3 E9 01 40", PuntosBraille = "12", Ejemplos = new[] { "Barco", "Burro", "Brazo" } });
            _letras.Add(new Letra { Nombre = 'C', Fonetica = "C", ID = "45 5B 4D 2A", PuntosBraille = "14", Ejemplos = new[] { "Casa", "Comida", "Caballo" } });
            _letras.Add(new Letra { Nombre = 'D', Fonetica = "Dé", ID = "80 8D 3F 32", PuntosBraille = "145", Ejemplos = new[] { "Dedo", "Delfín", "Diente" } });
            _letras.Add(new Letra { Nombre = 'E', Fonetica = "E", ID = "80 3F 7E 32", PuntosBraille = "15", Ejemplos = new[] { "Estatua", "Elote", "Elefante" } });
            _letras.Add(new Letra { Nombre = 'F', Fonetica = "Efe", ID = "90 1F 2E 32", PuntosBraille = "124", Ejemplos = new[] { "Foca", "Fresa", "Frijol" } });
            _letras.Add(new Letra { Nombre = 'G', Fonetica = "Ge", ID = "93 9A D8 40", PuntosBraille = "1245", Ejemplos = new[] { "Guante", "Gato", "Gelatina" } });
            _letras.Add(new Letra { Nombre = 'H', Fonetica = "Ache", ID = "70 EB 4E 32", PuntosBraille = "125", Ejemplos = new[] { "Huevo", "Helado", "Hongo" } });
            _letras.Add(new Letra { Nombre = 'I', Fonetica = "I", ID = "90 3B B3 32", PuntosBraille = "24", Ejemplos = new[] { "Iglesia", "Iguana", "Isla" } });
            _letras.Add(new Letra { Nombre = 'J', Fonetica = "Jota", ID = "90 F9 5D 32", PuntosBraille = "245", Ejemplos = new[] { "Jeringa", "Jamón", "Jardín" } });
            _letras.Add(new Letra { Nombre = 'K', Fonetica = "Ca", ID = "C7 7F 37 19", PuntosBraille = "13", Ejemplos = new[] { "Kilo", "Koala", "Kiwi" } });
            _letras.Add(new Letra { Nombre = 'L', Fonetica = "L", ID = "70 86 15 32", PuntosBraille = "123", Ejemplos = new[] { "León", "Lagartija", "Lápiz" } });
            _letras.Add(new Letra { Nombre = 'M', Fonetica = "M", ID = "F4 5A 3B 2A", PuntosBraille = "134", Ejemplos = new[] { "Mundo", "Mariposa", "Mano" } });
            _letras.Add(new Letra { Nombre = 'N', Fonetica = "N", ID = "B7 17 C5 3B", PuntosBraille = "1345", Ejemplos = new[] { "Nariz", "Niño", "Nopal" } });
            _letras.Add(new Letra { Nombre = 'O', Fonetica = "O", ID = "04 6B D6 2B", PuntosBraille = "135", Ejemplos = new[] { "Ojo", "Oso", "Oreja" } });
            _letras.Add(new Letra { Nombre = 'P', Fonetica = "Pé", ID = "F4 CC 26 2A", PuntosBraille = "1234", Ejemplos = new[] { "Paleta", "Plato", "Pescado" } });
            _letras.Add(new Letra { Nombre = 'Q', Fonetica = "Cú", ID = "04 56 53 2B", PuntosBraille = "12345", Ejemplos = new[] { "Queso", "Quesadilla", "Química" } });
            _letras.Add(new Letra { Nombre = 'R', Fonetica = "Erre", ID = "B3 08 1B 40", PuntosBraille = "1235", Ejemplos = new[] { "Ratón", "Rama", "Rueda" } });
            _letras.Add(new Letra { Nombre = 'S', Fonetica = "Ese", ID = "04 8A 86 2B", PuntosBraille = "234", Ejemplos = new[] { "Sartén", "Serpiente", "Sopa" } });
            _letras.Add(new Letra { Nombre = 'T', Fonetica = "Té", ID = "04 2B 3E 2B", PuntosBraille = "2345", Ejemplos = new[] { "Taza", "Taco", "Tortuga" } });
            _letras.Add(new Letra { Nombre = 'U', Fonetica = "U", ID = "90 FB A0 32", PuntosBraille = "136", Ejemplos = new[] { "Uva", "Uña", "Unicornio" } });
            _letras.Add(new Letra { Nombre = 'V', Fonetica = "Uvé", ID = "04 0E 23 2B", PuntosBraille = "1236", Ejemplos = new[] { "Vaca", "Vuelta", "Vacío" } });
            _letras.Add(new Letra { Nombre = 'W', Fonetica = "DobleÚ", ID = "35 6E 84 2A", PuntosBraille = "2456", Ejemplos = new[] { "Whiskey", "Wi-Fi", "Waffle" } });
            _letras.Add(new Letra { Nombre = 'X', Fonetica = "Equis", ID = "04 B6 48 2B", PuntosBraille = "1346", Ejemplos = new[] { "Xilófono" } });
            _letras.Add(new Letra { Nombre = 'Y', Fonetica = "I griega", ID = "04 A7 77 2B", PuntosBraille = "13456", Ejemplos = new[] { "Yo-yó", "Yegua", "Yogurt" } });
            _letras.Add(new Letra { Nombre = 'Z', Fonetica = "Zeta", ID = "F4 6F 96 2A", PuntosBraille = "1356", Ejemplos = new[] { "Zanahoria", "Zapato", "Zoológico" } });
            _letras.Add(new Letra { Nombre = 'M', Fonetica = "Mario", ID = "71 CB 17 EC", PuntosBraille = "123456", Ejemplos = new[] { "Zanahoria", "Zapato", "Zoológico" } });


            _letras.CopyTo(_tempArray);

            ComboBoxRangeA.Items.Clear();
            ComboBoxRangeB.Items.Clear();

            for (var letter = 'A'; letter <= 'Z'; letter++)
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
        /// <param name="actualLetra">La letra que el usuario ingresó en el tablero.</param>
        /// <param name="requested">La letra que se le pidió al usuario que ingresara.</param>
        private void ErrorDialog(Letra actualLetra, Letra requested)
        {
            var dialog = _rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    Speak("Coloca la letra " + requested.Fonetica);
                    break;
                case 1:
                    Speak(_userName + ", busca la letra " + requested.Fonetica + ". ");
                    break;
                case 2:
                    Speak(_userName + ", esa no es la letra " + requested.Fonetica + ". ");
                    break;
                case 3:
                    Speak("Esa es la letra " + actualLetra.Fonetica + ", necesitamos la letra " + requested.Fonetica);
                    break;
            }
        }

        /// <summary>
        /// El método FoundDialog crea un diálogo aleatorio para decirle al usuario qué letra es la que colocó en el tablero.
        /// </summary>
        /// <param name="letra">La letra que el usuario ingresó en el tablero.</param>
        private void FoundDialog(Letra letra)
        {
            var dialog = _rnd.Next(0, 3);
            var dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = "Esa es la letra " + letra.Fonetica;
                    break;
                case 1:
                    dialogString = "Colocaste la letra " + letra.Fonetica;
                    break;
                case 2:
                    dialogString = "Detecto la letra " + letra.Fonetica;
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " de " + letra.GiveExample(_rnd);

            Speak(dialogString);
        }

        /// <summary>
        /// El método CorrectDialog crea un diálogo aleatorio para felicitar al usuario después de ingresar la letra que se le pidió. (Solo en el modo juego).
        /// </summary>
        /// <param name="letra">La letra que el usuario ingresó en el tablero.</param>
        private void CorrectDialog(Letra letra)
        {
            _foundSound.Play();
            var dialog = _rnd.Next(0, 4);
            switch (dialog)
            {
                case 0:
                    _tts.Speak("Correcto, " + _userName + ", esa es la letra " + letra.Fonetica);
                    break;
                case 1:
                    _tts.Speak("Muy bien, " + _userName + ", esa es la letra " + letra.Fonetica);
                    break;
                case 2:
                    _tts.Speak("Bien hecho, " + _userName + ", encontraste la letra " + letra.Fonetica);
                    break;
                case 3:
                    _tts.Speak("Perfecto, encontraste la letra " + letra.Fonetica);
                    break;
            }
        }

        /// <summary>
        /// El método EndGame termina el juego en curso determinando una razón del termino del juego ya sea por el tutor o porque se acabaron las letras en el minijuego.
        /// </summary>
        /// <param name="razon">Razón por la cual se terminó el juego.</param>
        private void EndGame(int razon)
        {
            switch (razon)
            {
                case 0:
                    _tts.Speak("Terminando juego");
                    break;

                case 1:
                    _winSound.Play();
                    _tts.Speak("Felicidades " + _userName + ". Colocaste todas las letras de la " + ComboBoxRangeA.SelectedItem + ", a la " + ComboBoxRangeB.SelectedItem + ", Juego completado.");
                    ChangeGameState();
                    break;

                case 2:
                    _winSound.Play();
                    _tts.Speak("Felicidades " + _userName + ". Colocaste todas las vocales, juego completado.");
                    ChangeGameState();
                    break;
            }
        }

        #endregion

        #region Iniciar juego

        /// <summary>
        /// Método para iniciar el juego con las letras del alfabeto elegidas.
        /// </summary>
        private void StartGameAlphabet()
        {
            _tts.Speak("Comenzando juego de la " + ComboBoxRangeA.SelectedItem + ", a la " + ComboBoxRangeB.SelectedItem + ". ");
            StartMainGame();
            NewLetter();
        }

        /// <summary>
        /// Método para inicializar el juego principal.
        /// </summary>
        private void StartMainGame()
        {
            _pendingLetters.Clear();

            for (var x = ComboBoxRangeA.SelectedIndex; x < ComboBoxRangeB.SelectedIndex + 1; x++)
            {
                _pendingLetters.Add(_tempArray[x]);
            }

            if (RadioButtonVowels.Checked)
            {
                foreach (var c in _letras.Where(c => !"AEIOU".Contains(c.Nombre)))
                {
                    _pendingLetters.Remove(c);
                }
            }

            if (RadioButtonAleatorio.Checked)
                _pendingLetters.Shuffle();

            foreach (Letra c in _pendingLetters)
            {
                Console.WriteLine(c.Nombre);
            }
        }

        /// <summary>
        /// Método para iniciar el juego con las vocales.
        /// </summary>
        private void StartGameVowels()
        {
            _tts.Speak("Comenzando juego con las vocales.");
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
        private void sp2_LineReceived(object sender, LineReceivedEventArgs Args)
        {
            Console.WriteLine(TAG + Args.LineData);

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(delegate { UpdateUI(Args.LineData); }));
            }
        }

        /// <summary>
        /// El método UpdateUI actualiza la interfaz de acuerdo a los datos recibidos a través del parámetro enviado por el método sp2_LineReceived
        /// </summary>
        /// <param name="data">Los datos recibidos a través del puerto serial.</param>
        private void UpdateUI(string data)
        {
            if (data.Length < 11)
                return;

            var newData = data.Trim();
            if (data.Contains(";"))
            {
                newData = data.Substring(2, data.Length);
            }

            var result = _letras.Find(
                letra => letra.ID == newData
            );

            if (result != null)
            {
                if (_gameStarted)
                {
                    if (_expectedLetra.Equals(result))
                    {
                        CorrectDialog(_expectedLetra);
                        switch (_selectedMode)
                        {
                            case GameMode.Alphabet when _pendingLetters.Count <= 0:
                                EndGame(1);
                                break;
                            case GameMode.Alphabet:
                                NewLetter();
                                break;
                            case GameMode.Vowels when _pendingLetters.Count <= 0:
                                EndGame(2);
                                break;
                            case GameMode.Vowels:
                                NewLetter();
                                break;
                        }
                    }
                    else
                    {
                        _errorSound.Play();
                        ErrorDialog(result, _expectedLetra);
                    }
                }
                else
                {
                    _homeSound.Play();
                    FoundDialog(result);
                    LabelLetter.Text = "Letra actual: " + result.Nombre;
                    UpdateUI(result);
                }
            }
            else
            {
                if (_gameStarted) return;
                _errorSound.Play();
                LabelLetter.Text = "Letra actual:";
                braille1.Visible = false;
                braille2.Visible = false;
                braille3.Visible = false;
                braille4.Visible = false;
                braille5.Visible = false;
                braille6.Visible = false;
            }
        }

        /// <summary>
        /// Método para cambiar el modo de juego de alfabeto a vocales o viceversa.
        /// </summary>
        private void ChangeGameState()
        {
            _gameStarted = !_gameStarted;

            if (_gameStarted)
            {
                _userName = TextBoxName.Text;

                switch (_selectedMode)
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

            TileStartStopGame.TileImage = _gameStarted ? _tileStop : _tilePlay;
            TileStartStopGame.Text = _gameStarted ? "TERMINAR JUEGO" : "COMENZAR JUEGO";
            TileSkipLetter.Visible = _gameStarted;
            ComboBoxRangeA.Enabled = !_gameStarted;
            ComboBoxRangeB.Enabled = !_gameStarted;
            RadioButtonAlphabet.Enabled = !_gameStarted;
            RadioButtonVowels.Enabled = !_gameStarted;
            RadioButtonAleatorio.Enabled = !_gameStarted;
            RadioButtonOrdenado.Enabled = !_gameStarted;
            TextBoxName.Enabled = !_gameStarted;
        }

        /// <summary>
        /// Método para cambiar la letra que se le pide al usuario en un minijuego.
        /// </summary>
        private void NewLetter()
        {
            _homeSound.Play();
            _expectedLetra = _pendingLetters.First();
            _pendingLetters.RemoveAt(0);
            NewLetterDialog(_expectedLetra);
            UpdateUI(_expectedLetra);
        }

        /// <summary>
        /// Método para hacerle saber al usuario que se le está pidiendo una nueva letra durante el minijuego.
        /// </summary>
        /// <param name="expectedLetra">Siguiente letra que se le pedirá al usuario.</param>
        private void NewLetterDialog(Letra expectedLetra)
        {
            var dialog = _rnd.Next(0, 3);
            var dialogString = "";
            switch (dialog)
            {
                case 0:
                    dialogString = ("Coloca la letra: " + expectedLetra.Fonetica);
                    break;
                case 1:
                    dialogString = (_userName + ", busca la letra: " + expectedLetra.Fonetica + ".");
                    break;
                case 2:
                    dialogString = ("Necesitamos la letra: " + expectedLetra.Fonetica);
                    break;
            }
            if (CheckBoxExample.Checked)
                dialogString += " de " + expectedLetra.GiveExample(_rnd);
            Speak(dialogString);
        }

        /// <summary>
        /// Método para actualizar el texto y los puntos de Braille en la interfaz de usuario.
        /// </summary>
        /// <param name="letra">Letra que se le pide al usuario en el modo juego o que el usuario coloca en el modo práctica.</param>
        private void UpdateUI(Letra letra)
        {
            LabelLetter.Text = "Letra actual: " + letra.Nombre;
            braille1.Visible = letra.PuntosBraille.Contains("1");
            braille2.Visible = letra.PuntosBraille.Contains("2");
            braille3.Visible = letra.PuntosBraille.Contains("3");
            braille4.Visible = letra.PuntosBraille.Contains("4");
            braille5.Visible = letra.PuntosBraille.Contains("5");
            braille6.Visible = letra.PuntosBraille.Contains("6");
        }

        /// <summary>
        /// Método para utilizar la función de texto a voz y que el usuario invidente escuche las instrucciones o avisos del programa.
        /// </summary>
        /// <param name="text">Texto con el diálogo que se escuchará a través de los altavoces o audífonos.</param>
        private void Speak(string text)
        {
            if (_tts.State == SynthesizerState.Speaking)
                _tts.SpeakAsyncCancelAll();

            _tts.SpeakAsync(text);
        }

        /// <summary>
        /// Método para actualizar la interfaz de usuario cuando se cambia el modo de juego (alfabeto/vocales).
        /// </summary>
        void CambiarTipoJuego()
        {
            if (RadioButtonAlphabet.Checked)
            {
                _selectedMode = GameMode.Alphabet;
                metroLabel1.Text = "Desde: ";
                metroLabel2.Visible = true;
                ComboBoxRangeA.Visible = true;
                ComboBoxRangeB.Visible = true;
            }
            else if (RadioButtonVowels.Checked)
            {
                _selectedMode = GameMode.Vowels;
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
                ComboBoxRangeB.SelectedIndex = ComboBoxRangeA.SelectedIndex < _letras.Count - 1 ? ComboBoxRangeA.SelectedIndex + 1 : ComboBoxRangeA.SelectedIndex;
            }

            if (ComboBoxRangeA.SelectedIndex != ComboBoxRangeB.SelectedIndex) return;
            if (ComboBoxRangeB.SelectedIndex < _letras.Count - 1)
            {
                ComboBoxRangeB.SelectedIndex += 1;
            }
            else
            {
                ComboBoxRangeA.SelectedIndex--;
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

            if (ComboBoxRangeB.SelectedIndex != ComboBoxRangeA.SelectedIndex) return;
            if (ComboBoxRangeA.SelectedIndex > 0)
            {
                ComboBoxRangeA.SelectedIndex -= 1;
            }
            else
            {
                ComboBoxRangeB.SelectedIndex++;
            }
        }

        /// <summary>
        /// Método para iniciar el juego de letras de Braille.
        /// </summary>
        private void StartGameTile_Click(object sender, EventArgs e)
        {
            if (TextBoxName.Text.Trim().Length >= 3)
            {
                _enterSound.Play();
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
            if (_sp2 == null) return;
            if (_sp2.IsOpen())
                _sp2.WriteLine("0");
        }

        private void CheckBoxExample_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxExample.Checked)
            {
                _bingSound.Play();
            }
            else
            {
                _borderSound.Play();
            }
        }

        private void PlayClickSound(object sender, EventArgs e)
        {
            _clickSound.Play();
        }

        private void PlayClickSound(object sender, MouseEventArgs e)
        {
            _clickSound.Play();
        }

        private void TileSkipLetter_Click(object sender, EventArgs e)
        {
            _newsSound.Play();
            if (_pendingLetters.Count <= 0)
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
    internal class Letra : IEquatable<Letra>
    {
        public char Nombre { get; set; }
        public string ID { get; set; }
        public string[] Ejemplos { get; set; }
        public string Fonetica { get; set; }
        public string PuntosBraille { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + "   Name: " + Nombre + "     Phonetic: " + Fonetica;
        }
        public override bool Equals(object obj)
        {
            var objAsPart = obj as Letra;
            return objAsPart != null && Equals(objAsPart);
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
        public bool Equals(Letra other)
        {
            return ID != null && other != null && ID.Equals(other.ID);
        }
        /// <summary>
        /// Método para dar un ejemplo de una palabra que comience con la letra creada.
        /// </summary>
        /// <param name="rnd">Variable aleatoria.</param>
        /// <returns>Un string con la palabra de ejemplo.</returns>
        public string GiveExample(Random rnd) => Ejemplos[rnd.Next(0, Ejemplos.Length)];
    }
}

