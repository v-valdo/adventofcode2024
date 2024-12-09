using problems;

string[] file = File.ReadAllLines("list.txt");

int[] puzzleLeft = new int[file.Length];
int[] puzzleRight = new int[file.Length];

for (int i = 0; i < file.Length; i++)
{
    string[] toPairs = file[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    puzzleLeft[i] = int.Parse(toPairs[0].Trim());
    puzzleRight[i] = int.Parse(toPairs[1].Trim());
}

Array.Sort(puzzleLeft);
Array.Sort(puzzleRight);

//day 1
WriteLine("Day 1 sln: " + Problems.DayOne(puzzleLeft, puzzleRight));
//day2
WriteLine("Day 2 sln: " + Problems.DayTwo(puzzleLeft, puzzleRight));
