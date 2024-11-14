using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class Homestay : CommonAccommodation
    {
        public Homestay(int idAcc, string nameAcc, string addressAcc, string cityAcc, List<Room> listRoomOfAcc, float rateAcc) : base (idAcc, nameAcc, addressAcc, cityAcc, listRoomOfAcc, rateAcc)
        {
        }
        public Homestay(int idAcc, string nameAcc, string addressAcc, string cityAcc, float rateAcc) : base (idAcc, nameAcc, addressAcc, cityAcc, new List<Room>(), rateAcc)   //Sử dụng new List<Room>() trong constructor thứ hai nhằm đảm bảo rằng danh sách listRoomOfAcc (danh sách các phòng) được khởi tạo đúng cách, ngay cả khi không được cung cấp từ bên ngoài
        {
        }
        public override string ToString()
        {
            string s = $"Homestay [{IdAcc}, {NameAcc}, {AddressAcc}, {CityAcc}, {RateAcc}]";
            return s ;
        }
    }
}
