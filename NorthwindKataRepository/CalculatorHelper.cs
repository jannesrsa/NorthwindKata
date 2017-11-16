namespace NorthwindKataRepository
{
    public class CalculatorHelper
    {
        public int Add(params int[] values)
        {
            var total = default(int);
            foreach (var value in values)
            {
                total = total + value;
            }

            return total;
        }
    }
}