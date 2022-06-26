using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transaction.Models
{
    public class TransactionModel
    {

        [Key]
        public int TransId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("First Name")]
        //[Column(TypeBase = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        //[Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Email")]
        //[Column(TypeBase = "nvarchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Phone Number")]
        //[Column(TypeBase = "nvarchar(100)")]
        public string Phone { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Acc Num")]
        //[Column(TypeName = "nvarchar(100)")]
        public string AccNum { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Bank")]
        //[Column(TypeBase = "nvarchar(100)")]
        public string Bank { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Amount")]
        public int Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

    }
}
