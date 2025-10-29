internal class Program
{
    static int SeqSearch(int[] arr, int value)
    {
        int i = 0;
        while (arr[i] != value)
            i++;
        return i;
    }
    static int RecuSearch(int[] arr, int from, int value)
    {
        if (arr[from] == value)
            return from;
        else
            return RecuSearch(arr, from + 1, value);
    }
    static int RecuSearch2(Array arr, int value)
    {
        if (arr.GetValue(arr.GetLowerBound(0)).Equals(value))
            return 0;
        else
        {
            Array temp = Array.CreateInstance(
                typeof(int),
                new int[1] { arr.Length - 1 },
                new int[1] { arr.GetLowerBound(0) + 1 }
            );
            Array.Copy(arr, arr.GetLowerBound(0) + 1,
            temp, temp.GetLowerBound(0), temp.Length);
            return 1 + RecuSearch2(temp, value);
        }
    }
    static int SenSearch(int[] arr, int value)
    {
        int x = arr[arr.Length - 1];
        arr[arr.Length - 1] = value;//đặt phần tử canh
        int index = SeqSearch(arr, value);
        arr[arr.Length - 1] = x;//khôi phục phần tử cuối
        if (index < arr.Length - 1)
            return index;
        else
            if (arr[arr.Length - 1] == value)
                return arr.Length - 1;
            else
                return -1;
    }
    private static void Main(string[] args)
    {
        int[] array = { 3, 7, 5, 9, 1 };
        //int index_by_recu = RecuSearch(array, 0, 9);
        //int index_by_recu2 = RecuSearch2(array, 9);
        //Console.WriteLine($"{index_by_recu}, {index_by_recu2}");
        int index_by_sen = SenSearch(array, 99);
        Console.WriteLine($"{index_by_sen}");
    }
}