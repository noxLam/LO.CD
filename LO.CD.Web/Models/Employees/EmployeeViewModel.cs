﻿using LO.CD.Utils.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LO.CD.Web.Models.Employees
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            BranchIds = new List<int>();
        }
        public int Id { get; set; }
        [Display (Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public int Sallary { get; set; }
        public List<int> BranchIds { get; set; }

        [ValidateNever]
        public MultiSelectList MultiSelectBranches { get; set; }
    }
}
