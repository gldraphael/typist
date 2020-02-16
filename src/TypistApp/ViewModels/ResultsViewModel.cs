using System;
using System.Collections.Generic;
using System.Text;

namespace TypistApp.ViewModels
{
    // Equations from: https://www.speedtypingonline.com/typing-equations
    public class ResultsViewModel : ViewModelBase
    {
        const int AVG_WORD_LENGTH = 5;

        public int NoOfCharacters { get; set; }
        public int TotalErrors { get; set; }
        public int UnCorrectedErrors { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public string TimeElapsedText => $"{TimeElapsed.Minutes}m {TimeElapsed.Seconds}s {TimeElapsed.Milliseconds}ms";
        public double GrossWPM => (NoOfCharacters / AVG_WORD_LENGTH) / TimeElapsed.TotalMinutes;
        public double NetWPM => Math.Ceiling(GrossWPM - (UnCorrectedErrors / TimeElapsed.TotalSeconds));
        public float Accuracy => (1f - TotalErrors / (float)NoOfCharacters) * 100;
    }
}
