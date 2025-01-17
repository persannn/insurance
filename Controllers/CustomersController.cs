using Insurance_Two_Tables.Managers;
using Insurance_Two_Tables.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Two_Tables.Controllers
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

            var customer = await customerManager.GetCustomerById((int)id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
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
            if(ModelState.IsValid)
            {
                Customer customer = await customerManager.AddCustomer(customerViewModel);
                return RedirectToAction(nameof(Index));
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

            var customer = await customerManager.GetCustomerById((int)id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,AddressId,Name,Surname,Age,Insurance")] CustomerViewModel customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedCustomer = await customerManager.UpdateCustomer(customer);

                return updatedCustomer is null ? NotFound() : RedirectToAction(nameof(Index));
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

            var customer = await customerManager.GetCustomerById((int)id);

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
