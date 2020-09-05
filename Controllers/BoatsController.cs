using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoatProject.Data;
using BoatProject.Models;
using BoatProject.Models.Repository;

namespace BoatProject.Controllers
{

    

    public class BoatsController : Controller
    {
        private readonly IDataRepository<Boat> _dataRepository;

        public BoatsController(IDataRepository<Boat> dataRepository)
        {
            _dataRepository = dataRepository;
        }
      
        // GET: Boats
        public async Task<IActionResult> Index()
        {
            return View(await _dataRepository.GetAll().ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var boat =  _dataRepository.Get(id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // GET: Boats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoatName,HourlyRate,isCurrentlyRented,CreatedDate")] Boat boat)
        {
            if (ModelState.IsValid)
            {
               int id= _dataRepository.Add(boat);
                return RedirectToAction(nameof(Index));
            }
            return View(boat);
        }

        // GET: Boats/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var boat =  _dataRepository.Get(id);
            if (boat == null)
            {
                return NotFound();
            }
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoatName,HourlyRate,isCurrentlyRented,CreatedDate")] Boat boat)
        {
            if (id != boat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataRepository.Update(id,boat);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatExists(boat.Id))
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
            return View(boat);
        }

        // GET: Boats/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var boat =  _dataRepository.Get(id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             _dataRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BoatExists(int id)
        {
            return _dataRepository.GetAll().Any(e => e.Id == id);
        }

        private bool BoatAlreadyInUse(int boatNumber)
        {
            return _dataRepository.GetAll().Any(e => e.Id == boatNumber);
        }

        // POST: Boats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignBoatToCustomer([Bind("Id,RentedByCustomerName")] Boat boat)
        {
            Boat boatDetail=_dataRepository.Get(boat.Id);

            if (boatDetail != null)
            {
                bool alreadyRented = boatDetail.isCurrentlyRented;

                if (alreadyRented)
                {
                    //Show error that boat is already in use
                    ViewBag.Message = "Boat is already in use";
                    ModelState.AddModelError("id ", "Boat Number does not exists");
                }
                else
                {
                    _dataRepository.AssignCustomerToBoatNumber(boat);
                    ViewBag.Message = "Success";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewBag.Message = "Boat Number does not exists";
                ModelState.AddModelError("id ", "Boat Number does not exists");
            }
            return View(boat);                      
        }

        // GET: Boats/Create
        public IActionResult AssignBoatToCustomer()
        {
            return View();
        }
    }
}
