using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public class CustomerDetail
    {
        [Key]
        public Guid customerId { get; set; }
        [Required]
        public string customerFirstName { get; set; }
        [Required]
        public string customerLastName { get; set; }
        [Required]
        public string customerAddress { get; set; }
        [Required]
        public string customerPostalCode { get; set; }
        [Required]
        public string customerMobileNumber { get; set; }
        [Required]
        [EmailAddress]
        public string customerEmail { get; set; }
    }
}
