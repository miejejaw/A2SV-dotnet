﻿using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Comment
{
    public class CommentRequestDto
    {
        public int PostId { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
