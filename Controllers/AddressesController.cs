using Insurance_Final_Version.Managers;
using Insurance_Final_Version.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Final_Version.Controllers
{

    public class AddressesController(AddressManager addressManager) : Controller
    {
        private readonly AddressManager addressManager = addressManager;

        // GET: Addresses
        /// <summary>
        /// A regular user should never have the option to get to this action, but it could be useful
        /// to keep it in case an administrator wants to see all the stuff at once.
        /// </summary>
        /// <returns>a list of all Address entities in the database</returns>
        public async Task<IActionResult> Index()
        {
            return View(await addressManager.GetAll());
        }

        // GET: Addresses/Details/5
        /// <summary>
        /// The bool byCustomerId specifies whether the submitted Id is of an Address, or the corresponding Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="byCustomerId"></param>
        /// <returns></returns>
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
        public async Task<IActionResult> Create(int? customerId)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel addressViewModel)
        {
            if (ModelState.IsValid)
            {
                await addressManager.Add(addressViewModel);
                return RedirectToAction("Index", "Customers");
            }
            return View(addressViewModel);
        }

        // GET: Addresses/Edit/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddressViewModel addressViewModel)
        {
            if (ModelState.IsValid)
            {
                var updateAddress = await addressManager.Update(addressViewModel);

                return updateAddress is null ? NotFound() : RedirectToAction("Details", new { id = addressViewModel.Id, byCustomerId = false });
            }
            return View(addressViewModel);
        }

        // GET: Addresses/Delete/5
        /// <summary>
        /// I don't think there's any use for this method? Since all addresses should only
        /// be inserted and removed from the database with their corresponding Customer.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ViewModel of the address that's about to be deleted</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await addressManager.GetById((int)id);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        /// <summary>
        /// I don't think there's any use for this method? Since all addresses should only
        /// be inserted and removed from the database with their corresponding Customer.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Index View from CustomersController</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await addressManager.RemoveWithId(id);
            return RedirectToAction("Index", "Customers");
        }
    }
}
