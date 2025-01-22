using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Final_Version.Controllers
{
    public class CustomersController(CustomerManager customerManager) : Controller
    {
        private readonly CustomerManager customerManager = customerManager;

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await customerManager.GetAllCustomers());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerViewModel? customerViewModel = await customerManager.GetById((int)id, true);

            if (customerViewModel == null)
            {
                return NotFound();
            }
            IEnumerable<InsuranceViewModel> insuranceViewModels = customerManager.mapper.Map<List<InsuranceViewModel>>(customerViewModel.Insurances);
            ViewData["Insurances"] = insuranceViewModels;
            return View(customerViewModel);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomerViewModel addedCustomer = await customerManager.AddCustomer(customerViewModel);
                return RedirectToAction("Create", "Addresses", new { customerId = addedCustomer.Id });
            }
            return View(customerViewModel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerViewModel? customer = await customerManager.GetById((int)id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Age,PhoneNumberPrefix,PhoneNumber,Email")] CustomerViewModel customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CustomerViewModel? updatedCustomer = await customerManager.UpdateCustomer(customer);

                return updatedCustomer is null ? NotFound() : RedirectToAction("Details", "Customers", new { id = updatedCustomer.Id});
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await customerManager.GetById((int)id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await customerManager.RemoveCustomerWithId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
