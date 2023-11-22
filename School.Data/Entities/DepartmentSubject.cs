using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class DepartmentSubject
    {
        [Key]
        public int DepartmentId { get; set; }
        [Key]
        public int SubjectId { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("DepartmentsSubjects")]
        public virtual Department Department { get; set; }

        [ForeignKey("SubjectId")]
        [InverseProperty("DepartmentsSubjects")]
        public virtual Subject Subject { get; set; }
    }

}
