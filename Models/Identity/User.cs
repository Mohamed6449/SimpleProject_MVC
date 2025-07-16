﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MCV_Empity.Models.Identity
{
    public class User:IdentityUser
    {
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
    
        public string? Address { get; set; }
    }
}
