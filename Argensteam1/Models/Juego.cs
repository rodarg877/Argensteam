using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Argensteam1.Models
{
    public class Juego
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string urllVideo { get; set; }
        public string Imagenes { get; set; }
        [EnumDataType(typeof(Categoria))]

        public Categoria Categoria { get; set; }

        public ICollection<UsuarioJuego> Usuarios { get; set; }
        public double Precio { get; set; }

        //public Juego(int Id, string Name, double precio, string Descripcion, Categoria Categoria)
        //{
        //    this.Id = Id;
        //    this._precio = precio;
        //    this.Name = Name;
        //    this.Descripcion = Descripcion;
        //    this.Categoria = Categoria;
        //    this.Imagenes = new List<string>();
        //}
    }
}
