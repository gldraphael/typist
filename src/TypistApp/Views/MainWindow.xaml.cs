using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TypistApp.ViewModels;

namespace TypistApp.Views
{
    public class MainWindow : Window
    {
        private MainWindowViewModel VM => DataContext as MainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            TextInput += MainWindow_TextInput;
        }

        private void MainWindow_TextInput(object sender, Avalonia.Input.TextInputEventArgs e)
        {
            VM.State.RegisterKeyPress(e.Text);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
