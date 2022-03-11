using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Autobus
    {
        [Key]
        public int BusID  { get; set; }

        [Required]
        [MaxLength(30)]
        public string NazivPrevoznika {get; set;}

        // [Required]
        // [Range(1,16)]
        // public int BrojSedista { get; set; }

        //public bool slobodnoMesto{ get; set;}

        [Required]
        [MaxLength(30)]
        public string Destinacija { get; set; }

        [JsonIgnore]
        public virtual List<Putnik> ListaPutnika { get; set; }

        [JsonIgnore]
        public virtual List<Karta> ListaKarata {get; set; }

    }
}