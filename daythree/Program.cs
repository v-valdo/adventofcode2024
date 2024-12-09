string mulBig = File.ReadAllText("mul.txt");

string ex = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

int totalSum = 0;

int mulStartIndex = mulBig.IndexOf("mul(");

while (mulStartIndex != -1)
{
    int mulEndIndex = mulBig.IndexOf(")", mulStartIndex);

    if (mulEndIndex == -1)
    {
        break;
    }

    string potentialMul = mulBig.Substring(mulStartIndex, mulEndIndex - mulStartIndex + 1);
    var (valid, x, y) = CheckShenanigans(potentialMul);

    if (valid)
    {
        System.Console.WriteLine(potentialMul);
        totalSum += x * y;
        mulStartIndex = mulBig.IndexOf("mul(", mulEndIndex + 1);
    }
    else
    {
        mulStartIndex = mulBig.IndexOf("mul(", mulStartIndex + 1);
    }
}

Console.WriteLine(totalSum);

Tuple<bool, int, int> CheckShenanigans(string mulMethod)
{
    if (!mulMethod.StartsWith("mul(") || !mulMethod.EndsWith(")"))
    {
        return Tuple.Create(false, 0, 0);
    }

    int parOne = mulMethod.IndexOf("(");
    int parTwo = mulMethod.LastIndexOf(")");

    string numbers = mulMethod.Substring(parOne + 1, parTwo - parOne - 1);

    string[] numParts = numbers.Split(',');

    if (numParts.Length == 2
    && int.TryParse(numParts[0], out int x)
    && int.TryParse(numParts[1], out int y))
    {
        return Tuple.Create(true, x, y);
    }
    return Tuple.Create(false, 0, 0);
}
