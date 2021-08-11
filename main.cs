using System;
using System.Linq;
using System.IO;

namespace ClickingGame64
{
    class _main
    {
        public static int clicks;

        public static void Main()
        {
            if (File.Exists("save.cg64"))
            {
                try
                {
                    clicks = int.Parse(File.ReadAllLines("save.cg64").First());
                }
                catch (IOException e)
                {
                    Console.WriteLine("Oh no! We caught an error, possibly in the savegame feature. \n\n" + e.ToString());
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                finally
                {
                    ClickingGame64();
                }
            }
            else
            {
                try
                {
                    File.WriteAllText("save.cg64", "0");
                    clicks = int.Parse(File.ReadAllLines("save.cg64").First());
                }
                catch (IOException e)
                {
                    Console.WriteLine("Oh no! We caught an error, possibly in the savegame feature. \n\n" + e.ToString());
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                finally
                {
                    ClickingGame64();
                }

            }
        }

        public static void ClickingGame64()
        {
            Console.Clear();

            Console.WriteLine("ClickingGame64 - ESC = Save & Quit / Any = Click! - pspsps#7677 * Apache-2.0\n" +
                $"Clicks = {clicks}");

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                try
                {
                    File.WriteAllText("save.cg64", clicks.ToString());
                }
                catch (IOException e)
                {
                    Console.Clear();
                    Console.WriteLine("Oh no! We caught an error, possibly in the savegame feature. \n\n" + e.ToString());
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                finally
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                clicks++;
                ClickingGame64();
            }
        }
    }
}