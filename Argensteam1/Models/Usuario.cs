using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argensteam1.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        private string _username;
        private string _password;
        private string _email;
        public string FotoPerfil { get; set; }
        public ICollection<UsuarioJuego> UsuarioJuegos { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        //    public Usuario(string Username, string Password, string Email)
        //    {
        //        this.Username = Username;
        //        this.Password = Password;
        //        this.Email = Email;
        //        this.Juegos = new List<Juego>();
        //        this.Whishlist = new List<Juego>();
        //    }


        //    public Boolean comprar(Juego juego)
        //    {
        //        Boolean result = false;
        //        if (juego != null && !Juegos.Contains(juego))
        //        {
        //            this.Juegos.Add(juego);
        //            result = true;
        //        }

        //        return result;
        //    }

        //    public Boolean agregarWhishlist(Juego juego)
        //    {
        //        Boolean exito = false;
        //        if (juego != null && !Whishlist.Contains(juego))
        //        {
        //            this.Whishlist.Add(juego);
        //            exito = true;
        //        }

        //        return exito;
        //    }

        //}
    }
}
