using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClearKilovat.Models.Entity
{
    [Table("parser_analytics")]
    public class ParserAnalytics
    {
        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("suggestion")]
        public string Suggestion { get; set; }

        [Column("confidence")]
        public decimal? Confidence { get; set; }

        [Column("parsed_at")]
        public DateTime ParsedAt { get; set; }

        public Account Account { get; set; }
    }
}
