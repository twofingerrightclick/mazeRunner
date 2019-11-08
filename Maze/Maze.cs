using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public class Maze
    {

       
        private int size;
        private int[] entranceCoodinates = new int[2];
        private int[] exitCoordinates = new int[2];
        private QuestionFactory questionFactory = new QuestionFactory();
        private Queue<Question> questions;



        private Random randomInt = new Random();

        public Maze(int size, params string [] questionArgs)
        {
       
            this.size = size;
            
            questions = questionFactory.getQuestions(questionArgs, (size * size * 4));

            createMaze();



        }

        private void createMaze()
        {

            MazeStructure mazeStructure = new MazeStructure(size);
            String[,] wallLocations = mazeStructure.getWalls();

        }

        

        private void changeRoomQuestions( (int x, int y) roomCoordinates, params string [] questionArgs )
        {
            
            

         //  int numQuestionsNotAnsweredInRoom = roomArray[roomCoordinates.x, roomCoordinates.y].getRemainingQuestions();
            
           // questionFactory.getQuestions(questionArgs, numQuestionsNotAnsweredInRoom);

            //the room has questions stored by index. so then add the new questions at the old questions spots, and check adjacent questions. 



        }


        public void QuestionAnsweredCorrectly((int x, int y) roomIndex, int questionIndex)
        {
            //roomArray[roomIndex.x, roomIndex.y].RemoveQuestionMakeDoorOpen(questionIndex);
        }

       

        private void setExits()
        {
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

            
            //RoomEvent theEntrance = new Entrance();
            //roomArray[exitX,exitY].addRoomEvent(theExit);
            //roomArray[entranceCoodinates[0],entranceCoodinates[1]].addRoomEvent(theEntrance);

        }

        public int[] getEntrance()
        {
            return this.entranceCoodinates;
        }
        public int[] getExit()
        {
            return this.exitCoordinates;
        }




        public int getSize()
        {
            return size;
        }

        
    }

}
