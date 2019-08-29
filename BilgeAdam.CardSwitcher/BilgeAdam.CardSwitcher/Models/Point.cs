namespace BilgeAdam.CardSwitcher.Models
{
    public class Location
    {
        public Location(int p1, int p2)
        {
            Point1 = p1;
            Point2 = p2;
        }
        public int Point1 { get; set; }
        public int Point2 { get; set; }

        public override string ToString()
        {
            return $"{Point1} - {Point2}";
        }
    }
}