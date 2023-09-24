namespace PowerPlant.Domain
{
    public class PowerRange
    {
        public int Minimum { get; }
        public int Maximum { get; }
        public PowerRange(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
