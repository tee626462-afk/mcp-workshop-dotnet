using System;
using McpTodoServer.ContainerApp.Models;
using System.Linq;

namespace McpTodoServer.ContainerApp.Tools
{
    public class MonkeyConsoleApp
    {
  (•ㅅ•)
  / 　 づ  - 귀여운 토끼 원숭이!",
    \__(-)    __)
        /     (
       (      )
        `----'  - 원숭이 점프!",
        / .===. \\
        \\/ 6 6 \\/
        ( \\___/ )
    ___ooo__ooo___  - 원숭이 얼굴!"
        private static readonly string[][] AsciiArts = new[]
        {
            new[] {
                "   __,=\"__,",
                "  ( o o )",
                "  /  V  \",
                " /--m-m-\\",
                "   Monkey!"
            },
            new[] {
                "   .-\"\"\"-.",
                "  / .===. \\",
                "  \\/ 0 0 \\/",
                "  ( \\___/ )",
                "___ooo__ooo___"
            },
            new[] {
                "   ( )__( )",
                "   (=\'.\'=)",
                "   (\")_ (\")",
                "   Monkey Power!"
            }
        };

        public static void Run()
        {
            var rand = new Random();
            while (true)
            {
                Console.Clear();
                var art = AsciiArts[rand.Next(AsciiArts.Length)];
                Console.WriteLine(string.Join("\n", art));
                Console.WriteLine("\n==== Monkey Menu ====");
                Console.WriteLine("1. List all monkeys");
                Console.WriteLine("2. Get details for a specific monkey by name");
                Console.WriteLine("3. Get a random monkey");
                Console.WriteLine("4. Exit app");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("-- All Monkeys --");
                        foreach (var m in MonkeyHelper.GetAllMonkeys())
                        {
                            Console.WriteLine($"{m.Id}: {m.Name} ({m.Species}), Age: {m.Age}, Desc: {m.Description}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter monkey name: ");
                        var name = Console.ReadLine();
                        var found = MonkeyHelper.FindMonkeyByName(name);
                        if (found != null)
                        {
                            Console.WriteLine($"Id: {found.Id}\nName: {found.Name}\nSpecies: {found.Species}\nAge: {found.Age}\nDescription: {found.Description}");
                        }
                        else
                        {
                            Console.WriteLine("Monkey not found!");
                        }
                        break;
                    case "3":
                        var randomMonkey = MonkeyHelper.GetRandomMonkey();
                        Console.WriteLine("-- Random Monkey --");
                        Console.WriteLine($"Id: {randomMonkey.Id}\nName: {randomMonkey.Name}\nSpecies: {randomMonkey.Species}\nAge: {randomMonkey.Age}\nDescription: {randomMonkey.Description}");
                        Console.WriteLine($"Random monkey picked {MonkeyHelper.GetRandomAccessCount()} times.");
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
