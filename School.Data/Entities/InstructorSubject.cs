using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class InstructorSubject
    {
        [Key]
        public int InstructorId { get; set; }

        [Key]
        public int SubjectId { get; set; }

        [ForeignKey("InstructorId")]
        [InverseProperty("InstructorSubjects")]
        public Instructor Instructor { get; set; }


        [ForeignKey("SubjectId")]
        [InverseProperty("InstructorSubjects")]
        public Subject Subject { get; set; }

    }
}
