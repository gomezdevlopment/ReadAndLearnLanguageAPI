using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadAndLearnLanguageAPI.Model
{
    public class UserText
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TextId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}