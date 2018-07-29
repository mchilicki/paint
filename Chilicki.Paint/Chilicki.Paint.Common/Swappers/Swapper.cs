namespace Chilicki.Paint.Common.Swappers
{
    public class Swapper
    {
        public static void Swap<T>(ref T object1, ref T object2)
        {
            T swapperHelper = object1;
            object1 = object2;
            object2 = swapperHelper;
        }
    }
}
