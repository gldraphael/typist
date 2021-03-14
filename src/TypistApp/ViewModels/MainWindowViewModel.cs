using System.Linq;

namespace TypistApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public TypingViewModel State { get; } = new TypingViewModel();
        public ResultsViewModel Results { get; private set; } = new ResultsViewModel();

        public void UpdateResults()
        {
            Results = new ResultsViewModel
            {
                TimeElapsed = State.TimeElapsed,
                NoOfCharacters = State.TextToType.Length,
                TotalErrors = State.CharactersToType.Count(c => c.WasCharacterMistyped),
                UnCorrectedErrors = State.Mistypes
            };
        }
    }
}
