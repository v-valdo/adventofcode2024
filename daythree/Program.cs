using System.Text.RegularExpressions;

string mulBig = File.ReadAllText("mul.txt");

int PartOne = 1;
int PartTwo = 2;

Go(PartOne);

Go(PartTwo);


void Go(int pt)
{
    int sum = 0;

    bool isEnabled = true;

    Regex regex = new(@"mul\((\d+),(\d+)\)|do\(\)|don't\(\)");

    var matches = regex.Matches(mulBig);

    foreach (Match match in matches)
    {
        if (match.Value == "do()")
        {
            if (pt == 2)
                isEnabled = true;
        }
        else if (match.Value == "don't()")
        {
            if (pt == 2)
                isEnabled = false;
        }
        else if (match.Value.StartsWith("mul(") && isEnabled)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            sum += x * y;
        }
    }

    Console.WriteLine("part " + pt + " result: " + sum);
}