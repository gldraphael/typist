using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TypistApp.Views
{
    public class ResultsView : UserControl
    {
        public ResultsView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
