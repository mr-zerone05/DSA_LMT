using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module
{
    public class Resort : CommonAccommodation
    {
        private int starResort;
        private bool isPool;
        public int StarResort { get => starResort; set => starResort = value; }
        public bool IsPool { get => isPool; set => isPool = value; }
        public Resort ()
        { }
        public Resort(int idAcc, string nameAcc, string addressAcc, string cityAcc, List<Room> listRoomOfAcc, float rateAcc, int startResort, bool isPool) : base ( idAcc, nameAcc, addressAcc, cityAcc, listRoomOfAcc, rateAcc)
        {
            StarResort = startResort;
            IsPool = isPool;
        }
        public Resort(int idAcc, string nameAcc, string addressAcc, string cityAcc, float rateAcc, int starResort,bool isPool): base(idAcc, nameAcc, addressAcc, cityAcc, rateAcc)
        {
            StarResort = starResort;
            IsPool = isPool;
        }
        public override string ToString()
        {
            string s = $"Resort [{IdAcc}, {NameAcc}, {AddressAcc}, {CityAcc}, {StarResort},{IsPool}]";
            return s ;
        }
    }
}
