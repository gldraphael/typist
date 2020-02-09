using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TypistApp.Views
{
    public class ResultsViewModel : UserControl
    {
        public ResultsViewModel()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
