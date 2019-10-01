using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace aws_lambda_netcore3_readytorun
{
    public static class LambdaConfiguration
    {
        private static IConfigurationRoot instance = null;
        public static IConfigurationRoot Instance
        {
            get 
            {
                return instance ?? (instance = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddEnvironmentVariables()
                    .Build());
            }
        }
    }
}