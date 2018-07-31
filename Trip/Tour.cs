namespace Trip
{
    public class Tour
    {
        public string From { get; private set; }
        public string To { get; private set; }

        public Tour(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
