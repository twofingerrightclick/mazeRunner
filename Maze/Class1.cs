﻿using System;
using System.Text;

namespace Maze
{
    public class Room
    {

        //private ArrayList<RoomEvent> roomEvent = new ArrayList<>();
        //room events now can be doors
        private char[,] roomLayout ={{'*','*','*'},
                                     {'*',' ','*'},
                                     {'*','*','*'}};


        public bool RoomHasBeenDiscovered { get; } = false;

        public Room(String wallLocations)
        {

            if (!wallLocations.Contains("N")) { this.roomLayout[0, 1] = '-'; }
            if (!wallLocations.Contains("S")) { this.roomLayout[2, 1] = '-'; }
            if (!wallLocations.Contains("E")) { this.roomLayout[1, 2] = '|'; }
            if (!wallLocations.Contains("W")) { this.roomLayout[1, 0] = '|'; }

        }


        public Room() { }

        //private void setRoomEventIdentifier()
        //{

        //    if (roomEvent.size() > 1)
        //    {
        //        this.roomLayout[1, 1] = 'M';
        //    }
        //    else this.roomLayout[1, 1] = roomEvent.get(0).getIdentifier();



        //}
        public void setRoomEventIdentifier(char identifier)
        {

            /*if (this.roomEvent.size()>=2){
            this.roomLayout[1, 1]=roomEvent.get(0).getIdentifier();
            }*/

            this.roomLayout[1, 1] = identifier;



        }

        //public void addRoomEvent(RoomEvent r)
        //{
        //    this.roomEvent.add(r);
        //    setRoomEventIdentifier();
        //}

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

        //public ArrayList<RoomEvent> getRoomEvent()
        //{
        //    return roomEvent;
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

            for (int i = 0; i < roomLayout.Length; i++)

            {
                sb.Append(string(roomLayout[i, 0]) + "\r\n");
            }

            return sb.ToString().ReplaceAll("\\[|]|,", "");
        }

        public String getRoomRowasString(int row)
        {

            return ToString(this.roomLayout[row]).replaceAll("\\[|]|,", "");




        }

        public char getRoomIdentier()
        {
            return this.roomLayout[1, 1];
        }
    }

}
