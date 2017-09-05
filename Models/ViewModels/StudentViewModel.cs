using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models.ViewModels
{
    public class StudentViewModel
    {

        /// <summary>
        /// The Social Security Number of the student. Example value: 123456-0011
        /// </summary>
        [Required]
        public string SSN { get; set; }

        /// <summary>
        /// The name of the student. Example value: Jónatan
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}