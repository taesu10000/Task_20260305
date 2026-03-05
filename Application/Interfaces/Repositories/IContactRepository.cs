using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> CreateAsync(Contact contact, CancellationToken ct = default);
        Task<List<Contact>> GetAsnyc(int page, int pageSize, CancellationToken ct = default);
        Task<Contact?> GetAsnyc(string name, CancellationToken ct = default);
    }
}
