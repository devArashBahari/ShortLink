using Data.Context;
using Domain.Interface;
using Domain.Models.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ShortLinkContext _context;
        public PersonRepository(ShortLinkContext context)
        {
            _context = context;
        }

        public async Task AddPerson(Person person)
        {
            await _context.Person.AddAsync(person);
        }

        public async ValueTask DisposeAsync()
        {
            if (_context != null) await _context.DisposeAsync();
        }

        public async Task<List<Person>> GetAllAsync()
        {
           return await _context.Person.ToListAsync();
        }

        public async Task SaveChange()
        {
           await _context.SaveChangesAsync();
        }
    }
}
