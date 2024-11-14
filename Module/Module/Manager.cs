using System;
using System;
using System.Collections.Generic;
using System.IO;

namespace Module
{
    public class ReservationHandler
    {
        private ReservationSystem reservationSystem;

        public ReservationHandler(ReservationSystem system)
        {
            reservationSystem = system;
        }

        // Requirement 1
        public void HandleRequirement1()
        {
            List<Accommodation> req1 = reservationSystem.getAccommodations();
            WriteToFile("requirement1_output.csv", req1);
        }

        // Requirement 2
        public void HandleRequirement2()
        {
            Console.WriteLine("Enter City for Requirement 2:");
            string city1 = Console.ReadLine();
            int numOfPeople1 = GetNumberOfPeople();

            string city2 = Console.ReadLine();
            int numOfPeople2 = GetNumberOfPeople();

            List<Accommodation> req2_1 = reservationSystem.SearchForRoom(city1, numOfPeople1);
            List<Accommodation> req2_2 = reservationSystem.SearchForRoom(city2, numOfPeople2);

            WriteToFile("requirement2_output_city1.csv", req2_1);
            WriteToFile("requirement2_output_city2.csv", req2_2);
        }

        // Requirement 3
        public void HandleRequirement3()
        {
            Console.WriteLine("Enter the minimum price for Requirement 3:");
            double minPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the maximum price for Requirement 3:");
            double maxPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the start and end date (in epoch time) for Requirement 3:");
            DateTime checkIn = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt64(Console.ReadLine()));
            DateTime checkOut = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt64(Console.ReadLine()));

            Console.WriteLine("Enter the city for Requirement 3:");
            string city = Console.ReadLine();

            Console.WriteLine("Enter the number of people for Requirement 3:");
            int numOfPeople = Convert.ToInt32(Console.ReadLine());

            List<Accommodation> req3_1 = reservationSystem.SearchForRoomByRange("data/reservation_3.csv", minPrice, maxPrice,
                checkIn, checkOut, city, numOfPeople);
            WriteToFile("requirement3_output.csv", req3_1);
        }

        // Requirement 5
        public void HandleRequirement5()
        {
            Console.WriteLine("Enter the Homestay details for Requirement 5:");
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine();
            string address = Console.ReadLine();
            string city = Console.ReadLine();
            float rating = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter the Room details for Requirement 5:");
            int roomId = Convert.ToInt32(Console.ReadLine());
            string roomName = Console.ReadLine();
            int roomCapacity = Convert.ToInt32(Console.ReadLine());
            string roomType = Console.ReadLine();
            int bedCount = Convert.ToInt32(Console.ReadLine());
            int maxPerson = Convert.ToInt32(Console.ReadLine());
            double pricePerNight = Convert.ToDouble(Console.ReadLine());
            double area = Convert.ToDouble(Console.ReadLine());

            try
            {
                Accommodation acc = new Homestay(id, name, address, city, rating);
                Room room = new Room(roomId, roomName, roomCapacity, roomType, bedCount, maxPerson, pricePerNight, area);

                double totalPrice = reservationSystem.PerformReservation("data/reservation_5.csv", acc, room,
                    new DateTime(1713368812), new DateTime(1713398812));

                List<string> req5 = new List<string> { totalPrice.ToString() };
                WriteToFile("requirement5_output.csv", req5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Nhập số người từ bàn phím
        private int GetNumberOfPeople()
        {
            Console.WriteLine("Enter number of people:");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Ghi dữ liệu vào file
        private void WriteToFile(string fileName, object data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    if (data is List<Accommodation> accommodations)
                    {
                        foreach (var acc in accommodations)
                        {
                            writer.WriteLine(acc.ToString());
                        }
                    }
                    else if (data is List<string> strData)
                    {
                        foreach (var str in strData)
                        {
                            writer.WriteLine(str);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }
    }
}

