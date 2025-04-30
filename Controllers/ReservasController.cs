using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinedaLuis_EvaluacionP1.Models;

namespace PinedaLuis_EvaluacionP1.Controllers
{
    public class ReservasController : Controller
    {
        private readonly PinedaL_Prueba1P _context;

        public ReservasController(PinedaL_Prueba1P context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var reservas = _context.Reserva.Include(r => r.Cliente);
            return View(await reservas.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            return reserva == null ? NotFound() : View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            CargarClientesDropDownList();
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,FechaEntrada,FechaSalida,ClienteId")] Reserva reserva)
        {
            if (reserva.FechaSalida <= reserva.FechaEntrada)
            {
                ModelState.AddModelError("FechaSalida", "La fecha de salida debe ser posterior a la fecha de entrada.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Debug de errores
            foreach (var key in ModelState.Keys)
            {
                var state = ModelState[key];
                foreach (var error in state.Errors)
                {
                    Console.WriteLine($"Error en campo '{key}': {error.ErrorMessage}");
                }
            }

            CargarClientesDropDownList(reserva.ClienteId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null) return NotFound();

            CargarClientesDropDownList(reserva.ClienteId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,FechaEntrada,FechaSalida,ClienteId")] Reserva reserva)
        {
            if (id != reserva.IdReserva) return NotFound();

            if (reserva.FechaSalida <= reserva.FechaEntrada)
            {
                ModelState.AddModelError("FechaSalida", "La fecha de salida debe ser posterior a la fecha de entrada.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            CargarClientesDropDownList(reserva.ClienteId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            return reserva == null ? NotFound() : View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }

        private void CargarClientesDropDownList(object selectedCliente = null)
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nombre", selectedCliente);
        }
    }
}
