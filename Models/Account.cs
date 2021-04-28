using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TranferAPI.Models
{
    public class Account
    {
        [Key]
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Please insert your Name...")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Please insert Amount...")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        
        [Required(ErrorMessage = "Please state a description...")]
        public string Description { get; set; }
        public string AccountNumber { get; set; }


        
    }
}