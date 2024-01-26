using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class UsersRole : BaseEntity
    {
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        [ForeignKey("Users")]
        public long UserId { get; set; }
        public Users User { get; set; }
        public Role Role { get; set; }
    }
}
