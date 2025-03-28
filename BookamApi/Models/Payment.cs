using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Models
{
    public class Payment
    {
        public int TransactionId {get; set;}
        public int BookingId {get; set;}
        public float amount {get; set;}
        public PaymentMethod paymentMethod {get; set;}
        public DateTime PayedAt {get; set;}
    }
    
    public enum PaymentMethod
    {
        Transfer,
        Cash
    }
}