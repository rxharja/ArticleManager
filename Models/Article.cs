using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        public byte[] Image { get; set; }
    }
}
