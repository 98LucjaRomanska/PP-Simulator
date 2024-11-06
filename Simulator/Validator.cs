
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
            if (min > value.Length) 
            {   
                min = value.Length;
                return value.PadRight(min, placeholder);
            }
            else if (max < value.Length)
            {
                return value.Substring(0, max);
            }
            else if ((max | min) == value.Length)
            { 
                return value;
            }
            return value; 
        }
        
     }
}
