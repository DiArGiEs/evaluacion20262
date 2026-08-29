using Microsoft.AspNetCore.Mvc;
using evaluacion20262.Data;
using evaluacion20262.Models;

namespace evaluacion20262.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Solicitud/Crear
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        // POST: /Solicitud/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                // Asignar fecha actual en servidor por seguridad
                solicitud.FechaRegistro = DateTime.Now;

                // Inserción en SQLite (EF Core)
                _context.Add(solicitud);
                await _context.SaveChangesAsync();

                // Mensaje de confirmación usando TempData
                TempData["MensajeExito"] = "¡La solicitud de servicio fue registrada con éxito!";

                return RedirectToAction(nameof(Crear));
            }

            // Si falla la validación, recarga la vista mostrando los errores
            return View(solicitud);
        }
    }
}