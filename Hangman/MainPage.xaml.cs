using System.ComponentModel;
using System.Diagnostics;

namespace Hangman
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        #region UI PROPERTIES
        public string Spotlight
        {
            get => spotlight;
            set
            {
                spotlight = value;
                OnPropertyChanged();
            }
        }

        public List<Char> Letters
        {
            get => letters;
            set
            {
                letters = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        public string GameStatus
        {
            get => gameStatus;
            set
            {
                gameStatus = value;
                OnPropertyChanged();
            }
        }

        public string CurrentImage
        {
            get => currentImage; 
            set
            {
                currentImage = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region FIELDS

        List<string> words = new List<string>()
        {
            "python",
            "javascript",
            "maui",
            "csharp",
            "mongodb",
            "sql",
            "xaml",
            "word",
            "excel",
            "powerpoint",
            "code",
            "hotreload",
            "snippets"
        };
        private string answer = "";
        private string spotlight;
        private List<char> guessed = new List<char>();
        private List<char> letters = new List<char>();
        private string message;
        private int mistakes = 0;
        private string gameStatus;
        private int maxWrong = 6;
        private string currentImage = "img0.jpg";

        #endregion

        #region GAME ENGINE

        private void PickWord()
        {
            answer = words[new Random().Next(0, words.Count)];
        }

        private void CalculateWord(string answer, List<Char> guessed)
        {
            var temp = answer.Select(x => (guessed.IndexOf(x) >= 0) ? x : '_').ToArray();
            Spotlight = string.Join(" ", temp);
        }

        #endregion

        public MainPage()
        {
            InitializeComponent();
            Letters.AddRange("abcdefghijklmnñopqrstuvwxyz");
            BindingContext = this;
            PickWord();
            CalculateWord(answer, guessed);
            UpdateStatus();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var letter = button.Text;
                button.IsEnabled = false;
                HandleGuess(letter[0]);
            }
        }

        private void HandleGuess(char letter)
        {
            if (guessed.IndexOf(letter) == -1)
            {
                guessed.Add(letter);
            }
            if (answer.IndexOf(letter) >= 0)
            {
                CalculateWord(answer, guessed);
                CheckIfGameWon();
            }
            else
            {
                mistakes++;
                UpdateStatus();
                CheckIfGameLost();
                CurrentImage = $"img{mistakes}.jpg";
            }
        }

        private void CheckIfGameWon()
        {
            if (Spotlight.Replace(" ", "") == answer)
            {
                Message = "You win";
                EnableDisableLetters(false);
            }
        }

        private void EnableDisableLetters(bool status)
        {
            foreach(var children in LettersContainer.Children)
            {
                var btn = children as Button;
                if (btn != null)
                {
                    btn.IsEnabled = status;
                }
            }
        }

        private void UpdateStatus()
        {
            GameStatus = $"Errors: {mistakes} of {maxWrong}";
        }

        private void CheckIfGameLost()
        {
            if (mistakes == maxWrong)
            {
                Message = "You Lost";
                EnableDisableLetters(false);
            }

        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            mistakes = 0;
            guessed = new List<char>();
            CurrentImage = "img0.jpg";
            PickWord();
            CalculateWord(answer, guessed);
            Message = "";
            UpdateStatus();
            EnableDisableLetters(true);
        }
    }
}