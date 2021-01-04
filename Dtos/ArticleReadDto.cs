﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Dtos
{
    public class ArticleReadDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
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
