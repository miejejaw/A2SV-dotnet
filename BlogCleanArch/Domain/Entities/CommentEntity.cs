﻿
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommentEntity : BaseDomainEntity
    {
        public int PostId { get; set; }
        public string Text { get; set; } = string.Empty;
        public PostEntity? Post { get; set; }
    }
}
