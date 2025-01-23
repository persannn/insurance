using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Final_Version.Controllers
{
    public class InsurancesController(InsuranceManager insuranceManager) : Controller
    {
        /// <summary>
        /// Instance of a manager class that processes and returns insurance data.
        /// </summary>
        private readonly InsuranceManager insuranceManager = insuranceManager; 

        // GET: Insurances
        // I didn't delete this method or its views yet, but I don't expect this method to ever be used.
        /// <summary>
        /// Returns a list of all insurances in the database.
        /// </summary>
        /// <returns>A list of all insurances in the database.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await insuranceManager.GetAll());
        }

        // GET: Insurances/Details/5
        /// <summary>
        /// Returns the details of a single insurance.
        /// </summary>
        /// <param name="id">ID of the requested insurance.</param>
        /// <returns>ViewModel of the requested insurance.</returns>
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

        /// <summary>
        /// Returns a list of all insurances belonging to a customer.
        /// </summary>
        /// <param name="customerId">ID of the customer whose insurances will be displayed.</param>
        /// <returns>List of insurances of the customer whose ID was passed as parameter.</returns>
        public async Task<IActionResult> CustomerInsurances(int? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }

            IEnumerable<InsuranceViewModel> insurances = await insuranceManager.GetByCustomerId((int)customerId);
            ViewData["CustomerId"] = customerId;
            return View(insurances);
        }

        // GET: Insurances/Create
        /// <summary>
        /// Returns a form for adding a new insurance to the database.
        /// </summary>
        /// <param name="customerId">ID of the customer who owns the insurance.</param>
        /// <returns>Form for adding a new insurance to the database</returns>
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
        /// <summary>
        /// If the form is filled out correctly, the insurance is added to the database and
        /// the user is redirected to a list of all insurances owned by the customer.
        /// </summary>
        /// <param name="insuranceViewModel">ViewModel based on the submitted form.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns a form that lets the user edit the insurance.
        /// </summary>
        /// <param name="id">ID of the edited insurance.</param>
        /// <returns>ViewModel of the insurance about to be edited.</returns>
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
        /// <summary>
        /// If the submitted form is valid, the insurance information is passed to insuranceManager
        /// which will then tell insuranceRepository to update the insurance info in the database.
        /// </summary>
        /// <param name="id">ID of the updated insurance.</param>
        /// <param name="customerId">ID of the customer who owns the insurance.</param>
        /// <param name="insuranceViewModel">ViewModel based on the submitted form. </param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int customerId, [Bind("Id,CustomerId,InsuranceType,InsuranceValue")] InsuranceViewModel insuranceViewModel)
        {
            if (id != insuranceViewModel.Id || customerId != insuranceViewModel.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                InsuranceViewModel? updatedInsurance = await insuranceManager.Update(insuranceViewModel);
                return updatedInsurance is null ? NotFound() : RedirectToAction("Details", new { id = updatedInsurance.Id});
            }
            return View(insuranceViewModel);
        }

        // GET: Insurances/Delete/5
        /// <summary>
        /// Shows the information of the insurance about to be deleted from the database.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>ViewModel of the insurance that's about to be deleted.</returns>
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
        /// <summary>
        /// Upon user confirmation, this method tells insuranceManager to remove
        /// the insurance from the database.
        /// </summary>
        /// <param name="id">ID of the insurance about to be deleted.</param>
        /// <returns>Redirects the user to Index method of the Customers controller.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await insuranceManager.RemoveWithId(id);
            return RedirectToAction("Index", "Customers");
        }
    }
}
