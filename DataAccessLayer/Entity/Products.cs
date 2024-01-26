using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Products : BaseEntity
    {
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey("Brand")]
        public long BrandId { get; set; }
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        public int Quantity { get; set; }
        public Categories Category { get; set; }
        public Brands Brand { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? ImagePath { get; set; }


    }

}
