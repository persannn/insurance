using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Final_Version.Controllers
{
    public class AddressesController(AddressManager addressManager) : Controller
    {
        /// <summary>
        /// Instance of a manager class that processes and returns address data.
        /// </summary>
        private readonly AddressManager addressManager = addressManager;

        // GET: Addresses
        /// <summary>
        /// Shows a list of all addresses stored in the database.
        /// </summary>
        /// <returns>A list of all Address entities in the database.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await addressManager.GetAll());
        }

        // GET: Addresses/Details/5
        /// <summary>
        /// Shows the address of a customer. The bool byCustomerId specifies whether
        /// the submitted Id is of an Address, or the Customer it belongs to.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="byCustomerId">bool that specifies whether the submitted ID is of the Customer or the Address.</param>
        /// <returns>AddressViewModel of the requested address.</returns>
        public async Task<IActionResult> Details(int? id, bool byCustomerId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await addressManager.GetById((int)id);

            // If the submitted Id was of a Customer, addressManager will instead get the
            // address with the corresponding CustomerId.
            if (byCustomerId)
            {
                address = await addressManager.GetByCustomerId((int)id);
            }

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        /// <summary>
        /// Returns a form for adding a new customer's address to the database.
        /// </summary>
        /// <param name="customerId">ID of the customer whose address will be created.</param>
        /// <returns>A form for creating a new address.</returns>
        public IActionResult Create(int? customerId)
        {
            if (customerId == null)
            {
                return BadRequest();
            }
            Address address = new Address((int)customerId);
            AddressViewModel addressViewModel = addressManager.mapper.Map<AddressViewModel>(address);
            return View(addressViewModel);
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// If the form was filled out correctly the address is added to the database,
        /// and the user is redirected to the list of customers.
        /// </summary>
        /// <param name="addressViewModel">AddressViewModel based on the submitted form.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel addressViewModel)
        {
            if (ModelState.IsValid)
            {
                await addressManager.Add(addressViewModel);
                return RedirectToAction("Index", "Customers", new { wasAdded = true});
            }
            return View(addressViewModel);
        }

        // GET: Addresses/Edit/5
        /// <summary>
        /// Returns a form that lets the user edit the customer's address.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="byCustomerId">bool that specifies whether the 'id' parameter is of the address or the customer it belongs to.</param>
        /// <returns>ViewModel of the address to be edited.</returns>
        public async Task<IActionResult> Edit(int? id, bool byCustomerId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await addressManager.GetById((int)id);

            if (byCustomerId)
            {
                address = await addressManager.GetByCustomerId((int)id);
            }

            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// If the submitted form is valid, the address information is passed to addressManager,
        /// which will then tell addressRepository to update the address info in the database.
        /// </summary>
        /// <param name="id">ID of the edited address.</param>
        /// <param name="addressViewModel">The edited AddressViewModel.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddressViewModel addressViewModel)
        {
            if(id != addressViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                AddressViewModel? updateAddress = await addressManager.Update(addressViewModel);

                return updateAddress is null ? NotFound() : RedirectToAction("Details", new { id = addressViewModel.Id});
            }
            return View(addressViewModel);
        }

        // GET: Addresses/Delete/5
        // I don't think there's any use for this method right now, since all addresses should only
        // be inserted and removed from the database with their corresponding Customer.
        /// <summary>
        /// Shows the information of the address about to be deleted from the database.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>ViewModel of the address that's about to be deleted.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressViewModel? addressViewModel = await addressManager.GetById((int)id);

            if (addressViewModel == null)
            {
                return NotFound();
            }

            return View(addressViewModel);
        }

        // POST: Addresses/Delete/5
        // I don't think there's any use for this method right now, since all addresses should only
        // be inserted and removed from the database with their corresponding Customer.
        /// <summary>
        /// Removes the address from the database and redirects the user to the list of customers.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Redirects the user to the list of customers.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await addressManager.RemoveWithId(id);
            return RedirectToAction("Index", "Customers");
        }
    }
}
