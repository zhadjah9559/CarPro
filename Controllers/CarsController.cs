using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarPro.Data;
using CarPro.Models;

namespace CarPro.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string sortOrder)
        {
            if (sortOrder != null)
            {
                var cars = _context.Cars.AsQueryable();

                switch (sortOrder)
                {
                    //In case the user hits the down arrow, order the table in a descending form
                    case "ModelYearDescending":
                        cars = cars.OrderByDescending(e => e.ModelYear);
                        break;
                    case "IdDescending":
                        cars = cars.OrderByDescending(e => e.Id);
                        break;
                    case "LotDescending":
                        cars = cars.OrderByDescending(e => e.Lot);
                        break;
                    case "LotIdDescending":
                        cars = cars.OrderByDescending(e => e.LotId);
                        break;
                    case "MakeDescending":
                        cars = cars.OrderByDescending(e => e.Make);
                        break;
                    case "MileageDescending":
                        cars = cars.OrderByDescending(e => e.Mileage);
                        break;
                    case "ModelDescending":
                        cars = cars.OrderByDescending(e => e.Model);
                        break;
                    case "PriceDescending":
                        cars = cars.OrderByDescending(e => e.Price);
                        break;
                    case "ColorDescending":
                        cars = cars.OrderByDescending(e => e.Color);
                        break;
                    case "DriveTrainDescending":
                        cars = cars.OrderByDescending(e => e.DriveTrain);
                        break;


                    //In case the user hits the up arrow, order the table in a ascending form
                    case "ModelYearAscending":
                        cars = cars.OrderBy(e => e.ModelYear);
                        break;
                    case "IdAscending":
                        cars = cars.OrderBy(e => e.Id);
                        break;
                    case "LotAscending":
                        cars = cars.OrderBy(e => e.Lot);
                        break;
                    case "LotIdAscending":
                        cars = cars.OrderBy(e => e.LotId);
                        break;
                    case "MakeAscending":
                        cars = cars.OrderBy(e => e.Make);
                        break;
                    case "MileageAscending":
                        cars = cars.OrderBy(e => e.Mileage);
                        break;
                    case "ModelAscending":
                        cars = cars.OrderBy(e => e.Model);
                        break;
                    case "PriceAscending":
                        cars = cars.OrderBy(e => e.Price);
                        break;
                    case "ColorAscending":
                        cars = cars.OrderBy(e => e.Color);
                        break;
                    case "DriveTrainAscending":
                        cars = cars.OrderBy(e => e.DriveTrain);
                        break;


                    default:
                        cars = cars.OrderByDescending(s => s.Model);
                        break;
                }
                return View(cars.ToList());
            }
            var applicationDbContext = _context.Cars.Include(c => c.Lot);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Lot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ManagerName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LotId,Make,Model,ModelYear,Mileage,Price,Color,DriveTrain")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ManagerName", car.LotId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ManagerName", car.LotId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,ModelYear,Mileage,Price,Color,DriveTrain,LotId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ManagerName", car.LotId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Lot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
