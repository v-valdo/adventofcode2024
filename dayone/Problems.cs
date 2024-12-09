namespace problems;

public static class Problems
{
    public static int DayOne(int[] puzzleLeft, int[] puzzleRight)
    {
        //day 1
        int sumOfDiff = 0;

        for (int i = 0; i < puzzleLeft.Length; i++)
        {
            sumOfDiff += puzzleLeft[i] > puzzleRight[i]
            ? puzzleLeft[i] - puzzleRight[i]
            : puzzleRight[i] - puzzleLeft[i];
        }

        return sumOfDiff;
    }

    public static int DayOnePtTwo(int[] puzzleLeft, int[] puzzleRight)
    {
        int sum = 0;
        for (int i = 0; i < puzzleLeft.Length; i++)
        {
            sum += puzzleLeft[i] * puzzleRight.Count(pr => pr == puzzleLeft[i]);
        }
        return sum;
    }
}
