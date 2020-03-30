namespace light_map
{
    public class Tile
    {
        public TileType type = TileType.dark;
        public float lightLvl = 0;
        public double x = 0;
        public double y = 0;

        public Tile(double p_x, double p_y, TileType tileType = TileType.lith)
        {
            x = p_x;
            y = p_y;
            type = tileType;
        }

        public char Draw()
        {
            switch (type)
            {
                case TileType.dark:
                    return '░';
                case TileType.lith:
                    return '▓';
                case TileType.light:
                    return 'L';
                case TileType.wall:
                    return '■';
                default:
                    return '?';
            }
        }
    }
}
