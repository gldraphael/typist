using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using TypistApp.ViewModels;

namespace TypistApp.Views
{
    public class TypingView : UserControl
    {
        private TypingViewModel VM => DataContext as TypingViewModel;

        public TypingView()
        {
            this.InitializeComponent();
            this.KeyDown += TypingView_KeyDown;
        }

        private void TypingView_KeyDown(object sender, KeyEventArgs e)
        {
            VM.RegisterKeyPress(e.Key);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
