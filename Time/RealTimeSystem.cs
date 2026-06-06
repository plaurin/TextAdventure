namespace Time
{
    public class RealTimeSystem
    {
        private DateTimeOffset _gameStartTime;

        public RealTimeSystem()
        {
            _gameStartTime = DateTimeOffset.Now;
        }

        public TimeSpan GameTime => DateTimeOffset.Now.Subtract(_gameStartTime);
    }
}
