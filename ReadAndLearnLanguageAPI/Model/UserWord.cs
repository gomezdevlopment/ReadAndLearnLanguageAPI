using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadAndLearnLanguageAPI.Model
{
    public class UserWord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WordId { get; set; }

        public string Word { get; set; }
        public string Language { get; set; }
        public string Definition { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
    }
}