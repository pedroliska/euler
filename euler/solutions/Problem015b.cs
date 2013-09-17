using System;

namespace euler.solutions
{
    /// <summary>
    /// I took the dynamic programming idea from here
    /// http://www.mathblog.dk/project-euler-15/
    /// But I avoided looking at the code implementation so I could
    /// come up with my own
    /// </summary>
    public class Problem015b
    {
        public static void Run()
        {
            int gridSize = 20;

            Timer.RecordMiliseconds(() =>
            {
                var pathsGrid = new long[gridSize + 1,gridSize + 1];

                // set up the boundaries
                for (int i = 0; i < gridSize; i++)
                {
                    pathsGrid[gridSize, i] = 1;
                    pathsGrid[i, gridSize] = 1;
                }

                // calculate the other grid elements
                for (int x = gridSize - 1; x >= 0; x --)
                    for (int y = gridSize - 1; y >= 0; y--)
                        pathsGrid[x, y] = pathsGrid[x + 1, y] + pathsGrid[x, y + 1];

                Console.WriteLine("There are {0} Lattice paths on a {1}x{1} grid.", pathsGrid[0, 0], gridSize);
            });
        }
    }
}