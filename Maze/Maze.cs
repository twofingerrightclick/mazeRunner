using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public class Maze
    {

        private Room[,] roomArray;
        private int size;
        private int[] entranceCoodinates = new int[2];
        private int[] exitCoordinates = new int[2];

        private Random randomInt = new Random();

        public Maze(int size)
        {
            this.roomArray = new Room[size,size];
            this.size = size;
            //if not all pillars set try again
           // while (!createMaze()) ;



        }

        private void createMaze()
        {

            MazeStructure mazeStructure = new MazeStructure(size);
            String[,] wallLocations = mazeStructure.getWalls();

            for (int x = 0; x < size; x++)
            {

                for (int y = 0; y < size; y++)
                {
                    this.roomArray[x,y] = new Room(wallLocations[x,y]);
                }
            }

            //bool sucess = 
                populateWithEvents();

           // return sucess;
        }

        private void populateWithEvents()
        {

            setExits();
            //return addEvents();



        }



        private bool addQuestions()
        {
            

           
            //for (Room row[] : roomArray)
            //{

            //    for (Room room : row)
            //    {
            //        //only add events where there aren't exits
                    
            //    }

            //}
            
           
            return true;
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

        public void MakeMock()
        {
            for (int dungeonRow = 0; dungeonRow < this.size; dungeonRow++)
            {
                for (int dungeonCol = 0; dungeonCol < this.size; dungeonCol++)
                {
                    roomArray[dungeonRow,dungeonCol] = new Room();
                }
            }

        }

      override
    public String ToString()
        {
            StringBuilder mazeRoomStringBuilder = new StringBuilder();
            for (int mazeRow = 0; mazeRow < this.size; mazeRow++)
            {

                for (int roomRow = 0; roomRow < 3; roomRow++)
                {
                    for (int dungeonCol = 0; dungeonCol < this.size; dungeonCol++)
                    {
                        //mazeRoomStringBuilder.Append(getRoom(mazeRow, dungeonCol).getRoomRowasString(roomRow));
                        mazeRoomStringBuilder.Append(getRoom(mazeRow, dungeonCol));

                    }
                    mazeRoomStringBuilder.Append("\r\n");
                }

            }

            return mazeRoomStringBuilder.ToString();


        }


        //public void printCurrentLocation(PillarofOOHeroTracker heroTracker)
        //{
        //    Room currentRoom = this.getRoom(heroTracker.getLocation());
        //    char currentIdentifier = currentRoom.getRoomIdentier();
        //    currentRoom.setRoomEventIdentifier('+');

        //    StringBuilder dungeonStringBuilder = new StringBuilder();
        //    for (int dungeonRow = 0; dungeonRow < this.size; dungeonRow++)
        //    {

        //        for (int row = 0; row < 3; row++)
        //        {
        //            for (int dungeonCol = 0; dungeonCol < this.size; dungeonCol++)
        //            {
        //                dungeonStringBuilder.append(getRoom(dungeonRow, dungeonCol).getRoomRowasString(row));

        //            }
        //            dungeonStringBuilder.append("\r\n");
        //        }

        //    }

        //    System.out.println(dungeonStringBuilder.toString());
        //    System.out.println("+ = current location");
        //    currentRoom.setRoomEventIdentifier(currentIdentifier);



        //}


        public Room getRoom(int x, int y)
        {
            return this.roomArray[x,y];
        }
        public Room getRoom(int[] xy)
        {
            return this.roomArray[xy[0],xy[1]];
        }


        public int getSize()
        {
            return size;
        }

        
    }

}
