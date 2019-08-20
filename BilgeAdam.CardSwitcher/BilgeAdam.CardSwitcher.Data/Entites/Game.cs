using BilgeAdam.CardSwitcher.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgeAdam.CardSwitcher.Data.Entites
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public Winner Winner { get; set; }
        public int GamePoint { get; set; }

        [ForeignKey(nameof(Player1Id))]
        public virtual User Player1 { get; set; }
        [ForeignKey(nameof(Player2Id))]
        public virtual User Player2 { get; set; }
    }
}
