using ReactiveUI;

namespace TypistApp.ViewModels
{
    public class TypingViewModel : ViewModelBase
    {
        public int KeysPressed { get; private set; } = 0;

        public void RegisterKeyPress()
        {
            KeysPressed++;
            this.RaisePropertyChanged(nameof(KeysPressed));
        }
    }
}
