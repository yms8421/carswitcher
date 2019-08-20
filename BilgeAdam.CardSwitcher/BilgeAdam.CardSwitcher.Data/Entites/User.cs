using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgeAdam.CardSwitcher.Data.Entites
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(64)]
        public string Password { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        public int Point { get; set; }
        public int DrawCount { get; set; }
        public int WinCount { get; set; }
        public int LooseCount { get; set; }
    }
}
