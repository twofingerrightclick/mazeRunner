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
        public void Questions_Are_The_Same_On_Either_Side_Of_Door()
        {
            int n = 3;
            MazeStructure maze = new MazeStructure(n);
            //maze.testDraw();

            maze.testDraw();

            for (int i = 0; i < maze.size; i++)
            {
                for (int j = 0; j < maze.size; j++)
                {
                    if (maze.ValidInput(i + 1))
                    {
                        if (!maze.NorthWall[i, j] && !maze.SouthWall[i + 1, j])
                        {
                            Console.WriteLine($"({i},{j}) north question matches ({i + 1},{j})");
                            Assert.IsTrue(maze.NorthQuestion[i, j].Equals(maze.SouthQuestion[i + 1, j]));
                        }
                    }
                }
            }

            



        }




    }
}
