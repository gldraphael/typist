using Avalonia.Input;
using Avalonia.Media;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TypistApp.ViewModels
{
    public class TypingViewModel : ViewModelBase
    {
        public string TextToType => "Hey there Delilah, what's it like in New York city? I'm a thousand miles away but girl tonight you look so pretty--yes you do. Times Square won't shine as bright you. I swear it's true!";
        public ObservableCollection<CharacterToType> CharactersToType { get; } 

        int Position = 0;

        public void RegisterKeyPress(Key key)
        {
            if (key is Key.Back) Position--;
            else
            {
                if (Position < 0) Position = 0;
                if(Position < CharactersToType.Count)
                {
                    CharactersToType[Position].RegisterEntry(key);
                }
                
                Position++;
            }
        }

        public TypingViewModel()
        {
            CharactersToType = CharacterToType.GetCharacters(TextToType);
        }
    }


    public class CharacterToType : ViewModelBase
    {
        public char ActualCharacter { get; }
        public char? EnteredCharacter { get; private set; }

        public SolidColorBrush BackgroundColor
        {
            get
            {
                if (EnteredCharacter is null) return new SolidColorBrush();
                else if (EnteredCharacter == ActualCharacter) return new SolidColorBrush(AppColors.BackgroundGreen);
                else return new SolidColorBrush(AppColors.BackgroundRed);
            }
        }


        public CharacterToType(char c)
        {
            ActualCharacter = c;
        }

        public void RegisterEntry(Key k)
        {
            char c = k.ToString()[0];
            EnteredCharacter = c;

            this.RaisePropertyChanged(nameof(EnteredCharacter));
            this.RaisePropertyChanged(nameof(BackgroundColor));
        }

        public static ObservableCollection<CharacterToType> GetCharacters(string s)
        {
            return new ObservableCollection<CharacterToType>(get(s));
             
            IEnumerable<CharacterToType> get(string s)
            {
                foreach (var c in s) yield return new CharacterToType(c);
            }
        }
    }
}
