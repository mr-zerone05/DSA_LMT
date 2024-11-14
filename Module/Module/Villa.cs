using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class Villa : LuxuryAccommodation
    {
        public Villa() { }
        public Villa(int idAcc, string nameAcc, string addressAcc, string cityAcc, bool isPool, bool isDrinkWelcome, bool isFreeBrfast, bool isGym, int maxPerson, int cost1NLuxury) : base ( idAcc, nameAcc,  addressAcc, cityAcc, isPool, isDrinkWelcome, isFreeBrfast, isGym, maxPerson, cost1NLuxury)
        {
        }
        public override string ToString()
        {
            string s = $"Villa [{IdAcc}, {NameAcc}, {AddressAcc}, {CityAcc}, {IsPool}, {IsDrinkWelcome},  {IsFreeBrfast}, {IsGym}, {MaxPerson}, {Cost1NLuxury}]";
            return s ;
        }
    }
}
