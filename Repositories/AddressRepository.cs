﻿using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Repositories
{
    public class AddressRepository(ApplicationDbContext dbContext) : BaseRepository<Address>(dbContext), IAddressRepository
    {
    }
}
