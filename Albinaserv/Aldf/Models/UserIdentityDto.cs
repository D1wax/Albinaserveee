﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Albina.Core.Models
{
    class UserIdentityDto
    {
        public int Id { get; set; }
        public int NumberPrefix { get; set; }
        public int Number { get; set; }
        public int Password { get; set; }
        public int ConfirmPassword { get; set; }
    }
}
