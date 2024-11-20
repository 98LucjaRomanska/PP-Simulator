
namespace Simulator
{
    public static class Validator
    {


        public static int Limiter(int value, int min, int max)
        {
            if (value < min) { return min; }
            if (max < value) { return max; }
            if (value == min) return min;
            if (value == max) return max;
            return value; 
 
        }

        public static string Shortener(string value, int min, int max, char placeholder)
        {
            value = value.Trim();
            if (min > value.Length) 
            {
                int new_min = min - value.Length;
                for (int i = 0; i < new_min; i++)
                {
                    value += placeholder;
                }
            }
            else if (max < value.Length)
            {
                value = value[0..max].Trim();
            }
            else if ((max | min) == value.Length)
            { 
                return value;
            }
            return value; 
        }
        
     }
}
