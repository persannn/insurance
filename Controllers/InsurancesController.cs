using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Final_Version.Controllers
{
    public class InsurancesController(InsuranceManager insuranceManager) : Controller
    {
        private readonly InsuranceManager insuranceManager = insuranceManager; 

        // GET: Insurances
        public async Task<IActionResult> Index()
        {
            return View(await insuranceManager.GetAll());
        }

        // GET: Insurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InsuranceViewModel? insuranceViewModel = await insuranceManager.GetById((int)id);
            if (insuranceViewModel == null)
            {
                return NotFound();
            }

            return View(insuranceViewModel);
        }

        public async Task<IActionResult> CustomerInsurances(int? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }

            List<InsuranceViewModel> insurances = await insuranceManager.GetByCustomerId((int)customerId);
            ViewData["CustomerId"] = customerId;
            return View(insurances);
        }

        // GET: Insurances/Create
        public IActionResult Create(int? customerId)
        {
            if (customerId == null)
            {
                return BadRequest();
            }
            Insurance insurance = new Insurance((int)customerId);
            InsuranceViewModel insuranceViewModel = insuranceManager.mapper.Map<InsuranceViewModel>(insurance);
            return View(insuranceViewModel);
        }

        // POST: Insurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsuranceViewModel insuranceViewModel)
        {
            if (ModelState.IsValid)
            {
                await insuranceManager.Add(insuranceViewModel);
                return RedirectToAction("CustomerInsurances", "Insurances", new { customerId = insuranceViewModel.CustomerId});
            }
            return View(insuranceViewModel);
        }

        // GET: Insurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InsuranceViewModel? insuranceViewModel = await insuranceManager.GetById((int)id);
            if (insuranceViewModel == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = insuranceViewModel.CustomerId;
            return View(insuranceViewModel);
        }

        // POST: Insurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int customerId, [Bind("Id,CustomerId,InsuranceType,InsuranceValue")] InsuranceViewModel insurance)
        {
            if (id != insurance.Id || customerId != insurance.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                InsuranceViewModel? updatedInsurance = await insuranceManager.Update(insurance);
                return updatedInsurance is null ? NotFound() : RedirectToAction("Details", new { id = updatedInsurance.Id});
            }
            return View(insurance);
        }

        // GET: Insurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InsuranceViewModel? insuranceViewModel = await insuranceManager.GetById((int)id);

            if (insuranceViewModel == null)
            {
                return NotFound();
            }

            return View(insuranceViewModel);
        }

        // POST: Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await insuranceManager.RemoveWithId(id);
            return RedirectToAction("Index", "Customers");
        }
    }
}
