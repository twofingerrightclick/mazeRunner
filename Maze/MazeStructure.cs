﻿


using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{

    public class MazeStructure
    {
        private int size;                 // dimension of maze
        private bool[,] northWall;     // is there a wall to north of cell i, j
        private bool[,] eastWall;
        private bool[,] southWall;
        private bool[,] westWall;

        private bool[,] visited;
        private bool done = false;

        public Question[,] northQuestion;     // is there a wall to north of cell i, j
        public Question[,] eastQuestion;
        public Question[,] southQuestion;
        public Question[,] westQuestion;


        private int[] entranceCoodinates = new int[2];
        private int[] exitCoordinates = new int[2];
        private QuestionFactory questionFactory = new QuestionFactory();
        private Queue<Question> questions;

        public Room[,] _Rooms;

        public string[,] testMaze;

        //gui neeeds to know:
        //walls, questions, location.


        public MazeStructure(int n, params string[] questionArgs)
        {
            questions = questionFactory.getQuestions(questionArgs, (n * n * 4));
            this.size = n;
            /*StdDraw.setXscale(0, n+2);
            StdDraw.setYscale(0, n+2);*/
            _Rooms = new Room[n, n];
            testMaze = new string[n+2, n+2];

            Initialize();
            generate();
            PlaceQuestions();
            //setExits();

        }

        private void PlaceQuestions()
        {



            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!westWall[i, j])
                    {
                        westQuestion[i, j] = questions.Dequeue();
                    }

                    if (!eastWall[i, j])
                    {
                        eastQuestion[i, j] = questions.Dequeue();
                    }
                    if (!northWall[i, j])
                    {
                        northQuestion[i, j] = questions.Dequeue();
                    }
                    if (!southWall[i, j])
                    {
                        southQuestion[i, j] = questions.Dequeue();
                    }



                }

            }
        }

        private void Initialize()
        {
            // initialize border cells as already visited
            visited = new bool[size + 2, size + 2];
            for (int x = 0; x < size + 2; x++)
            {
                visited[x, 0] = true;
                visited[x, size + 1] = true;
            }
            for (int y = 0; y < size + 2; y++)
            {
                visited[0, y] = true;
                visited[size + 1, y] = true;
            }

            northQuestion = new Question[size + 2, size + 2];
            eastQuestion = new Question[size + 2, size + 2];
            southQuestion = new Question[size + 2, size + 2];
            westQuestion = new Question[size + 2, size + 2];

            // initialze all walls as present
            northWall = new bool[size + 2, size + 2];
            eastWall = new bool[size + 2, size + 2];
            southWall = new bool[size + 2, size + 2];
            westWall = new bool[size + 2, size + 2];
            for (int x = 0; x < size + 2; x++)
            {
                for (int y = 0; y < size + 2; y++)
                {
                    northWall[x, y] = true;
                    eastWall[x, y] = true;
                    southWall[x, y] = true;
                    westWall[x, y] = true;
                }
            }
        }


        // generate the maze
        private void generate(int x, int y)
        {
            visited[x, y] = true;
            Random rand = new Random();

            // while there is an unvisited neighbor
            while (!visited[x, y + 1] || !visited[x + 1, y] || !visited[x, y - 1] || !visited[x - 1, y])
            {

                // pick random neighbor (could use Knuth's trick instead)
                Random random = new Random();
                while (true)
                {
                    // double r = StdRandom.uniform(4);
                    int r = random.Next(4);
                    if (r == 0 && !visited[x, y + 1])
                    {
                        northWall[x, y] = false;
                        southWall[x, y + 1] = false;
                        generate(x, y + 1);
                        break;
                    }
                    else if (r == 1 && !visited[x + 1, y])
                    {
                        eastWall[x, y] = false;
                        westWall[x + 1, y] = false;
                        generate(x + 1, y);
                        break;
                    }
                    else if (r == 2 && !visited[x, y - 1])
                    {
                        southWall[x, y] = false;
                        northWall[x, y - 1] = false;
                        generate(x, y - 1);
                        break;
                    }
                    else if (r == 3 && !visited[x - 1, y])
                    {
                        westWall[x, y] = false;
                        eastWall[x - 1, y] = false;
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
                northWall[x, y] = southWall[x, y + 1] = false;
            }

        }

        private void setExits()
        {
            Random randomInt = new Random();
            entranceCoodinates[0] = randomInt.Next(size / 2);
            entranceCoodinates[1] = randomInt.Next(size / 2);

            int boundaryFactor;
            if (size % 2 == 0)
            {
                boundaryFactor = (size / 2) - 1;
            }
            else boundaryFactor = size / 2;
            int exitX;
            int exitY = randomInt.Next(size / 2) + boundaryFactor;
            do
            {
                exitX = randomInt.Next(size / 2) + boundaryFactor;
            }
            while (exitX == entranceCoodinates[0]);

            exitCoordinates[0] = exitX;
            exitCoordinates[1] = exitY;
        }

        // draw the maze
        public string[,] draw()
        {
            /* StdDraw.setPenColor(StdDraw.RED);
             StdDraw.filledCircle(n/2.0 + 0.5, n/2.0 + 0.5, 0.375);
             StdDraw.filledCircle(1.5, 1.5, 0.375);


             StdDraw.setPenColor(StdDraw.BLACK);*/

            string[,] wallLocations = new string[size, size];
            // for (int row =0; row <n; row++){
            for (int x = 1; x <= size; x++)
            {
                //for (int col= 0; col<n;col++){
                for (int y = 1; y <= size; y++)
                {
                    StringBuilder wallLocationsstring = new StringBuilder();
                    if (southWall[x, y])
                    {//StdDraw.line(x, y, x+1, y);
                        wallLocationsstring.Append('S');
                    }
                    if (northWall[x, y])
                    {//StdDraw.line(x, y+1, x+1, y+1);
                        wallLocationsstring.Append('N');
                    }
                    if (westWall[x, y])
                    {//StdDraw.line(x, y, x, y+1);
                        wallLocationsstring.Append('W');
                    }
                    if (eastWall[x, y])
                    {
                        //StdDraw.line(x + 1, y, x + 1, y + 1);
                        wallLocationsstring.Append('E');
                    }
                    //System.out.println(wallLocationsstring.tostring().toCharArray());
                    wallLocations[x - 1, y - 1] = wallLocationsstring.ToString();

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


        public void testDraw()
        {
            /* StdDraw.setPenColor(StdDraw.RED);
             StdDraw.filledCircle(n/2.0 + 0.5, n/2.0 + 0.5, 0.375);
             StdDraw.filledCircle(1.5, 1.5, 0.375);


             StdDraw.setPenColor(StdDraw.BLACK);*/

            
            // for (int row =0; row <n; row++){
            for (int x = 1; x <= size; x++)
            {
                //for (int col= 0; col<n;col++){
                for (int y = 1; y <= size; y++)
                {
                    Console.Write($"({ x - 1},{y - 1}) has: ");
                    if (southWall[x, y])
                    {//StdDraw.line(x, y, x+1, y);
                        testMaze[x - 1, y] = "*";
                        Console.Write("southWall, ");
                    }
                    else
                    {
                        testMaze[x - 1, y] = "?";
                        Console.Write("south ?, ");
                    }
                    
                    
                    if (northWall[x, y])
                    {//StdDraw.line(x, y+1, x+1, y+1);
                        testMaze[x + 1, y] = "*";
                        Console.Write("northWall, ");
                    }
                    else
                    {
                        Console.Write("north ?, ");
                    }
                    
                    
                    if (westWall[x, y])
                    {//StdDraw.line(x, y, x, y+1);
                        testMaze[x, y - 1] = "*";
                        Console.Write("westWall, ");
                    }
                    else
                    {
                        testMaze[x, y - 1] = "?";
                        Console.Write("west ?, ");
                    }
                    
                    
                    if (eastWall[x, y])
                    {
                        //StdDraw.line(x + 1, y, x + 1, y + 1);
                        testMaze[x, y + 1] = "*";
                        Console.Write("eastWall, ");
                    }
                    else
                    {
                        testMaze[x, y + 1] = "?";
                        Console.Write("east ?, ");
                    }


                }
                Console.WriteLine();
                // }
            }

            //Print2DArray(testMaze);
        }

            // a test client
            public static void Main(string[] args)
        {
            int n = 3;
            MazeStructure maze = new MazeStructure(n);
            maze.testDraw();
    

        }

        private string[,] convertWallLocationsToDungeonformat(string[,] wallLocations)
        {

            List<string> formatted = new List<string>();


            for (int colUnformatted = size - 1; colUnformatted >= 0; colUnformatted--)
            {
                for (int rowUnformatted = 0; rowUnformatted < size; rowUnformatted++)
                {
                    formatted.Add(wallLocations[rowUnformatted, colUnformatted]);
                }
            }

            string[,] formattedWallLocations = new string[size, size];

            int i = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    formattedWallLocations[row, col] = formatted[i];
                    i++;
                }
            }
            

            return formattedWallLocations;

        }

        public string[,] getWalls()
        {
            string[,] wallLocations = this.draw();
            string[,] wallLocationsRCformat = this.convertWallLocationsToDungeonformat(wallLocations);
            Print2DArray(wallLocationsRCformat);
            return wallLocationsRCformat;
        }


        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}