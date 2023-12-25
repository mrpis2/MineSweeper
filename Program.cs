class Program
{
    static void Main(string[] args)
    {
        string[,] array = {
            {"*", ".", ".", "."},
            {".", ".", ".", "."},
            {".", "*", ".", "."},
            {".", ".", ".", "."}
        };
        int height = array.GetLength(0);
        int width = array.GetLength(1);

        string[,] mapReport = new string[height, width];
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                string curentCell = array[x, y];
                if (curentCell.Equals("*"))
                {
                    mapReport[x, y] = "*";
                }
                else
                {
                    int[,] NEIGHBOURS_ORDINATE = {
                        {x - 1, y - 1}, {x - 1, y}, {x - 1, y + 1},
                        {x, y - 1}, {x, y + 1},
                        {x + 1, y - 1}, {x + 1, y}, {x + 1, y + 1},};

                    int minesAround = 0;
                    int length = NEIGHBOURS_ORDINATE.GetLength(0);
                    for (int i = 0; i < length; i++)
                    {
                        int xOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 1];
                        int yOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 0];

                        bool isOutOfMapNeighbour = xOrdinateOfNeighbour < 0
                                || xOrdinateOfNeighbour == width
                                || yOrdinateOfNeighbour < 0
                                || yOrdinateOfNeighbour == height;
                        if (isOutOfMapNeighbour)
                        {
                            continue;
                        }

                        bool isMineOwnerNeighbour = array[yOrdinateOfNeighbour, xOrdinateOfNeighbour].Equals("*");
                        if (isMineOwnerNeighbour)
                        {
                            minesAround++;
                        }
                    }

                    mapReport[x, y] = minesAround.ToString();
                }
            }
        }

        for (int yOrdinate = 0; yOrdinate < height; yOrdinate++)
        {
            Console.WriteLine("\n");
            for (int xOrdinate = 0; xOrdinate < width; xOrdinate++)
            {
                String currentCellReport = mapReport[yOrdinate, xOrdinate];
                Console.Write(currentCellReport);
            }
        }
        Console.ReadLine();
    }
}