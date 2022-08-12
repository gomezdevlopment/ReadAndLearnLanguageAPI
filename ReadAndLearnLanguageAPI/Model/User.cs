using System.ComponentModel.DataAnnotations;

namespace ReadAndLearnLanguageAPI.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }
    }
}