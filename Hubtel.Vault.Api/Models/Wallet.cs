using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hubtel.Vault.Api.Models
{
    [Table("wallet")]
    public class Wallet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Column("account_scheme")]
        public string AccountScheme { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("owner")]
        public string Owner { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class WalletRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string AccountNumber { get; set; }
        public string AccountScheme { get; set; }

        [JsonIgnore]
        public string? Owner { get; set; }
    }
}
