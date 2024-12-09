string[] file = File.ReadAllLines("reports.txt");

int safeReports = 0;

foreach (string line in file)
{
    string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    bool safeRow = true;
    bool? isIncreasing = null;

    for (int i = 0; i < numbers.Length - 1; i++)
    {
        if (int.TryParse(numbers[i], out int first) &&
            int.TryParse(numbers[i + 1], out int next))
        {
            if (!CheckSafe(first, next))
            {
                safeRow = false;
                break;
            }

            if (isIncreasing == null)
            {
                isIncreasing = first < next;
            }
            else if ((isIncreasing == true && first > next)
            || (isIncreasing == false && first < next))
            {
                safeRow = false;
                break;
            }
        }
    }

    if (safeRow)
    {
        safeReports++;
    }
}

System.Console.WriteLine(safeReports);

bool CheckSafe(int num, int nextNum)
{
    return !(num == nextNum || Math.Abs(num - nextNum) > 3);
}