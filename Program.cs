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
    static int BinSearch(int[] arr, int value)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] == value)
                return mid;
            else if (arr[mid] < value)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
    static int BinSearch2(int[] arr, int value,
                                    int from, int to)
    {
        int mid = (from + to) / 2;
        if (arr[mid] == value)
            return mid;
        else if (arr[mid] < value)
            return BinSearch2(arr, value, mid + 1, to);
        else
            return BinSearch2(arr, value, from, mid - 1);
    }
    static int TriSearch(int[] arr, int value)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right){
            int mid1 = (left + right) / 3;
            int mid2 = 2 * (left + right) / 3;
            if (arr[mid1] == value)
                return mid1;
            else if (arr[mid2] == value)
                return mid2;
            else if (value < arr[mid1])
                right = mid1 - 1;
            else if (value > arr[mid2])
                left = mid2;  //mid2 + 1;
            else{
                left = mid1; //mid1 + 1;
                right = mid2 - 1;
            }
        }
        return -1;
    }
    private static void Main(string[] args)
    {
        //int[] array = { 3, 7, 5, 9, 1 };
        //int index_by_recu = RecuSearch(array, 0, 9);
        //int index_by_recu2 = RecuSearch2(array, 9);
        //Console.WriteLine($"{index_by_recu}, {index_by_recu2}");
        //int index_by_sen = SenSearch(array, 99);
        //Console.WriteLine($"{index_by_sen}");
        int[] sorted_array = { 1, 3, 5, 7, 9 };
        //int index_by_bin = BinSearch(sorted_array, 7);
        //int index_by_bin2 = BinSearch2(sorted_array, 7, 0, sorted_array.Length - 1);
        //Console.WriteLine($"{index_by_bin}, {index_by_bin}");
        int index_by_tri = TriSearch(sorted_array, 7);
        Console.WriteLine($"Triple: {index_by_tri}");
    }
}