using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;
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
    



    }
}
