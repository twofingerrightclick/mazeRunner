using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PrintMazeToConsole()
        {
            Maze.Maze maze = new Maze.Maze(4);
            System.Console.Write(maze);
        }

        

    }
}
