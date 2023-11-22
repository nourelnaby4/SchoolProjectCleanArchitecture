using School.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class Subject : GenericLocalizer
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmentsSubjects = new HashSet<DepartmentSubject>();
            InstructorSubjects = new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string NameAr { get; set; }
        [StringLength(100)]
        public string NameEn { get; set; }
        public DateTime Period { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<DepartmentSubject> DepartmentsSubjects { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }
    }

}
