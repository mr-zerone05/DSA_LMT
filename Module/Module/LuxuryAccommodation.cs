using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module
{
    public class LuxuryAccommodation : Accommodation
    {
        private bool isPool;             //Co be boi khong
        private bool isDrinkWelcome;     //Co thuc uong chao mung khong
        private bool isFreeBrfast;       //Co phuc vu mien phi bua sang khong
        private bool isGym;              //co phuc vu phong the hinh khong
        private int maxPerson;           //so luong nguoi toi da co the phuc vu
        private int cost1NLuxury;        //chi phi cho 1 dem

        public bool IsPool { get => isPool; set => isPool = value; }
        public bool IsDrinkWelcome { get => isDrinkWelcome; set => isDrinkWelcome = value; }
        public bool IsFreeBrfast { get => isFreeBrfast; set => isFreeBrfast = value; }
        public bool IsGym { get => isGym; set => isGym = value; }
        public int MaxPerson { get => maxPerson; set => maxPerson = value; }
        public int Cost1NLuxury { get => cost1NLuxury; set => cost1NLuxury = value; }
        public LuxuryAccommodation() { }
        public LuxuryAccommodation(int idAcc, string nameAcc, string addressAcc, string cityAcc, bool isPool, bool isDrinkWelcome, bool isFreeBrfast, bool isGym, int maxPerson, int cost1NLuxury) : base (idAcc, nameAcc, addressAcc, cityAcc)
        {
            IsPool = isPool;
            IsDrinkWelcome = isDrinkWelcome;
            IsFreeBrfast = isFreeBrfast;
            IsGym = isGym;
            MaxPerson = maxPerson;
            Cost1NLuxury = cost1NLuxury;
        }
        public override string ToString()
        {
            string s = $"{IdAcc}, {NameAcc}, {AddressAcc}, {CityAcc}";
            return s;
        }
    }
}
