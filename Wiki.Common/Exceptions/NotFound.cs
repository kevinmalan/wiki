﻿using System;

namespace Wiki.Common.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound(string message) : base(message)
        {
        }
    }
}