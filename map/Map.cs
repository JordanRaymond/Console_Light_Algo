using System;
using System.Collections.Generic;

namespace light_map
{
    public enum TileType { wall, dark, light, lith }

    public struct Coord
    {
        public int x;
        public int y;

        public Coord(int p_x, int p_y)
        {
            x = p_x;
            y = p_y;
        }
    }
    public class Map
    {
        public Tile[,] map;
        public List<Tile> lights = new List<Tile>();
        public List<Tile> walls = new List<Tile>();
        private int width = 1;
        private int height = 1;

        public Map(int p_width, int p_height)
        {
            width = p_width;
            height = p_height;

            map = new Tile[width + 2, height + 2];
            Init();
        }

        public void Draw()
        {

            HandleLight();
            for (int h = height; h >= 0; h--)
            {
                for (int w = 0; w <= width; w++)
                {
                    Console.Write(map[w, h].Draw() + " ");
                }

                Console.Write("\n");
            }
        }

        private void HandleLight()
        {
            foreach (var light in lights)
            {
                ShootRayEverywhere(light);
            }
        }

        private void ShootRayEverywhere(Tile light)
        {
            Coord lightOrigin = new Coord((int)light.x, (int)light.y);
            LithBottom(lightOrigin);
            LithTop(lightOrigin);
            LithRight(lightOrigin);
            LithLeft(lightOrigin);
        }

        private void LithBottom(Coord lightCoord)
        {
            LithOnX(lightCoord, 0);
        }

        private void LithRight(Coord lightCoord)
        {
            LithSide(lightCoord, width);
        }

        private void LithLeft(Coord lightCoord)
        {
            LithSide(lightCoord, 0);
        }

        private void LithSide(Coord lightCoord, int xOrignie)
        {
            for (int y = 0; y <= height; y++)
            {
                Line line = new Line(lightCoord, new Coord(xOrignie, y));
                List<Tile> lineTiles = line.GetTiles();

                if (lineTiles[0].x == lightCoord.x && lineTiles[0].y == lightCoord.y)
                {
                    for (int i = 1; i < lineTiles.Count; i++)
                    {
                        Tile currentTile = map[(int)lineTiles[i].x, (int)lineTiles[i].y];
                        if (currentTile.type != TileType.wall)
                        {
                            currentTile.type = TileType.lith;
                        }
                        else break;
                    }
                }
                else
                {
                    for (int i = lineTiles.Count - 2; i >= 0; i--)
                    {
                        Tile currentTile = map[(int)lineTiles[i].x, (int)lineTiles[i].y];

                        if (currentTile.type != TileType.wall)
                        {
                            currentTile.type = TileType.lith;
                        }
                        else break;
                    }
                }
            }
        }

        private void LithTop(Coord lightCoord)
        {
            LithOnX(lightCoord, height);
        }

        private void LithOnX(Coord lightCoord, int yPosition)
        {
            for (int x = 0; x <= width; x++)
            {
                Line line = new Line(lightCoord, new Coord(x, yPosition));
                List<Tile> lineTiles = line.GetTiles();

                if (lineTiles[0].x == lightCoord.x && lineTiles[0].y == lightCoord.y)
                {
                    for (int i = 1; i < lineTiles.Count; i++)
                    {
                        Tile currentTile = map[(int)lineTiles[i].x, (int)lineTiles[i].y];
                        if (currentTile.type != TileType.wall)
                        {
                            currentTile.type = TileType.lith;
                        }
                        else break;
                    }
                }
                else
                {
                    for (int i = lineTiles.Count - 2; i >= 0; i--)
                    {
                        Tile currentTile = map[(int)lineTiles[i].x, (int)lineTiles[i].y];

                        if (currentTile.type != TileType.wall)
                        {
                            currentTile.type = TileType.lith;
                        }
                        else break;
                    }
                }
            }
        }



        public void SetWall(int x, int y)
        {
            SetTile(x, y, TileType.wall);
            walls.Add(map[x, y]);

        }

        public void SetLight(int x, int y)
        {
            SetTile(x, y, TileType.light);
            lights.Add(map[x, y]);
        }

        private void SetTile(int x, int y, TileType tileType)
        {
            if ((x < 0 || x > width) || (y < 0 || y > height))
            {
                Console.WriteLine("Invalide cords");
            }

            // Console.WriteLine("SetTile x: " + x + " y: " + y);
            map[x, y].type = tileType;
        }

        private void Init(TileType defaultType = TileType.dark)
        {
            for (int h = height; h >= 0; h--)
            {
                for (int w = 0; w <= width; w++)
                {
                    map[w, h] = new Tile(w, h, defaultType);
                }
            }
        }
    }
}
