using System.Linq;
using Argensteam1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Argensteam1.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;

namespace Argensteam1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ArgensteamDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //-------------------------------------------------------------
        private readonly ArgensteamDatabaseContext _context;

      

        // GET: Juego
        public async Task<IActionResult> Index(Categoria? idCategoria)
        {
            if (idCategoria != null)
            {
                return View(_context.Juegos.Where(j => (j.Categoria ==idCategoria)));
            }

            ViewBag.sesion = HttpContext.Session.GetString("default");
            return View(await _context.Juegos.ToListAsync());
        }


        public async Task<IActionResult> Sesion(Usuario usuario)
        {
            if (usuario == null)
            {
                return NotFound();
            }

            var u = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Username == usuario.Username);
            if (u == null)
            {
                return NotFound();
            }
            if (u.Password.Equals(usuario.Password))
            {
                HttpContext.Session.SetString("default", u.UserId.ToString());

                return RedirectToAction(nameof(Perfil));
            }
            else
            {
                return NotFound();
            }
        }


        //GET:inicioSession
        public IActionResult InicioSesion()
        {
        return View();
        }
        //GET: Registro
        public IActionResult Registro()
        {
            return View();
        }

        //GET: Nueva Contrasenia
        public IActionResult NuevaContrasenia()
        {
            return View();
        }

        //GET: Soporte
        public IActionResult Soporte() {
            ViewBag.sesion = HttpContext.Session.GetString("default");
            return View();
        }

        //GET: Noticias
        public async Task<IActionResult> Noticias()
        {
            ViewBag.sesion = HttpContext.Session.GetString("default");
            return View(await _context.Noticias.ToListAsync());
        }

        public IActionResult Deslogueo()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        //GET: Perfil
        public async Task<IActionResult> Perfil()
        {
            ViewBag.sesion = HttpContext.Session.GetString("default");
            String idUser = HttpContext.Session.GetString("default");
            if (idUser == null)
            {
                return RedirectToAction(nameof(InicioSesion));
            } 
            else
            {
                
                Usuario u = await _context.Usuarios.FirstOrDefaultAsync(m => m.UserId == int.Parse(idUser));
                List<UsuarioJuego> uj =  _context.UsuarioJuegos.Where(uj => uj.UsuarioId == u.UserId).ToList();
                foreach (UsuarioJuego usuJue in uj)
                {
                    usuJue.Usuario = u;
                    usuJue.Juego = await _context.Juegos.FirstOrDefaultAsync(j => j.Id == usuJue.JuegoId);
                }
                u.UsuarioJuegos = uj;
                ViewBag.ContBiblio = _context.UsuarioJuegos.Count(m => m.UsuarioId == int.Parse(idUser) && m.tipoLista.Equals('B'));
                ViewBag.Contwhish = _context.UsuarioJuegos.Count(m => m.UsuarioId == int.Parse(idUser) && m.tipoLista.Equals('W'));
                //foreach (UsuarioJuego uj in _context.UsuarioJuegos.Where(uj => uj.UsuarioId == int.Parse(idUser)))
                //{
                //    uj.Juego = _context.Juegos.FirstOrDefaultAsync();
                //    u.UsuarioJuegos.Add(uj);
                //}
                return View(u);
            }
        }

        public async Task<IActionResult> CambiarImagen()
        {
            ViewBag.sesion = HttpContext.Session.GetString("default");
            String idUser = HttpContext.Session.GetString("default");
            if (idUser == null)
            {
                return RedirectToAction(nameof(InicioSesion));
            }
            else
            {
                Usuario u = await _context.Usuarios.FirstOrDefaultAsync(m => m.UserId == int.Parse(idUser));
                return View(u);
            }
        }

        // POST: Home/Registro

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("UserId,Username,Password,Email")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(usuario.Email!= null)
                {
                    if (await _context.Usuarios.FirstOrDefaultAsync(m => m.Username == usuario.Username) == null)
                    {
                        _context.Add(usuario);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.SetString("default", usuario.UserId.ToString());
                        return RedirectToAction(nameof(Perfil));
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "ya existe un usuario con ese nombre");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "El Email es campo obligatorio");
                }
            }
               
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> NuevaContrasenia(Usuario usuario, String contraseniaRepetida)
        {
            if (ModelState.IsValid)
            {
                Usuario u = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == usuario.Username);

                if (u != null)
                {
                    if (usuario.Password.Equals(contraseniaRepetida))
                    {
                        u.Password = contraseniaRepetida;
                        _context.Update(u);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(InicioSesion));
                    }
                    else {
                        ModelState.AddModelError("Password", "no coinciden los passwords");
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("Username", "usuario incorrecto");
                }
                
            }
            return View(usuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Soporte([Bind("Nombre,Email,Mensaje")] Soporte soporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soporte);
                await _context.SaveChangesAsync();
                return Content("<script language='javascript' type='text/javascript'>alert('Gracias por tu comentario');</script>");
            }
            return View(soporte);
        }
        // GET: Juego/Juegos/5
        public async Task<IActionResult> Juegos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // Comprar
        public async Task<IActionResult> Comprar(int? id)
        {
            String idUser = HttpContext.Session.GetString("default");
            Usuario user;
            if (idUser == null)
            {
                return RedirectToAction(nameof(InicioSesion));
            }
            else
            {
                user = await _context.Usuarios.FirstOrDefaultAsync(m => m.UserId == int.Parse(idUser));
            }


            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            UsuarioJuego uj = new UsuarioJuego();
            uj.JuegoId = juego.Id;
            uj.UsuarioId = user.UserId;
            uj.tipoLista = 'B';
            UsuarioJuego buscado = await _context.UsuarioJuegos.FirstOrDefaultAsync(m => m.UsuarioId == uj.UsuarioId && m.JuegoId == uj.JuegoId);

            if (buscado == null)
            {
                _context.Add(uj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Perfil));
            }
            else if (buscado.tipoLista.Equals('W'))
            {
                buscado.tipoLista = 'B';
                _context.Update(buscado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Perfil));
            }
            else
            {
                TempData["msg"] = "<script>alert('Ya se encuentra en la biblioteca');</script>";
            }

            return RedirectToAction("Juegos", new { id });
        }
        // Boton whishlist
        public async Task<IActionResult> Whishlist(int? id)
        {
            String idUser = HttpContext.Session.GetString("default");
            Usuario user;
            if (idUser == null)
            {
                return RedirectToAction(nameof(InicioSesion));
            }
            else
            {
                user = await _context.Usuarios.FirstOrDefaultAsync(m => m.UserId == int.Parse(idUser));
            }


            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos.FirstOrDefaultAsync(m => m.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            UsuarioJuego uj = new UsuarioJuego();
            uj.JuegoId = juego.Id;
            uj.UsuarioId = user.UserId;
            uj.tipoLista = 'W';
            UsuarioJuego buscado = await  _context.UsuarioJuegos.FirstOrDefaultAsync(m => m.UsuarioId == uj.UsuarioId && m.JuegoId == uj.JuegoId );
           
            if (buscado==null)
            {
                _context.Add(uj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Perfil));
            }
            else
            {
                TempData["msg"] = "<script>alert('Ya se encuentra en la whishlist o en la biblioteca');</script>";
            }
           
           return RedirectToAction("Juegos", new { id });
        }
    }
}

