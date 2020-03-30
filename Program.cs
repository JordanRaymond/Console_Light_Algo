using System;

// Made by: Jordan Raymond
// jrdnraymond@gmail.com
// part of challenges my friend gave me 
// while in quarentine of the COVID-19
namespace light_map
{
    class Program
    {
        const int w = 50, h = 50;

        static void Main(string[] args)
        {
            int lX = 10, lY = 10; // Light coords
            Map map = new Map(w, h);

            // To test the line algo, uncoment and comment the ReadKey;
            // Line line = new Line(new Coord(1, 1), new Coord(8, 4));
            // foreach (var tile in line.GetTiles())
            // {
            //     map.SetWall((int)tile.x, (int)tile.y);
            // }

            // map.Draw();
            ReadKey(map, lX, lY);
        }

        static void ReadKey(Map map, int lX, int lY)
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        lX++;
                        break;
                    case ConsoleKey.LeftArrow:
                        lX--;
                        break;
                    case ConsoleKey.UpArrow:
                        lY++;
                        break;
                    case ConsoleKey.DownArrow:
                        lY--;
                        break;
                }
                DrawMap(map, lX, lY);
            } while (key != ConsoleKey.Escape);
        }

        static void DrawMap(Map map, int lX, int lY)
        {
            Console.Clear();
            map = new Map(w, h);
            map.SetWall(7, 13);
            map.SetWall(6, 12);
            map.SetWall(6, 13);

            map.SetWall(13, 13);
            map.SetWall(14, 13);
            map.SetWall(14, 12);

            map.SetWall(7, 6);
            map.SetWall(6, 7);
            map.SetWall(6, 6);

            map.SetWall(13, 6);
            map.SetWall(14, 7);
            map.SetWall(14, 6);

            map.SetWall(25, 40);
            map.SetWall(26, 40);
            map.SetWall(27, 40);

            map.SetLight(lX, lY);

            map.Draw();
        }
    }
}
