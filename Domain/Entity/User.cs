using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class User : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
