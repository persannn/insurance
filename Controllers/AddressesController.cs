using Insurance_Two_Tables.Managers;
using Insurance_Two_Tables.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Two_Tables.Controllers
{
    public class AddressesController(AddressManager addressManager) : Controller
    {
        private readonly AddressManager addressManager = addressManager;

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            return View(await addressManager.GetAllAddresses());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var address = await addressManager.GetAddressById((int)Id);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public async Task<IActionResult> Create(int? id, int? customerId)
        {
            if (id == null || customerId == null)
            {
                return BadRequest();
            }
            int notNullId = id ?? 0;
            int notNullCustomerId = customerId ?? 0;
            AddressViewModel addressViewModel = await addressManager.AddAddress(notNullId, notNullCustomerId);
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
                await addressManager.AddAddress(addressViewModel);
                return RedirectToAction("Index", "Customers");
            }
            return View(addressViewModel);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await addressManager.GetAddressById((int)id);

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
        public async Task<IActionResult> Edit(int id, [Bind("Street,HouseNumber,RegistryNumber,City")] AddressViewModel address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateAddress = await addressManager.UpdateAddress(address);

                return updateAddress is null? NotFound() : RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await addressManager.GetAddressById((int)id);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await addressManager.RemoveAddressWithId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
