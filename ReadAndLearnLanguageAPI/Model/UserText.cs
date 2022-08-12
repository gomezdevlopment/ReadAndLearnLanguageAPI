using System.ComponentModel.DataAnnotations;

namespace ReadAndLearnLanguageAPI.Model
{
    public class UserText
    {
        [Key]
        public int TextId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}