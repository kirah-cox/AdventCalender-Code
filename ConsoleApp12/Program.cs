using System.ComponentModel;
using Enums;
class Program
{
    
    public static Compass CurrentDirection { get; set; }

    public static int X { get; set; }

    public static int Y { get; set; }


    static void Main()
    {
        string filePath = "C:\\Users\\kirah\\source\\repos\\kirah-cox\\AdventCalender-Code\\ConsoleApp12\\input.txt";
        List<string> file = File.ReadAllText(filePath).Split(',').ToList();

        CurrentDirection = Compass.North;
        X = 0;
        Y = 0;

        List<string> coordinates = new List<string>();

        bool duplicateFound = false;
        foreach (var step in file)
        {
            string trimmed = step.Trim();
            UpdateDirection(trimmed[0]);

            string letterRemoved = trimmed.Substring(1);

            int numberLength = int.Parse(letterRemoved);

            for (int i = 0; i < numberLength; i++)
            {
                Move();

                if (coordinates.Contains($"{X}:{Y},"))
                {
                    int result = Math.Abs(X) + Math.Abs(Y);
                    Console.WriteLine(result);
                    duplicateFound = true;
                    break;
                }
                else
                {
                    coordinates.Add($"{X}:{Y},");
                }
            }

            if (duplicateFound)
            {
                break;
            }

        }



    }

    public static void UpdateDirection(char direction)
    {
        if (direction == 'R')
        {
            CurrentDirection = (Compass)(((int)CurrentDirection + 1) % 4);
        }
        else
        {
            CurrentDirection = (Compass)(((int)CurrentDirection + 3) % 4);
        }

    }

    public static void Move()
    {

        switch (CurrentDirection)
        {
            
            case Compass.North:
                Y++;
                break;
            case Compass.East:
                X++;
                break;
            case Compass.South:
                Y--;
                break;
            case Compass.West:
                X--;
                break;
        }
    }
}
