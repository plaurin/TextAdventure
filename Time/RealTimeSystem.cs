namespace Time
{
    public class RealTimeSystem
    {
        private DateTimeOffset _gameStartTime;
        private TimeSpan _inGameTime;

        private long _gameStartDay = 0;
        private int _gameStartDayOfWeek = 0;

        private string[] _daysOfWeek;
        private string[] _monthsOfYear;
        private int _daysPerMonth;

        public RealTimeSystem()
        {
            _gameStartTime = DateTimeOffset.Now;

            _daysOfWeek = ["MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"];
            _monthsOfYear = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
            _daysPerMonth = 30;
        }

        public TimeSpan GameTime => TimeSpan.FromDays(_gameStartDay) + DateTimeOffset.Now.Subtract(_gameStartTime) + _inGameTime;

        public string GameDayOfWeek => _daysOfWeek[(GameTime.Days + _gameStartDayOfWeek) % DaysPerWeek];
        public string GameMonthOfYear => _monthsOfYear[GameTime.Days / _daysPerMonth % _monthsOfYear.Length];

        public int GameYear => GameTime.Days / DaysPerYear;
        public int GameMonth => (GameTime.Days / _daysPerMonth) % _monthsOfYear.Length + 1;
        public int GameDay => GameTime.Days % _daysPerMonth + 1;

        public string HumanizedTime => $"{GameTime:hh}:{GameTime:mm}:{GameTime:ss}";
        public string HumanizedDate => $"{GameDayOfWeek}, {GameMonthOfYear} {HumanizedDay}, {GameYear}";
        private string HumanizedDay => GameDay == 1
            ? "1st"
            : GameDay == 2
                ? "2nd"
                : GameDay == 3
                    ? "3rd"
                    : $"{GameDay}th";

        public int MonthsPerYear => _monthsOfYear.Length;
        public int DaysPerWeek => _daysOfWeek.Length;
        public int DaysPerMonth => _daysPerMonth;
        public int DaysPerYear => DaysPerMonth * MonthsPerYear;

        public void SetDaysOfWeek(params string[] daysOfWeeks) => _daysOfWeek = daysOfWeeks;
        public void SetMonthsOfYear(params string[] monthsOfYear) => _monthsOfYear = monthsOfYear;
        public void SetDaysPerMonth(int daysPerMonth)
        {
            _daysPerMonth = daysPerMonth;
        }

        public void SetGameStartTime(int year, int month, int day, string dayOfWeek)
        {
            if (month < 1 || month > MonthsPerYear) throw new ArgumentOutOfRangeException(nameof(month), $"{nameof(month)} must be between 1 and {MonthsPerYear} but was {month}");
            if (day < 1 || day > DaysPerMonth) throw new ArgumentOutOfRangeException(nameof(day), $"{nameof(day)} must be between 1 and {DaysPerMonth} but was {day}");

            _gameStartDay = (year * MonthsPerYear + month - 1) * DaysPerMonth + day - 1;

            var index = _daysOfWeek.IndexOf(dayOfWeek);
            if (index == -1) throw new ArgumentOutOfRangeException(nameof(dayOfWeek), $"{dayOfWeek} not a day of week");

            _gameStartDayOfWeek = (int)((DaysPerWeek + index - _gameStartDay) % DaysPerWeek);
        }

        public void AddTime(TimeSpan timeSpan)
        {
            _inGameTime += timeSpan;
        }
    }
}
