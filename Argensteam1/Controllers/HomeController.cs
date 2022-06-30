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



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //-------------------------------------------------------------
        private readonly ArgensteamDatabaseContext _context;

      

        // GET: Juego
        public async Task<IActionResult> Index(int? idCategoria)
        {
            //if (idCategoria != null)
            //{
            //    return View(_context.Juegos.Where(j => int.Parse(j.Categoria) == idCategoria));
            //}
            
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

                return RedirectToAction(nameof(Index));
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

        //GET: Soporte
        public IActionResult Soporte() { 
            return View();
        }

        //GET: Noticias
        public async Task<IActionResult> Noticias()
        {
            return View(await _context.Noticias.ToListAsync());
        }

        //GET: Soporte
        public async Task<IActionResult> Perfil()
        {
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
                //foreach (UsuarioJuego uj in _context.UsuarioJuegos.Where(uj => uj.UsuarioId == int.Parse(idUser)))
                //{
                //    uj.Juego = _context.Juegos.FirstOrDefaultAsync();
                //    u.UsuarioJuegos.Add(uj);
                //}
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
                if (await _context.Usuarios.FirstOrDefaultAsync(m => m.Username == usuario.Username) == null)
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.SetString("default", usuario.UserId.ToString());
                    return RedirectToAction(nameof(Perfil));
                }
                else
                {
                    //alert addModelError
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

            _context.Add(uj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Perfil));

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

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            UsuarioJuego uj = new UsuarioJuego();
            uj.JuegoId = juego.Id;
            uj.UsuarioId = user.UserId;
            uj.tipoLista = 'W';

            _context.Add(uj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Perfil));

        }

        // GET: Juego/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juego/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descripcion,urllVideo,Imagenes,Categoria,Precio")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juego);
        }

        // GET: Juego/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos.FindAsync(id);
            if (juego == null)
            {
                return NotFound();
            }
            return View(juego);
        }

        // POST: Juego/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descripcion,urllVideo,Imagenes,Categoria,Precio")] Juego juego)
        {
            if (id != juego.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuegoExists(juego.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(juego);
        }

        // GET: Juego/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Juego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juego = await _context.Juegos.FindAsync(id);
            _context.Juegos.Remove(juego);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegoExists(int id)
        {
            return _context.Juegos.Any(e => e.Id == id);
        }
    }
}

