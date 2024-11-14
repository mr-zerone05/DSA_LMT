
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class CommonAccommodation : Accommodation
    {
        //Danh sach cac phong trong noi luu tru
        private List<Room> listRoomOfAcc = new List<Room>();
        private float rateAcc; //He so danh gia
        public List<Room> ListRoomOfAcc { get => listRoomOfAcc; set => listRoomOfAcc = value; }
        public float RateAcc { get => rateAcc; set => rateAcc = value; }
        public CommonAccommodation()
        {

        }
        public CommonAccommodation(int idAcc, string nameAcc, string addressAcc, string cityAcc, List<Room> listRoomOfAcc,float rateAcc) : base (idAcc, nameAcc, addressAcc, cityAcc)
        {
            ListRoomOfAcc = listRoomOfAcc;
            RateAcc = rateAcc;
        }
        public CommonAccommodation(int idAcc, string nameAcc, string addressAcc, string cityAcc, float rateAcc): base(idAcc, nameAcc, addressAcc, cityAcc)
        {
            RateAcc = rateAcc;
        }
        public List<Room> getListRoomOfAcc()
        {
            return listRoomOfAcc;
        }
        public void setListRoomOfAcc(Room room)
        {
            ListRoomOfAcc.Add(room);
        }
        public override string ToString()
        {
            string s = $"{IdAcc}, {NameAcc}, {AddressAcc}, {CityAcc}";
            return s;
        }
    }
}
