using System;
using System.Collections.Generic;

namespace Maze
{
    public class Maze
    {


        public int Size { get; private set; }
        public bool[,] NorthWall { get; private set; }    // is there a wall to north of cell i, j
        public bool[,] EastWall { get; private set; }
        public bool[,] SouthWall { get; private set; }
        public bool[,] WestWall { get; private set; }

        public Question[,] NorthQuestion { get; private set; }    // is there a Question north of cell i, j 
        public Question[,] EastQuestion { get; private set; }
        public Question[,] SouthQuestion { get; private set; }
        public Question[,] WestQuestion { get; private set; }


        public bool[,] RoomDiscovered { get; private set; }



        private (int x, int y) _EntranceCoodinates;
        private (int x, int y) _ExitCoordinates;

        private QuestionFactory _QuestionFactory = new QuestionFactory();




        private Random randomInt = new Random();

        public Maze(int size, params string[] questionArgs)
        {
            if (size < 3)
            {
                throw new ArgumentException("size must be more than 2", nameof(size));
            }

            this.Size = size;

            createMaze(questionArgs);

        }

        private void createMaze(params string[] questionArgs)
        {

            MazeStructure mazeStructure = new MazeStructure(Size, questionArgs);

            CopyMazeStructure(mazeStructure);

            mazeStructure = null; // clean up memory.

            setExits();



        }

        private void CopyMazeStructure(MazeStructure mazeStructure)
        {
            NorthQuestion = mazeStructure.NorthQuestion;
            EastQuestion = mazeStructure.EastQuestion;
            SouthQuestion = mazeStructure.SouthQuestion;
            WestQuestion = mazeStructure.WestQuestion;

            NorthWall = mazeStructure.NorthWall;
            EastWall = mazeStructure.EastWall;
            SouthWall = mazeStructure.SouthWall;
            WestWall = mazeStructure.WestWall;



        }

        private void ChangeQuestion(Question question, params string[] questionArgs)
        {
            question = _QuestionFactory.getQuestions(questionArgs, 1).Dequeue();
        }



        public void ChangeAllQuestions((int x, int y) location, params string[] questionParams)
        {
            Queue<Question> newQuestions = _QuestionFactory.getQuestions(questionParams, Size * Size * 4);

            NorthQuestion = new Question[Size, Size];
            EastQuestion = new Question[Size, Size];
            SouthQuestion = new Question[Size, Size];
            WestQuestion = new Question[Size, Size];



            if (!NorthWall[location.x, location.y])

            {

                if (ValidIndex(location.x - 1) && SouthQuestion[location.x - 1, location.y] != null)
                {

                    NorthQuestion[location.x, location.y] = SouthQuestion[location.x - 1, location.y];

                }
                else
                {
                    NorthQuestion[location.x, location.y] = newQuestions.Dequeue();
                }

            }

            if (!SouthWall[location.x, location.y])

            {

                if (ValidIndex(location.x + 1) && NorthQuestion[location.x + 1, location.y] != null)
                {

                    SouthQuestion[location.x, location.y] = NorthQuestion[location.x + 1, location.y];

                }
                else
                {
                    SouthQuestion[location.x, location.y] = newQuestions.Dequeue();
                }

            }

            if (!EastWall[location.x, location.y])

            {

                if (ValidIndex(location.y + 1) && WestQuestion[location.x, location.y + 1] != null)
                {

                    EastQuestion[location.x, location.y] = WestQuestion[location.x, location.y + 1];

                }
                else
                {
                    EastQuestion[location.x, location.y] = newQuestions.Dequeue();
                }

            }

            if (WestWall[location.x, location.y])

            {

                if (ValidIndex(location.y - 1) && EastQuestion[location.x, location.y - 1] != null)
                {

                    WestQuestion[location.x, location.y] = EastQuestion[location.x, location.y - 1];

                }
                else
                {
                    WestQuestion[location.x, location.y] = newQuestions.Dequeue();
                }

            }
        }

        public void QuestionAnsweredCorrectly(Question question)
        {
            question.Unlock();
        }



        private void setExits()
        {
            _EntranceCoodinates.x = randomInt.Next(Size / 2);
            _EntranceCoodinates.y = randomInt.Next(Size / 2);

            int boundaryFactor;
            if (Size % 2 == 0)
            {
                boundaryFactor = (Size / 2) - 1;
            }
            else boundaryFactor = Size / 2;
            int exitX;
            int exitY = randomInt.Next(Size / 2) + boundaryFactor;
            do
            {
                exitX = randomInt.Next(Size / 2) + boundaryFactor;
            }
            while (exitX == _EntranceCoodinates.x);

            _ExitCoordinates.x = exitX;
            _ExitCoordinates.y = exitY;

        }

        public (int x, int y) getEntrance()
        {
            return _EntranceCoodinates;
        }
        public (int x, int y) getExit()
        {
            return _ExitCoordinates;
        }


        public int getSize()
        {
            return Size;
        }



        private void ChangeAllQuestionAtLocation((int x, int y) location)
        {

            if (NorthQuestion[location.x, location.y] != null && NorthQuestion[location.x, location.y].Locked()) { ChangeQuestion(NorthQuestion[location.x, location.y]); }

            if (SouthQuestion[location.x, location.y] != null && SouthQuestion[location.x, location.y].Locked()) { ChangeQuestion(SouthQuestion[location.x, location.y]); }

            if (WestQuestion[location.x, location.y] != null && WestQuestion[location.x, location.y].Locked()) { ChangeQuestion(WestQuestion[location.x, location.y]); }

            if (EastQuestion[location.x, location.y] != null && EastQuestion[location.x, location.y].Locked()) { ChangeQuestion(EastQuestion[location.x, location.y]); }

        }

        public bool ValidIndex(int index)
        {
            return index >= 0 && index < Size;
        }








    }

}
