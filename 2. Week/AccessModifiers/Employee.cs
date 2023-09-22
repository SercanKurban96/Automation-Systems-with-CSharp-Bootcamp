﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Employee : Person
    {
        public void AccessProtectedMethod()
        {
            ProtectedMethod();
        }
        public void AccessPrivateProtectedMethod()
        {
            PrivateProtectedMethod();
        }
        public void AccessInternalMethod()
        {
            InternalMethod();
        }
    }
}
