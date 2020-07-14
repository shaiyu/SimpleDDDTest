using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entity
{
    public class UserRole
    {
        public Guid UserId { get; set; }

        public long RoleId { get; set; }
    }
}
