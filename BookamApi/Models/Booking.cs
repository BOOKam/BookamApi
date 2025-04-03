using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Models
{
    public class Booking
    {
        [Key]
        public int BookingId {get; set;}
        public int UserId {get; set;}
        public int BusId{get; set;}
        public int RouteId {get; set;}
        public string SeatNumber {get; set;} = string.Empty;
        public DateTime BookingDate {get; set;}
        public PaymentStatus PaymentStatus {get; set;}
        public DateOnly CreatedAt {get; set;}
        
    }
    public enum PaymentStatus{
        completed,
        pending,
        failed,
    }
}