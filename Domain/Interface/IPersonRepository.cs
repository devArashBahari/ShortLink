using Domain.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IPersonRepository :IAsyncDisposable
    {
        Task AddPerson(Person person);
        Task<List<Person>> GetAllAsync();
        Task SaveChange();
    }
}
