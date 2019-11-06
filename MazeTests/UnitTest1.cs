using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;
namespace MazeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PrintMazeToConsole()
        {
            Maze.Maze maze = new Maze.Maze(5);
            Room r = maze.getRoom(1, 1);
            //maze.MakeMock();
            //Room testRoom = new Room();
            //string test = maze.getRoom(0, 0).getRoomRowasString(1);
            //System.Console.Write(maze);
            System.Console.WriteLine(maze);
        }



    }
}
