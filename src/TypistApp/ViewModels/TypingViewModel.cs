using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TypistApp.ViewModels
{
    public class TypingViewModel : ViewModelBase
    {
        public string TextToType => "Hello World!";
        public ObservableCollection<CharacterToType> CharactersToType { get; private set; }
        public int Mistypes { get; private set; } = 0;
        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }


        public event EventHandler SessionCompleted;


        int Position = 0;

        public TypingViewModel()
        {
            CharactersToType = CharacterToType.GetCharacters(TextToType);
        }

        public void RegisterKeyPress(string text)
        {
            foreach (var c in text) RegisterKeyPressForChar(c);

            void RegisterKeyPressForChar(char c)
            {
                if (StartTime is null) StartTime = DateTime.UtcNow;
                if (Position < CharactersToType.Count)
                {
                    CharactersToType[Position].RegisterEntry(c);
                    if (CharactersToType[Position].WasCharacterMistyped) Mistypes++;
                    Position++;

                    if(Position == CharactersToType.Count)
                    {
                        EndTime = DateTime.UtcNow;
                        SessionCompleted?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void RegisterBackspace()
        {
            if (Position > 0) Position--;
        }
    }


    public class CharacterToType : ViewModelBase
    {
        public char ActualCharacter { get; }
        public char? EnteredCharacter { get; private set; }

        public bool IsEntryDone => EnteredCharacter != null;
        public bool WasCharacterMistyped => IsEntryDone && EnteredCharacter != ActualCharacter;

        public SolidColorBrush BackgroundColor
        {
            get
            {
                if (!IsEntryDone) return new SolidColorBrush();
                else if (WasCharacterMistyped) return new SolidColorBrush(AppColors.BackgroundRed); 
                else return new SolidColorBrush(AppColors.BackgroundGreen);
            }
        }


        public CharacterToType(char c)
        {
            ActualCharacter = c;
        }

        public void RegisterEntry(char c)
        {
            EnteredCharacter = c;

            this.RaisePropertyChanged(nameof(EnteredCharacter));
            this.RaisePropertyChanged(nameof(BackgroundColor));
        }

        public static ObservableCollection<CharacterToType> GetCharacters(string s) =>
            new ObservableCollection<CharacterToType>(s.ToCharArray().Select(c => new CharacterToType(c)));
    }
}
