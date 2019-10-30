


using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{

    public class Maze
    {
        private int size;                 // dimension of maze
        private bool[,] north;     // is there a wall to north of cell i, j
        private bool[,] east;
        private bool[,] south;
        private bool[,] west;
        private bool[,] visited;
        private bool done = false;



        public Maze(int n)
        {
            this.size = n;
            /*StdDraw.setXscale(0, n+2);
            StdDraw.setYscale(0, n+2);*/
            Initialize();
            generate();
        }

        private void Initialize()
        {
            // initialize border cells as already visited
            visited = new bool[size + 2, size + 2];
            for (int x = 0; x < size + 2; x++)
            {
                visited[x,0] = true;
                visited[x,size + 1] = true;
            }
            for (int y = 0; y < size + 2; y++)
            {
                visited[0,y] = true;
                visited[size + 1,y] = true;
            }


            // initialze all walls as present
            north = new bool[size + 2, size + 2];
            east = new bool[size + 2, size + 2];
            south = new bool[size + 2, size + 2];
            west = new bool[size + 2, size + 2];
            for (int x = 0; x < size + 2; x++)
            {
                for (int y = 0; y < size + 2; y++)
                {
                    north[x, y] = true;
                    east[x, y] = true;
                    south[x, y] = true;
                    west[x, y] = true;
                }
            }
        }


        // generate the maze
        private void generate(int x, int y)
        {
            visited[x, y] = true;
            Random rand = new Random();

            // while there is an unvisited neighbor
            while (!visited[x,y + 1] || !visited[x + 1,y] || !visited[x,y - 1] || !visited[x - 1,y])
            {

                // pick random neighbor (could use Knuth's trick instead)
                Random random = new Random();
                while (true)
                {
                    // double r = StdRandom.uniform(4);
                    int r = random.Next(4);
                    if (r == 0 && !visited[x,y + 1])
                    {
                        north[x,y] = false;
                        south[x,y + 1] = false;
                        generate(x, y + 1);
                        break;
                    }
                    else if (r == 1 && !visited[x + 1,y])
                    {
                        east[x,y] = false;
                        west[x + 1,y] = false;
                        generate(x + 1, y);
                        break;
                    }
                    else if (r == 2 && !visited[x,y - 1])
                    {
                        south[x,y] = false;
                        north[x,y - 1] = false;
                        generate(x, y - 1);
                        break;
                    }
                    else if (r == 3 && !visited[x - 1,y])
                    {
                        west[x,y] = false;
                        east[x - 1,y] = false;
                        generate(x - 1, y);
                        break;
                    }
                }
            }
        }

        // generate the maze starting from lower left
        private void generate()
        {
            generate(1, 1);

            Random random = new Random();
            //delete some random walls
            for (int i = 0; i < size; i++)
            {
                int x = 1 + random.Next(size - 1);
                int y = 1 + random.Next(size - 1);
                north[x,y] = south[x,y + 1] = false;
            }

        }


        // draw the maze
        public string[,] draw()
        {
            /* StdDraw.setPenColor(StdDraw.RED);
             StdDraw.filledCircle(n/2.0 + 0.5, n/2.0 + 0.5, 0.375);
             StdDraw.filledCircle(1.5, 1.5, 0.375);


             StdDraw.setPenColor(StdDraw.BLACK);*/

            string[,] wallLocations = new string[size,size];
            // for (int row =0; row <n; row++){
            for (int x = 1; x <= size; x++)
            {
                //for (int col= 0; col<n;col++){
                for (int y = 1; y <= size; y++)
                {
                    StringBuilder wallLocationsstring = new StringBuilder();
                    if (south[x,y])
                    {//StdDraw.line(x, y, x+1, y);
                        wallLocationsstring.Append('S');
                    }
                    if (north[x,y])
                    {//StdDraw.line(x, y+1, x+1, y+1);
                        wallLocationsstring.Append('N');
                    }
                    if (west[x,y])
                    {//StdDraw.line(x, y, x, y+1);
                        wallLocationsstring.Append('W');
                    }
                    if (east[x,y])
                    {
                        //StdDraw.line(x + 1, y, x + 1, y + 1);
                        wallLocationsstring.Append('E');
                    }
                    //System.out.println(wallLocationsstring.tostring().toCharArray());
                    wallLocations[x - 1,y - 1] = wallLocationsstring.ToString();

                }
                // }
            }
            //}

            //System.out.println(Arrays.deepTostring(wallLocations));

            //System.out.println(theTestDungeon);
            /* StdDraw.show();
             StdDraw.pause(1000);*/
            return wallLocations;
        }




        // a test client
        public static void Main(string[] args)
        {
            int n = 3;
            Maze maze = new Maze(n);



        }

        private string[,] convertWallLocationsToDungeonformat(string[,] wallLocations)
        {

            List<string> formatted = new List<string>();


            for (int colUnformatted = size - 1; colUnformatted >= 0; colUnformatted--)
            {
                for (int rowUnformatted = 0; rowUnformatted < size; rowUnformatted++)
                {
                    formatted.Add(wallLocations[rowUnformatted,colUnformatted]);
                }
            }

            string[,] formattedWallLocations = new string[size,size];

            int i = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    formattedWallLocations[row,col] = formatted[i];
                    i++;
                }
            }
            //System.out.println(Arrays.deepTostring(formattedWallLocations));

            return formattedWallLocations;

        }

        public string[,] getWalls()
        {
            string[,] wallLocations = this.draw();
            string[,] wallLocationsRCformat = this.convertWallLocationsToDungeonformat(wallLocations);
            return wallLocationsRCformat;
        }
    }
}