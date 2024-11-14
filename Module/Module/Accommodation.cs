using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public abstract class Accommodation
    {
        private int idAcc;
        private string nameAcc;
        private string addressAcc;
        private string cityAcc;
        public int IdAcc { get => idAcc; set => idAcc = value;}
        public string NameAcc { get => nameAcc; set => nameAcc = value;}
        public string AddressAcc { get => addressAcc; set => addressAcc = value;}
        public string CityAcc { get => cityAcc; set => cityAcc = value;}
        public Accommodation()
        {
            idAcc = 0;
            nameAcc = "";
            addressAcc = "";
            cityAcc = "";
        }
        public Accommodation(int idAcc, string nameAcc, string addressAcc, string cityAcc)
        {
            IdAcc = idAcc;
            NameAcc = nameAcc;
            AddressAcc = addressAcc;
            CityAcc = cityAcc;
        }
        public abstract override string ToString();
    }
}
