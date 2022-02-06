using Application.Interfaces;
using Domain.Interface;
using Domain.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : IpersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task AddPerson(Person person)
        {
            await _personRepository.AddPerson(person);
            await _personRepository.SaveChange();
        }

        public async Task<List<Person>> GetAllAsync()
        {
           return await _personRepository.GetAllAsync();
        }
    }
}
