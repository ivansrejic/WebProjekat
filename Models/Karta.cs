using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using System;

namespace Models
{
    public class Karta
    {
        [Key]
        public int KartaID {get; set;}

        [Required]
        [Range(1,16)]
        public int BrojSedista { get; set; }
        
        [Required]
        [Range(100,2000)]
        public int Cena { get; set; }

        public virtual Putnik PutnikFK { get; set; }

        public virtual Autobus AutobusFK {get; set;}

    }
}