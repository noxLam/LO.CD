﻿using AutoMapper;
using LO.CD.Entities;
using LO.CD.Utils.Enums;
using LO.CD.Web.Models.Cars;
using System.ComponentModel.DataAnnotations;

namespace LO.CD.Web.Models.Deals
{
    public class DealViewModel
    {
        public DealViewModel()
        {
            Cars = new List<CarViewModel>();
            
        }
        public int Id { get; set; }

        [Display(Name = "Date")]
        public DateTime? DealDate { get; set; }

        [Display(Name ="Payment Medthod")]
        public PaymentMethod PaymentMethod { get; set; }
        public double Discount { get; set; }
        public double? Total { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        /*public CarViewModel? Cars { get; set; }*/

        public List<CarViewModel>? Cars { get; set; }

        public string? CarFullName { get; set; }
        
       

    }
    
}
