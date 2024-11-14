using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class Hotel : CommonAccommodation
    {
        private int starHotel;
        public int StarHotel { get => starHotel; set => starHotel = value; }
        public Hotel (int idAcc, string nameAcc, string addressAcc, string cityAcc, List<Room> listRoomOfAcc, float rateAcc, int startHotel) : base (idAcc, nameAcc, addressAcc, cityAcc, listRoomOfAcc, rateAcc)
        {
            StarHotel = startHotel;
        }
        public Hotel (int idAcc, string nameAcc, string addressAcc, string cityAcc, float rateAcc, int startHotel) : base (idAcc, nameAcc, addressAcc, cityAcc, new List<Room>(), rateAcc)
        {
            StarHotel = startHotel;
        }
        public override string ToString()
        {
            string s = $"Hotel [{IdAcc}, {NameAcc}, {AddressAcc}, {CityAcc}, {StarHotel}]";
            return s;
        }
    }
}
