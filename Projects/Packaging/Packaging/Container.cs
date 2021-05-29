namespace Packaging
{
    public class Container
    {
        private double _filled;
        private double MaxFill { get; }
        public double Available => MaxFill - _filled;
        
        public Container(double maxFill = 1)
        {
            _filled = 0;
            MaxFill = maxFill;
        }

        public bool Add(double number)
        {
            if (Available - number >= 0)
            {
                _filled += number;
                return true;
            }
            return false;
        }
    }
}