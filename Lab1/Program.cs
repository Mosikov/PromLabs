namespace Lab1
{
    class BubbleSort
    {
        Random rnd = new Random();
        int[] arr = new int[9];
        int _buff;
        public void RndInt()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(99);
                Console.Write(arr[i] + " ");
            }
        }
        public void Sort()
        {
            for(int n = 0; n < arr.Length; n++)
            {
                for (int i = 0, j = 1; j < arr.Length; i++, j++)
                {
                    if (arr[i] < arr[j])
                    {
                        _buff = arr[i];
                        arr[i] = arr[j];
                        arr[j] = _buff;
                    }
                }
            }
        }
        public void SortArrOut()
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.RndInt();
            bubbleSort.Sort();
            Console.WriteLine();
            bubbleSort.SortArrOut();
        }
    }
}
