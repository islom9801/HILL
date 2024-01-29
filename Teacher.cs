using CRUDADO.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDADO.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [SkillsValidate(Allowed = new string[] { "История", "Химия", "Обществознание", "География", "Геометрия", "Алгебра", "Русский язык", "Физика" }, ErrorMessage = "Ввести можно только школьный предмет")]
        public string Skills { get; set; }

        [Range(5, 50)]
        public int TotalStudents { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
