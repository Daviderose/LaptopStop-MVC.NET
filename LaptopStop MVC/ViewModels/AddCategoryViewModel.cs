﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.ViewModels
{
    public class AddCategoryViewModel
    {
    [Required]
    [Display(Name = "Category Name")]
    public string Name { get; set; }
}
}
