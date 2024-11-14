using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class CruiseShip : LuxuryAccommodation
    {
        private bool isBar;
        public bool IsBar { get => isBar; set => isBar = value; }
        public CruiseShip() { }
        public CruiseShip(int idAcc, string nameAcc, string addressAcc, string cityAcc, bool isPool, bool isDrinkWelcome, bool isFreeBrfast, bool isGym, int maxPerson, int cost1NLuxury, bool isBar) : base(idAcc, nameAcc, addressAcc, cityAcc, isPool, isDrinkWelcome, isFreeBrfast, isGym, maxPerson, cost1NLuxury)
        {
            IsBar = isBar;
        }
        public override string ToString()
        {
            string s = $"CruiseShip [{IdAcc}, {NameAcc}, {AddressAcc}, {CityAcc}, {IsPool}, {IsDrinkWelcome},  {IsFreeBrfast}, {IsGym}, {MaxPerson}, {Cost1NLuxury}, {IsBar}]";
            return s;
        }
    }
}
