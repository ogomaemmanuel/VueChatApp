using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VueChatApp.Features.QrCode.Entities
{
    [Table("QrCode")]
    public class QrCode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public String Token { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }=DateTime.UtcNow;
        
    }
}