using Domain.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IpersonService
    {
        Task AddPerson(Person person);
        Task<List<Person>> GetAllAsync();
    }
}
