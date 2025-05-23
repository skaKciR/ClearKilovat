using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClearKilovat.Models.Entity
{
    [Table("nn_results")]
    public class NnResult
    {
        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("prediction")]
        public string Prediction { get; set; }

        [Column("confidence")]
        public decimal? Confidence { get; set; }

        [Column("predicted_at")]
        public DateTime PredictedAt { get; set; }

        public Account Account { get; set; }
    }
}
