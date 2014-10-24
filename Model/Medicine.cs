using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedApp.Model
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long Qty { get; set; }
    }

    public class Purchase
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string NameOfProduct { get; set; }
        public double MRP { get; set; }
        public long Pack { get; set; }
        public string BatchNo { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public double Rate { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Dealers
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double AdvancedPaid { get; set; }
        public double DuePayment { get; set; }
        public DateTime Date { get; set; }
    }

    public class Customer
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double DuePayment { get; set; }
        public DateTime Date { get; set; }
    }

    public class Sell
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string NameOfProduct { get; set; }
        public double MRP { get; set; }
        public long Pack { get; set; }
        public string BatchNo { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public double Rate { get; set; }
    }
}
