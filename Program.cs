using System;
using Microsoft.Extensions.Configuration;

namespace Casper.CloudDatabase
{
    public static class Program
    {
        public static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory);
        }
    }
}
