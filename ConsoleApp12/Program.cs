using System.ComponentModel;
using Enums;
class Program
{
    
    public static Compass CurrentDirection { get; set; }

    public static int X { get; set; }

    public static int Y { get; set; }


    static void Main()
    {
        string filePath = "C:/Users/kirah.cox/source/repos/ConsoleApp12/ConsoleApp12/input.txt";
        List<string> file = File.ReadAllText(filePath).Split(',').ToList();

        CurrentDirection = Compass.North;
        X = 0;
        Y = 0;

        List<string> coordinates = new List<string>();


        foreach (var step in file)
        {
            string trimmed = step.Trim();
            UpdateDirection(trimmed[0]);

            string letterRemoved = trimmed.Substring(1);
            Move(letterRemoved);

            //320 is too high

            if (coordinates.Contains($"{X}:{Y},"))
            {
                int result = Math.Abs(X) + Math.Abs(Y);
                Console.WriteLine(result);
                break;
            }
            else
            {
                coordinates.Add($"{X}:{Y},");
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

    public static void Move(string letterRemoved)
    {
        int steps = int.Parse(letterRemoved);

        switch (CurrentDirection)
        {
            
            case Compass.North:
                Y += steps;
                break;
            case Compass.East:
                X += steps;
                break;
            case Compass.South:
                Y -= steps;
                break;
            case Compass.West:
                X -= steps;
                break;
        }
    }
}
