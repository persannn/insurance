using Insurance_Two_Tables.Managers;
using Insurance_Two_Tables.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Two_Tables.Controllers
{
    public class CustomersController(CustomerManager customerManager, AddressManager addressManager) : Controller
    {
        private readonly CustomerManager customerManager = customerManager;
        private readonly AddressManager addressManager = addressManager;

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

            var customerViewModel = await customerManager.GetCustomerById((int)id);
            var addressViewModel = await addressManager.GetAddressByCustomerId((int) id);

            Customer customer = addressManager.mapper.Map<Customer>(customerViewModel);
            Address address = addressManager.mapper.Map<Address>(addressViewModel);

            CustomerAddress customerAddress = new CustomerAddress(customer, address);

            if (customer == null || address == null)
            {
                return NotFound();
            }

            // Need to make a CustomerAddressViewModel class, map it to CustomerAddress,
            // and return that as a view.
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
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Age,Insurance")] CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                await customerManager.AddCustomer(customer);
                return RedirectToAction("Create", "Addresses");
            }
            return View(customer);
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
