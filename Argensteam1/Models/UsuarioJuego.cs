using System.ComponentModel.DataAnnotations;

namespace Argensteam1.Models
{
    public class UsuarioJuego
    {
       
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int JuegoId { get; set; }
        public Juego Juego { get; set; }
        public char tipoLista { get; set; }
    }
}