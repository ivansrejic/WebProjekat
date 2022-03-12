using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Models 
{
    public class Putnik
    {
        [Key]
        public int putnikID { get; set; }   

        [Required]
        [MaxLength(25)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(25)]
        public string Prezime { get; set; }

        [Required]
        [MaxLength(13)]
        public string JMBG { get; set; }

        // public Autobus PutnikAutobus { get; set; }
    }
}