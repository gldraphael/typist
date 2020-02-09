﻿using Avalonia.Media;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;

namespace TypistApp.ViewModels
{
    public class TypingViewModel : ViewModelBase
    {
        public string TextToType => "Hey there Delilah, what's it like in New York city? I'm a thousand miles away but girl tonight you look so pretty--yes you do. Times Square won't shine as bright you. I swear it's true!";
        public ObservableCollection<CharacterToType> CharactersToType { get; }
        public int Mistypes { get; set; } = 0;

        int Position = 0;

        public void RegisterKeyPress(string text)
        {
            foreach (var c in text) RegisterKeyPressForChar(c);

            void RegisterKeyPressForChar(char c)
            {
                if (Position < CharactersToType.Count)
                {
                    CharactersToType[Position].RegisterEntry(c);
                    if (CharactersToType[Position].WasCharacterMistyped) Mistypes++;
                    Position++;
                }
            }
        }

        public void RegisterBackspace()
        {
            if (Position > 0) Position--;
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
