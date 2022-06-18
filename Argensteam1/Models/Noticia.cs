using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argensteam1.Models
{
    public class Noticia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }


        //public Noticia(string Titulo, string Descripcion, string Url)
        //{
        //    this.Titulo = Titulo;
        //    this.Descripcion = Descripcion;
        //    this.Url = Url;
        //}
    }
}
