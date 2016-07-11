﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForTinkoff.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public int Jumps { get; set; }
    }
}