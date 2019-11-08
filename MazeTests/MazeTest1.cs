using Maze;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MazeTests
{
    [TestClass]
    public class MazeTest1
    {



        [TestMethod]
        public void PrintTestMaze()
        {
            int n = 3;
            MazeStructure maze = new MazeStructure(n);
            //maze.testDraw();

            maze.testDraw();



        }

        [TestMethod]
        public void North_South_Questions_Are_The_Same_On_Either_Side_Of_Door()
        {
            int n = 3;
            MazeStructure maze = new MazeStructure(n);
            //maze.testDraw();

            maze.testDraw();

            for (int i = 1; i < maze.size; i++)
            {
                for (int j = 0; j < maze.size; j++)
                {
                    if (maze.ValidIndex(i - 1))
                    {
                        if (!maze.NorthWall[i, j])
                        {
                            Console.WriteLine($"({i},{j}) north question {maze.NorthQuestion[i, j].number} matches south question {maze.SouthQuestion[i - 1, j].number} of ({i - 1},{j})");
                            Assert.IsTrue(ReferenceEquals(maze.NorthQuestion[i, j], maze.SouthQuestion[i - 1, j]));
                           
                        }
                    }
                }
            }





        }






        [TestMethod]
        public void East_West_Questions_Are_The_Same_On_Either_Side_Of_Door()
        {
            int n = 3;
            MazeStructure maze = new MazeStructure(n);
            //maze.testDraw();

            maze.testDraw();

            for (int i = 1; i < maze.size; i++)
            {
                for (int j = 0; j < maze.size; j++)
                {
                    if (maze.ValidIndex(j + 1))
                    {
                        if (!maze.EastWall[i, j])
                        {
                            Console.WriteLine($"({i},{j}) east question {maze.EastQuestion[i, j].number} matches west question {maze.WestQuestion[i, j + 1].number} of ({i},{j + 1})");
                            Assert.IsTrue(ReferenceEquals(maze.EastQuestion[i, j], maze.WestQuestion[i, j + 1]));
                           
                        }
                    }
                }
            }





        }




    }
}
