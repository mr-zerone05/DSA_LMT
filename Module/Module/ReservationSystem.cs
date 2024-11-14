using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class ReservationSystem
    {
        private List<Accommodation> accommodations;

        //Xuat so luong nguoi co the phuc vu cua tung phong dich vu
        public int[] ReMaxPeople(Accommodation acc)
        {
            if (acc is CommonAccommodation commonAcc)  // nếu đúng lưu trữ vào biến commonAcc
            {
                int[] arrMaxPeople = new int[commonAcc.ListRoomOfAcc.Count];  //tao mang có độ dài bằng số lượng phòng trong danh sách cua commonAcc
                for (int i = 0; i < commonAcc.ListRoomOfAcc.Count; i++)
                {
                    arrMaxPeople[i] = commonAcc.ListRoomOfAcc[i].MaxPerson;  //lay so luong nguoi toi đa mà phòng thứ i gán vào vị trí tương ứng trong mảng 
                }
                return arrMaxPeople;
            }
            else if (acc is LuxuryAccommodation luxuryAcc)
            {
                return new int[] { luxuryAcc.MaxPerson };
            }
            return new int[0];
        }

        // So sanh hai chuoi ki tu Ho tro cho Insertion Sort A -> Z.
        public int CompareStrings(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            int minLen = Math.Min(len1, len2);

            for (int i = 0; i < minLen; i++)
            {
                char c1 = char.ToLower(str1[i]);
                char c2 = char.ToLower(str2[i]);
                if (c1 != c2)   //2 ki tu khác nhau
                {
                    return c1 - c2; //ví dụ: Vì 'a' nhỏ hơn 'b', hàm sẽ trả về một số âm (chuỗi "apple" đứng trước "banana")
                }
            }
            // neu hai ki tu giong nhau thi xuat ra hieu str
            return len1 - len2;
        }
        // Sap xep danh sach luu tru theo Insertion sort A -> Z
        public void sortAccommondation(List<Accommodation> accList)
        {
            for (int i = 1; i < accList.Count; i++)
            {
                Accommodation accTmp = accList[i];  //luu tru doi tuong tai vi tri hien tai cua ds
                int j = i - 1;    //khoi tao chi so j dung ngay truoc i va sẽ so sánh và tìm vị trí thích hợp để chèn giá trị accTmp.
                string address1 = accTmp.NameAcc;  // lưu trữ tên nơi lưu trú tại vị trí i để so sánh.

                while (j >= 0 && CompareStrings(accList[j].NameAcc, address1) > 0)  // số dương (> 0), nghĩa là accList[j].NameAcc lớn hơn address1 theo thứ tự bảng chữ cái.
                {
                    //Chen vi tri
                    accList[j + 1] = accList[j]; // // Nếu phần tử tại vị trí j lớn hơn phần tử đang xét, di chuyển phần tử này lên một vị trí
                    j = j - 1;  //// Giảm j để tiếp tục so sánh với phần tử trước đó
                }
                // Sau khi tìm được vị trí thích hợp, chèn phần tử đang xét vào đúng vị trí(vì j đã bị giảm 1 vi trí)
                accList[j + 1] = accTmp;
            }
        }

        //Kiem tra thong tin dat phong
        public bool checkAccommodation(DateTime checkin, DateTime checkout, Reservation res)
        {
            DateTime checkOutMili = checkout.AddMilliseconds(checkout.TimeOfDay.TotalMilliseconds);
            DateTime resCIn = res.Checkin;  //Lưu trữ thời gian mà khách hàng đã đặt để nhận phòng (thời gian check-in).
            bool isCO = resCIn < checkOutMili;

            DateTime checkInMili = checkin.AddMilliseconds(checkin.TimeOfDay.TotalMilliseconds);
            DateTime resCOut = res.Checkout;  // Lưu trữ thời gian mà khách hàng đã đặt để trả phòng (thời gian check-out).
            bool isCI = resCOut > checkInMili;

            return isCO || isCI;
        }
        //Load data
        public ReservationSystem(string accPath, string roomPath, string roomOfAccPath)
        {
            this.accommodations = loadAccommodations(accPath, roomPath, roomOfAccPath);  //để tải dữ liệu từ các tệp và gán danh sách đối tượng lưu trú cho thuộc tính accommodations.
        }
        public List<Accommodation> getAccommodations() //Phương thức này trả về danh sách các đối tượng Accommodation đã được nạp từ tệp.
        {
            return accommodations;
        }
        // Requirement 1
        public List<Accommodation> loadAccommodations(string accPath, string roomPath, string roomOfAccPath)
        {
            List<Accommodation> accList = new List<Accommodation>();
            List<Room> roomList = new List<Room>();
            Dictionary<int, List<int>> roomInAccGroup = new Dictionary<int, List<int>>();

            StreamReader accFile = null;
            StreamReader roomFile = null;
            StreamReader roomOfAccFile = null;

            try
            {
                accFile = new StreamReader(accPath);
                roomFile = new StreamReader(roomPath);
                roomOfAccFile = new StreamReader(roomOfAccPath);

                // Process accommodations
                while (!accFile.EndOfStream)
                {
                    string lineAccInput = accFile.ReadLine();
                    string[] arrLineAcc = lineAccInput.Split(',');

                    int idAcc = int.Parse(arrLineAcc[0]);
                    string nameAcc = arrLineAcc[1];
                    string addressAcc = arrLineAcc[2];
                    string cityAcc = arrLineAcc[3];

                    int dataCount = arrLineAcc.Length;

                    if (dataCount >= 5 && dataCount <= 7)
                    {
                        float rateAcc = float.Parse(arrLineAcc[dataCount - 1]);

                        if (dataCount == 5)
                        {
                            accList.Add(new Homestay(idAcc, nameAcc, addressAcc, cityAcc, rateAcc));
                        }
                        else if (dataCount == 6)
                        {
                            int star = int.Parse(arrLineAcc[dataCount - 2]);
                            accList.Add(new Hotel(idAcc, nameAcc, addressAcc, cityAcc, rateAcc, star));
                        }
                        else
                        {
                            int star = int.Parse(arrLineAcc[dataCount - 3]);
                            bool isPool = arrLineAcc[dataCount - 2] == "yes";
                            accList.Add(new Resort(idAcc, nameAcc, addressAcc, cityAcc, rateAcc, star, isPool));
                        }
                    }
                    else if (dataCount >= 10 && dataCount <= 11)
                    {
                        bool isPool = arrLineAcc[4] == "yes";
                        bool isDrinkWelcome = arrLineAcc[5] == "yes";
                        bool isFreeBrfast = arrLineAcc[6] == "yes";
                        bool isGym = arrLineAcc[7] == "yes";
                        int maxPerson = int.Parse(arrLineAcc[dataCount - 2]);
                        int cost1Night = int.Parse(arrLineAcc[dataCount - 1]);

                        if (dataCount == 10)
                        {
                            accList.Add(new Villa(idAcc, nameAcc, addressAcc, cityAcc, isPool, isDrinkWelcome, isFreeBrfast, isGym, maxPerson, cost1Night));
                        }
                        else
                        {
                            bool isBar = arrLineAcc[dataCount - 3] == "yes";
                            accList.Add(new CruiseShip(idAcc, nameAcc, addressAcc, cityAcc, isPool, isDrinkWelcome, isFreeBrfast, isGym, maxPerson, cost1Night, isBar));
                        }
                    }
                }

                // Process rooms
                while (!roomFile.EndOfStream)
                {
                    string lineRoomInput = roomFile.ReadLine();
                    string[] arrLineRoom = lineRoomInput.Split(',');

                    int idRoom = int.Parse(arrLineRoom[0]);
                    string nameRoom = arrLineRoom[1];
                    int numOfFloor = int.Parse(arrLineRoom[2]);
                    string typeRoom = arrLineRoom[3];
                    int numOfBed = int.Parse(arrLineRoom[4]);
                    int maxPerson = int.Parse(arrLineRoom[5]);
                    double areaRoom = double.Parse(arrLineRoom[6]);
                    double cost1Night = double.Parse(arrLineRoom[7]);

                    roomList.Add(new Room(idRoom, nameRoom, numOfFloor, typeRoom, numOfBed, maxPerson, areaRoom, cost1Night));
                }

                // Link rooms to accommodations
                while (!roomOfAccFile.EndOfStream)
                {
                    string lineIDInput = roomOfAccFile.ReadLine();
                    string[] arrLineID = lineIDInput.Split(',');

                    int idOfAcc = int.Parse(arrLineID[0]);
                    int idOfRoom = int.Parse(arrLineID[1]);

                    if (!roomInAccGroup.ContainsKey(idOfAcc))
                    {
                        roomInAccGroup[idOfAcc] = new List<int>();
                    }
                    roomInAccGroup[idOfAcc].Add(idOfRoom);
                }

                foreach (var idA in roomInAccGroup.Keys)
                {
                    List<int> listIdR = roomInAccGroup[idA];

                    foreach (Accommodation acc in accList)
                    {
                        if (acc is CommonAccommodation commonAcc && acc.IdAcc == idA)
                        {
                            foreach (int idR in listIdR)
                            {
                                foreach (Room room in roomList)
                                {
                                    if (room.IdRoom == idR)
                                    {
                                        commonAcc.setListRoomOfAcc(room);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                accFile?.Close();
                roomFile?.Close();
                roomOfAccFile?.Close();
            }

            return accList;
        }
        // Requirement 2
        public List<Accommodation> SearchForRoom(string city, int numOfPeople)
        {
            List<Accommodation> accList = getAccommodations(); // là danh sách chứa tất cả các nơi lưu trú 
            List<Accommodation> comSearchList = new List<Accommodation>();
            List<Accommodation> luxSearchList = new List<Accommodation>();

            foreach (Accommodation acc in accList)
            {
                if (acc.CityAcc == city)
                {   
                    int[] arrMaxPer = ReMaxPeople(acc);
                    if (arrMaxPer != null)
                    {
                        //Phân loại và kiểm tra số lượng người
                        if (acc is CommonAccommodation)
                        {
                            foreach (int per in arrMaxPer)
                            {
                                if (per >= numOfPeople)
                                {
                                    comSearchList.Add(acc);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (arrMaxPer[0] >= numOfPeople)  //chỉ cần xem giá trị đầu tiên trong arrMaxPer, vì nơi lưu trú loại này thường chỉ có một giá trị cho sức chứa tối đa.
                            {
                                luxSearchList.Add(acc);
                            }
                        }
                    }
                    else return null;
                }
            }

            sortAccommondation(comSearchList);
            sortAccommondation(luxSearchList);
            //Ghép hai danh sách
            comSearchList.InsertRange(0, luxSearchList);  //chèn toàn bộ luxSearchList vào đầu comSearchList
            return comSearchList;
        }
        // Requirement 3
        public List<Reservation> getReservation(string reservationPath)
        {
            List<Reservation> loadRes = new List<Reservation>();  //là danh sách sẽ lưu trữ các đối tượng Reservation, đại diện cho các đặt phòng.
            try
            {
                using (StreamReader resFile = new StreamReader(reservationPath))  //mở và đọc từng dòng file
                {
                    string lineResInput;  //chứa dữ liệu của một dòng, đại diện cho một đặt phòng.
                    while ((lineResInput = resFile.ReadLine()) != null)
                    {
                        //Phân tách dữ liệu của dòng
                        string[] arrLineRes = lineResInput.Split(',');
                        int countInLineRes = arrLineRes.Length;  //có bao nhiêu phần tử được lưu trong dòng.

                        //Chuyển đổi và gán dữ liệu
                        int idRes = int.Parse(arrLineRes[0]);  //là ID của đặt phòng.
                        int idAccOfRes = int.Parse(arrLineRes[1]);  //là ID của chỗ ở được đặt phòng.
                        DateTime checkIn = DateTimeOffset.FromUnixTimeSeconds(long.Parse(arrLineRes[countInLineRes - 2])).DateTime;
                        DateTime checkOut = DateTimeOffset.FromUnixTimeSeconds(long.Parse(arrLineRes[countInLineRes - 1])).DateTime;
                        int idRoom = countInLineRes == 5 ? int.Parse(arrLineRes[2]) : 0;

                        loadRes.Add(new Reservation(idRes, idAccOfRes, idRoom, checkIn, checkOut));
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
            }
            return loadRes;
        }
        public List<Accommodation> SearchForRoomByRange(string reservationPath, double priceFrom, double priceTo, DateTime checkin, DateTime checkout, string city, int numOfPeople)
        {
            List<Accommodation> accSearchRange = new List<Accommodation>();
            List<Reservation> getRes = getReservation(reservationPath);
            List<Accommodation> accList = getAccommodations();

            foreach (var acc in accList)
            {
                bool isCity = acc.CityAcc == city;
                if (acc is CommonAccommodation common)
                {
                    foreach (Room room in common.getListRoomOfAcc())
                    {
                        bool isCost = room.CostOfNight >= priceFrom && room.CostOfNight <= priceTo;
                        bool isMaxPer = Math.Abs(room.MaxPerson - numOfPeople) <= 2;
                        bool isCheck = true;

                        foreach (var res in getRes)
                        {
                            if (common.IdAcc == res.AccId && room.IdRoom == res.RoomId)
                            {
                                isCheck = checkAccommodation(checkin, checkout, res);
                                break;
                            }
                        }

                        if (isCost && isCity && isMaxPer && isCheck)
                        {
                            accSearchRange.Add(acc);
                        }
                    }
                }
                else if (acc is LuxuryAccommodation luxury)
                {
                    bool isCost = luxury.Cost1NLuxury >= priceFrom && luxury.Cost1NLuxury <= priceTo;
                    bool isMaxPer = Math.Abs(luxury.MaxPerson - numOfPeople) <= 2;
                    bool isCheck = false;

                    foreach (var res in getRes)
                    {
                        if (luxury.IdAcc == res.AccId)
                        {
                            isCheck = checkAccommodation(checkin, checkout, res);
                            if (isCheck) break;
                        }
                    }

                    if (isCost && isCheck && isCity && isMaxPer)
                    {
                        accSearchRange.Add(acc);
                    }
                }
            }
            sortAccommondation(accSearchRange);
            accSearchRange.Reverse();
            return accSearchRange;
        }
        // Requirement 5
        public bool WriteReservation(List<Reservation> resList, string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (Reservation res in resList)
                    {
                        string s = string.Empty;

                        if (res.RoomId == 0)
                        {
                            s = string.Format("{0},{1},{2},{3}", res.ReservationId, res.AccId, res.Checkin.Ticks / TimeSpan.TicksPerSecond, res.Checkout.Ticks / TimeSpan.TicksPerSecond);
                        }
                        else
                        {
                            s = string.Format("{0},{1},{2},{3},{4}", res.ReservationId, res.AccId, res.RoomId, res.Checkin.Ticks / TimeSpan.TicksPerSecond, res.Checkout.Ticks / TimeSpan.TicksPerSecond);
                        }

                        writer.WriteLine(s);
                    }
                }
                Console.WriteLine("Successfully wrote to the file.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error.");
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot write file");
                return false;
            }

            return true;
        }

        public double PerformReservation(string reservationPath, Accommodation acc, Room room, DateTime checkin, DateTime checkout)
        {
            List<Reservation> getRes = getReservation(reservationPath);

            bool check = true;
            double totalMoney = room.CostOfNight * DiffBetweenDays(checkin, checkout);
            double payment = totalMoney + totalMoney * 0.08;

            if (acc is CommonAccommodation common)
            {
                foreach (Reservation res in getRes)
                {
                    if (common.IdAcc == res.AccId && room.getidRoom() == res.RoomId)
                    {
                        check = checkAccommodation(checkin, checkout, res);
                        break;
                    }
                }
            }
            else if (acc is LuxuryAccommodation luxury)
            {
                foreach (Reservation res in getRes)
                {
                    if (luxury.IdAcc == res.AccId)
                    {
                        check = checkAccommodation(checkin, checkout, res);
                    }
                }
            }

            if (!check)
            {
                throw new Exception("The room has already been booked during this time period");
            }

            getRes.Add(new Reservation(getRes.Count + 1, acc.IdAcc, room.getidRoom(), checkin, checkout));
            WriteReservation(getRes, reservationPath);
            return payment;
        }

        public long DiffBetweenDays(DateTime startDate, DateTime endDate)
        {
            // Remove time and calculate days difference
            startDate = RemoveTime(startDate);
            endDate = RemoveTime(endDate);

            // Ensure the dates are valid
            if (startDate < DateTime.MinValue || startDate > DateTime.MaxValue || endDate < DateTime.MinValue || endDate > DateTime.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The dates are out of the valid range.");
            }

            long diff = Math.Abs((endDate - startDate).Ticks);
            long numOfDays = TimeSpan.FromTicks(diff).Days;
            return numOfDays;
        }

        private DateTime RemoveTime(DateTime date)
        {
            // Remove time from the DateTime object (only keep the date part)
            return new DateTime(date.Year, date.Month, date.Day);
        }
    }
}