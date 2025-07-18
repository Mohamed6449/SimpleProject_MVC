﻿using MCV_Empity.Helper;
using MCV_Empity.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCV_Empity.Models
{
    public class product: LocalizableEntity
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("category")]

        public int CategoryId { get; set; }

        public Category? category { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; } = new HashSet<ProductImages>();
    }
}
