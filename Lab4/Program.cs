namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt16(Console.ReadLine());
            }
            void Sort()
            {
                for(int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 1)
                    {
                        Console.Write(arr[i]+" ");
                    }
                }
            }
            Sort();
        }
    }
}
