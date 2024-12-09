string[] file = File.ReadAllLines("reports.txt");

int safeReports = 0;

foreach (string line in file)
{
    string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    bool safeRow = false;

    if (CheckSafeRow(numbers))
    {
        safeRow = true;
    }

    else
    {
        var numList = numbers.ToList();

        for (int i = 0; i < numList.Count; i++)
        {
            List<string> dampenList = [.. numList];

            dampenList.RemoveAt(i);

            if (CheckSafeRow(dampenList.ToArray()))
            {
                safeRow = true;
                break;
            }
        }
    }

    if (safeRow)
    {
        safeReports++;
    }
}

Console.WriteLine(safeReports);

bool CheckSafePair(int num, int nextNum)
{
    return !(num == nextNum || Math.Abs(num - nextNum) > 3);
}

bool CheckSafeRow(string[] nums)
{
    bool? increasing = null;

    for (int i = 0; i < nums.Length - 1; i++)
    {
        if (int.TryParse(nums[i], out int first) &&
            int.TryParse(nums[i + 1], out int next))
        {
            if (!CheckSafePair(first, next))
            {
                return false;
            }

            if (increasing == null)
            {
                increasing = first < next;
            }
            else if ((increasing == true && first > next)
            || (increasing == false && first < next))
            {
                return false;
            }
        }
    }
    return true;
}