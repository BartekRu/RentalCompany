using Microsoft.AspNetCore.Mvc;
using Wypozyczalnia1.Data;
using Wypozyczalnia1.Models;

namespace Wypozyczalnia1.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public VehicleController(IRepository<Vehicle> vehicleRepository, IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;

        }

        // GET: Vehicle
        
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();

            var viewModels = vehicles.Select(v => new VehicleItemViewModel
            {
                Id = v.Id,
                Name = v.Model,
                Type = v.Type, //!= null ? v.VehicleType.Name : "Nieznany",
                PricePerHour = v.PricePerDay,
                ImageUrl = v.ImageURL //"././hulajonga.webp" 
            }).ToList();

            return View(viewModels);
        }

        // GET: Vehicle/Create
        public async Task <IActionResult> Create()
        {
            var vehicleTypes = await _vehicleTypeRepository.GetAllAsync();
            ViewBag.VehicleTypes = vehicleTypes;
            return View(new VehicleDetailViewModel());
        }

        // POST: Vehicle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle
                {
                    Make = model.Make,
                    Model = model.Model,
                    Year = model.Year,
                    //Type = model.Type
                };

                await _vehicleRepository.AddAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var model = new VehicleDetailViewModel
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                //Type = vehicle.Type
            };

            return View(model);
        }
        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var viewModel = new VehicleDetailViewModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Type = vehicle.Type, //!= null ? vehicle.VehicleType.Name : "Nieznany",
                PricePerHour = 90,
                ImageUrl = "/images/cross.jpg",
                Description = vehicle.Description
            };
            return View(viewModel);
        }


        // POST: Vehicle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleDetailViewModel model)//VehicleItemViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle
                {
                    Id = model.Id,
                    Make = model.Make,
                    Model = model.Model,
                    Year = model.Year,
                    //Type = model.Type
                };

                await _vehicleRepository.UpdateAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vehicleRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
