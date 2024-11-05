using System.Collections.Generic;
using Notebook.Domain.Interfaces;

namespace Notebook.Domain.Entity
{
    public class Role : IEntityId<long>
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}