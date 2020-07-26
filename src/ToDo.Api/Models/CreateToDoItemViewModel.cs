using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.Models
{
    public class CreateToDoItemViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
