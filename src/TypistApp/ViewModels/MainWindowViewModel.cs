﻿namespace TypistApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public TypingViewModel State { get; } = new TypingViewModel();
    }
}