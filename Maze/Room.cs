﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public class Room
    {

        //private ArrayList<RoomEvent> roomEvent = new ArrayList<>();
        //room events now can be doors
        private char[,] roomLayout ={{'*','*','*'},
                                     {'*','r','*'},
                                     {'*','*','*'}};


        public List<(int location, int questionIndex)> questions = new List<(int location, int questionIndex)>();

        public bool RoomHasBeenDiscovered { get; set; } = false;

        private enum QuestionLocation
        {
            North,
            South,
            East,
            West
        }

        //up too 4 questions, use enum for locations.
        // private Questions[] = new Questions[4];

        // public setDoor

        public Room(String wallLocations)
        {

            if (!wallLocations.Contains("N")) { this.roomLayout[0, 1] = '-'; }
            if (!wallLocations.Contains("S")) { this.roomLayout[2, 1] = '-'; }
            if (!wallLocations.Contains("E")) { this.roomLayout[1, 2] = '|'; }
            if (!wallLocations.Contains("W")) { this.roomLayout[1, 0] = '|'; }



        }

        internal void addQuestions(bool v1, bool v2, bool v3, bool v4)
        {
            throw new NotImplementedException();
        }

        public Room() { }

        public void RemoveQuestionMakeDoorOpen(int questionIndexToRemove) {

            foreach((int location, int questionIndex) question in questions)
            {
                if (question.questionIndex == questionIndexToRemove) {
                    questions.Remove(question);
                }
            }
            //remove question
        }

        //private void setRoomEventIdentifier()
        //{

        //    if (roomEvent.size() > 1)
        //    {
        //        this.roomLayout[1, 1] = 'M';
        //    }
        //    else this.roomLayout[1, 1] = roomEvent.get(0).getIdentifier();



        //}
       

        internal int getRemainingQuestions()
        {
            throw new NotImplementedException();
        }

        public void addQuestions(List<Question> questions)
        {
            //check adjacent rooms and add the same questions. 
        }

        //public bool doRoomEvents(Hero theHero)
        //{
        //    //need to refresh map location for player if lots of stuff printed to the console

        //    for (RoomEvent roomEvent : roomEvent)
        //    {

        //        roomEvent.doAction(theHero);
        //        if (!theHero.isAlive())
        //        {
        //            System.out.println("Game over...");
        //            return false;
        //        }

        //    }
        //    return true;
        //}

       

        public char[,] getRoomLayout()
        {
            return roomLayout;
        }

        //    public String getRoomEventsString()
        //    {
        //        if (roomEvent.size() < 1)
        //            return "*";

        //        StringBuilder sb = new StringBuilder();
        //        for (RoomEvent event: roomEvent){
        //        sb.append(event.getIdentifier());
        //    }
        //    return sb.toString();
        //}


        override
            public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < roomLayout.GetLength(0); i++)

            {
               
                for (int j = 0; j < roomLayout.GetLength(1); j++)
                {
                    sb.Append(roomLayout[i, j]);
                }
                sb.Append("\r\n");
            }

            return sb.ToString().Replace("\\[|]|,", "");
            //return "hello";
        }

        public String getRoomRowasString(int row)
        {

            //return ToString(roomLayout(row)).Replace("\\[|]|,", "");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < roomLayout.GetLength(0); i++)

            {
                sb.Append(roomLayout[row, i]);

            }

            //Console.WriteLine(sb.ToString());

            return sb.ToString().Replace("\\[|]|,", "");
           // return "***";




        }

        public char getRoomIdentier()
        {
            return this.roomLayout[1, 1];
        }
    }

}
