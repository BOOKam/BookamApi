using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookamApi.Models
{
    public class Payment
    {
        [Key]
        public int TransactionId {get; set;}
        public int BookingId {get; set;}
        public float Amount {get; set;}
        public PaymentMethod PaymentMethod {get; set;}
        public DateTime PayedAt {get; set;}
    }
    
    public enum PaymentMethod
    {
        Transfer,
        Cash
    }
}