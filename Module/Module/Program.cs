using Module;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class Program
{
    // Define output file paths   
    public static string[] REQUIREMENT_OUTPUT_FILES = new string[] {
        "./output_new/Req1.txt",
            "./output_new/Req2_1.txt",
            "./output_new/Req2_2.txt",
            "./output_new/Req3_1.txt",
            "./output_new/Req3_2.txt",
            "./output_new/Req5.txt",
        };
    public static bool WriteFile<T>(string path, List<T> rows)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (T row in rows)
                {
                    writer.WriteLine(row.ToString());
                }
            }
            Console.WriteLine("Successfully wrote to the file.");
            return true;
        }
        catch (IOException)
        {
            Console.WriteLine("Error writing file.");
            return false;
        }
        catch (Exception)
        {
            Console.WriteLine("Cannot write file");
            return false;
        }
    }


    public static void seekForRooOfCity(string city, int n)
    {
        string roomPath = "data/room_type.csv";
        string accPath = "data/accommodation.csv";
        string roomInAccPath = "data/room_in_accommodation.csv";

        string path = "./output_new";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        ReservationSystem reservationSystem = new ReservationSystem(accPath, roomPath, roomInAccPath);
        List <Accommodation> req2_1 = reservationSystem.SearchForRoom(city, n);
        WriteFile(REQUIREMENT_OUTPUT_FILES[1], req2_1);
        Console.WriteLine($"Danh sach cac dich vu luu tru tai {city}:");
        foreach (var accommodation in req2_1)
        {
            Console.WriteLine(accommodation);
        }
    }


    public static void displayDataAcc()
    {
        string roomPath = "data/room_type.csv";
        string accPath = "data/accommodation.csv";
        string roomInAccPath = "data/room_in_accommodation.csv";

        string outputPath = "./output_new";
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        ReservationSystem reservationSystem = new ReservationSystem(accPath, roomPath, roomInAccPath);

        // requirement 1
        List<Accommodation> req1 = reservationSystem.getAccommodations();
        foreach (var accommodation in req1)
        {
            Console.WriteLine(accommodation);
        }
        WriteFile(REQUIREMENT_OUTPUT_FILES[0], req1);
    }

    public static void Main(string[] args)
    {
        
        while (true) {
            Console.WriteLine("1.Tim kiem dich vu luu tru theo ten thanh pho.");
            Console.WriteLine("2.Dat dich vu phong.");
            Console.WriteLine("3.Huy dai phong");
            Console.WriteLine("4.Sua thong tin dat phong.");
            Console.WriteLine("6.Xuat hoa don.");
            Console.WriteLine("7.Thanh Toan.");
            Console.WriteLine("5.Thoat chuong trinh.");

            Console.WriteLine("Nhap Lua Chon Cua Ban");
            int option = int.Parse(Console.ReadLine());

            if (option == 1) {
                Console.WriteLine("Nhap Thanh Pho Ban Muon Tim Kiem: ");
                string city = Console.ReadLine();
                Console.WriteLine("Nhap Vao So Luong Nguoi Toi Da Ban Muon: ");
                int n = int.Parse(Console.ReadLine());
                seekForRooOfCity(city,n);

            }

            if (option == 2) {
                displayDataAcc();
            }



        }
    }




    }
