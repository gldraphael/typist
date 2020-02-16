using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using TypistApp.ViewModels;

namespace TypistApp.Views
{
    public class MainWindow : Window
    {
        private MainWindowViewModel VM => DataContext as MainWindowViewModel;

        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            TextInput += MainWindow_TextInput;
            KeyDown += MainWindow_KeyDown;
            VM.State.SessionCompleted += State_SessionCompleted;
        }

        private void State_SessionCompleted(object sender, System.EventArgs e)
        {
            Content = VM.Results;
        }

        private void MainWindow_TextInput(object sender, TextInputEventArgs e)
        {
            VM.State.RegisterKeyPress(e.Text);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Back)
            {
                VM.State.RegisterBackspace();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        
    }
}
