

public static class DisplaySums
{
    public static void Run()
    {
        DisplaySumPairs(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { -20, -15, -10, -5, 0, 5, 10, 15, 20 });
        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { 5, 11, 2, -4, 6, 8, -1 });
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
    {
        HashSet<int> seenNumbers = new HashSet<int>();
        HashSet<string> displayedPairs = new HashSet<string>();

        foreach (int number in numbers)
        {
            int complement = 10 - number;
            if (seenNumbers.Contains(complement))
            {
                // Ensure the pair is displayed in a consistent order
                string pair = number < complement ? $"{number} {complement}" : $"{complement} {number}";
                if (!displayedPairs.Contains(pair))
                {
                    Console.WriteLine(pair);
                    displayedPairs.Add(pair);
                }
            }
            seenNumbers.Add(number);
        }
    }
}