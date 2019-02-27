﻿namespace HelloConfigurationManager
{
    public class Console : IConsole
    {
        public void WriteLine(string s)
        {
            System.Console.WriteLine(s);
        }

        public void Write(string s)
        {
            System.Console.Write(s);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();

        }
    }
}