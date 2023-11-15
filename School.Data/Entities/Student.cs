using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Data.Common;

namespace School.Data.Entities
{
    public class Student :GenericLocalizer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NameAr { get; set; } 
        [StringLength(100)]
        public string NameEn { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
