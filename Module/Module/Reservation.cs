using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class Reservation
    {
        private int reservationId;
        private int accId;
        private int roomId;
        private DateTime checkin;  // thời điểm mà khách hàng đặt phòng.
        private DateTime checkout; // thời điểm mà khách hàng dự kiến trả phòng.

        public int ReservationId { get => reservationId; set => reservationId = value; }
        public int AccId { get => accId; set => accId = value; }
        public int RoomId { get => roomId; set => roomId = value; }
        public DateTime Checkin { get => checkin; set => checkin = value; }
        public DateTime Checkout { get => checkout; set => checkout = value; }

        public Reservation() { }
        public Reservation(int reservationId, int accId, int roomId, DateTime checkin, DateTime checkout)
        {
            ReservationId = reservationId;
            AccId = accId;
            RoomId = roomId;
            Checkin = checkin;
            Checkout = checkout;
        }
        public string toString()
        {
            string s = $"Ma dinh danh dat phong: {ReservationId}, Ma dinh danh luu tru: {AccId}, Ma dinh danh phong: {RoomId}, Thoi gian checkin: {Checkin}, Thoi gian checkout: {Checkout}";
            return s;
        }
    }
}
