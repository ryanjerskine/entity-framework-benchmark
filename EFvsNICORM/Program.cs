using BenchmarkDotNet.Running;
using System;

namespace EFvsNICORM
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(EFvsNICORM));

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
