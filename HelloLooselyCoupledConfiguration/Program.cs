﻿using System;
using System.Configuration;

namespace HelloLooselyCoupledConfiguration
{
    class Program
    {
        static void Main()
        {
            var introducer = new Introducer(new Configuration(key => ConfigurationManager.AppSettings[key]));

            introducer.SayHello();

            Console.ReadLine();
        }
    }
}