﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
