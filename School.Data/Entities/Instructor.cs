using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            Instructors=new HashSet<Instructor>();
            InstructorSubjects=new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public int? SupervisorId { get; set; }
        [ForeignKey("SupervisorId")]
        [InverseProperty("Instructors")]
        public virtual Instructor Suprvisor { get; set; }

        [InverseProperty("Suprvisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        
        
        [InverseProperty("Instructor")] // from table InstructorSubject
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }


  
        [InverseProperty("Manager")]
        public virtual Department DepartmentManage { get; set; }
    }
}
