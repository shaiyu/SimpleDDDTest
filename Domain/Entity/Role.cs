using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class Role : IAggregateRoot<long>
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
