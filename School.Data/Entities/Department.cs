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
    public  class Department : GenericLocalizer
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentsSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string NameAr { get; set; }  
        [StringLength(100)]
        public string NameEn { get; set; }

    

        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<DepartmentSubject> DepartmentsSubjects { get; set; }


        
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        [InverseProperty("DepartmentManage")]
        public virtual Instructor Manager { get; set; }



    }

}
