using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Role:BaseEntity
    {
        public string RoleNameAr { get; set; }
        public string RoleNameEn { get; set; }
    }
}
