
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argensteam1.Models
{
    public class Soporte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo es requerido")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "El formato del mail es invalido")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Campo es requerido, y no puede estar vacio")]
        public string Mensaje   { get; set; }



    }
}
