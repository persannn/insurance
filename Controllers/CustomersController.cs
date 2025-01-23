using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Final_Version.Controllers
{
    /// <summary>
    /// Controller of Customer entities, has a CustomerManager class
    /// from which it requests processed customer data.
    /// </summary>
    /// <param name="customerManager">Instance of a manager class that processes and returns customer data.</param>
    public class CustomersController(CustomerManager customerManager) : Controller
    {
        /// <summary>
        /// Instance of a manager class that processes and returns customer data.
        /// </summary>
        private readonly CustomerManager customerManager = customerManager;

        // GET: Customers
        /// <summary>
        /// Shows a list of all customers in the database.
        /// </summary>
        /// <param name="wasAdded">Parameter that specifies whether a customer was just added.</param>
        /// <param name="wasDeleted">Parameter that specifies whether a customer was just deleted.</param>
        /// <returns>A view containing a list of all customers in the database.</returns>
        public async Task<IActionResult> Index(bool wasAdded = false, bool wasDeleted = false)
        {
            ViewBag.WasAdded = wasAdded;
            ViewBag.WasDeleted = wasDeleted;
            return View(await customerManager.GetAllCustomers());
        }

        // GET: Customers/Details/5
        /// <summary>
        /// Shows the personal details of a customer if the customer
        /// with the submitted ID exists in the database.
        /// </summary>
        /// <param name="id">ID of the desired customer.</param>
        /// <param name="wasEdited">Parameter that specifies whether the customer was just edited.</param>
        /// <returns>Personal details of the customer.</returns>
        public async Task<IActionResult> Details(int? id, bool wasEdited = false)
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
            ViewBag.WasEdited = wasEdited;
            return View(customerViewModel);
        }

        // GET: Customers/Create
        /// <summary>
        /// Returns a form for adding a new customer to the database.
        /// </summary>
        /// <returns>A form for adding a new customer to the database.</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// If the form is filled out correctly the user is redirected to a form
        /// for adding the new customer's address, otherwise they're prompted to
        /// fill out the form correctly.
        /// </summary>
        /// <param name="customerViewModel">Customer view model based on the user submitted form.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns a form that lets the user edit customer parameters.
        /// </summary>
        /// <param name="id">ID of the customer about to be edited.</param>
        /// <returns>ViewModel of the customer to be edited.</returns>
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
        /// <summary>
        /// If the submitted form is valid, the customer informaton is passed to customerManager,
        /// which will then tell customerRepository to update the customer info in the database.
        /// </summary>
        /// <param name="id">ID of the edited customer.</param>
        /// <param name="customer">The edited CustomerViewModel.</param>
        /// <returns></returns>
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

                // The 'wasEdited' parameter tells the Details() method that the customer information was just edited.
                return updatedCustomer is null ? NotFound() : RedirectToAction("Details", "Customers", new { id = updatedCustomer.Id, wasEdited = true});
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        /// <summary>
        /// Shows the personal information of the customer about to be
        /// deleted from the database, and requests a confirmation.
        /// </summary>
        /// <param name="id">ID of the customer about to be deleted.</param>
        /// <returns>ViewModel of the customer about to be deleted.</returns>
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
        /// <summary>
        /// Upon user confirmation, this method tells customerManager to remove
        /// the customer from the database.
        /// </summary>
        /// <param name="id">ID of the customer about to be deleted.</param>
        /// <returns>Redirects the user to Index method of the Customers controller.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await customerManager.RemoveCustomerWithId(id);

            //The wasDeleted parameter tells the Index() method that a customer was just removed from the database.
            return RedirectToAction(nameof(Index), new { wasDeleted = true});
        }
    }
}
