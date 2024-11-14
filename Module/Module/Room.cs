using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class Room
    {
        private int idRoom;
        private string nameRoom;
        private int numOfFloor;
        private string typeRoom;
        private int numOfBed;
        private int maxPerson;
        private double areaRoom;
        private double costOfNight;
        public int IdRoom { get =>  idRoom; set => idRoom = value;}
        public string NameRoom { get => nameRoom; set => nameRoom = value;}
        public int NumOfFloor { get => numOfFloor; set => numOfFloor = value;}
        public string TypeRoom { get => typeRoom; set => typeRoom = value;}
        public int NumOfBed { get => numOfBed; set => numOfBed = value;}
        public int MaxPerson { get => maxPerson; set => maxPerson = value;}
        public double AreaRoom { get => areaRoom; set => areaRoom = value;}
        public double CostOfNight { get => costOfNight; set => costOfNight = value;}
#pragma warning disable CS8618 
        public Room(int idRoom, string nameRoom, int numOfFloor, string typeRoom, int numOfBed, int maxPerson, double areaRoom, double costOfNight)
#pragma warning restore CS8618
        {
            IdRoom = idRoom;
            NameRoom = nameRoom;
            NumOfFloor = numOfFloor;
            TypeRoom = typeRoom;
            NumOfBed = numOfBed;
            MaxPerson = maxPerson;
            AreaRoom = areaRoom;
            CostOfNight = costOfNight;
        }
        public int getidRoom()
        {
            return idRoom; 
        }
        public string toString()
        {
            string s = $"Room [{idRoom}, {nameRoom}, {numOfFloor}, {typeRoom}, {numOfBed}, {maxPerson}, {areaRoom}, {costOfNight} ]";
            return s ;
        }
    }
}
