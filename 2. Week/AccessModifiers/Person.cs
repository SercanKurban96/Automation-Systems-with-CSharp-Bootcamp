﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Person
    {
        public string Name { get; set; }
        private int age;

        internal void InternalMethod()
        {
            Console.WriteLine("Bu metot sadece aynı derleme içerisinden erişilebilir.");
        }
        protected void ProtectedMethod()
        {
            Console.WriteLine("Bu metot sadece bu sınıfta ve alt sınıflarda erişilebilir.");
        }
        private protected void PrivateProtectedMethod()
        {
            Console.WriteLine("Bu metot sadece aynı derleme içindeki alt sınıflara erişilebilir.");
        }
    }
}
