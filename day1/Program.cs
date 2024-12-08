//day 1
string[] pairsFile = File.ReadAllLines("list.txt");

int[] puzzleLeft = new int[pairsFile.Length];
int[] puzzleRight = new int[pairsFile.Length];

for (int i = 0; i < pairsFile.Length; i++)
{
    string[] toPairs = pairsFile[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    puzzleLeft[i] = int.Parse(toPairs[0].Trim());
    puzzleRight[i] = int.Parse(toPairs[1].Trim());
}

Array.Sort(puzzleLeft);
Array.Sort(puzzleRight);

int sumOfDiff = 0;

for (int i = 0; i < puzzleLeft.Length; i++)
{
    sumOfDiff += puzzleLeft[i] > puzzleRight[i]
    ? puzzleLeft[i] - puzzleRight[i]
    : puzzleRight[i] - puzzleLeft[i];
}

System.Console.WriteLine(sumOfDiff);