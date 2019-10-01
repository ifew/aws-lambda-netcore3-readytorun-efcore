using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace aws_lambda_netcore3_readytorun
{
    public class Function
    {
        private ServiceProvider _service;

        public Function() : this (Bootstrap.CreateInstance()) {}

        public Function(ServiceProvider service)
        {
            _service = service;
        }
        private static async Task Main(string[] args)
		{
            Func<ILambdaContext, List<Member>> func = FunctionHandler;
			using(var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer()))
			{
				using(var lambdaBootstrap = new LambdaBootstrap(handlerWrapper))
				{
					await lambdaBootstrap.RunAsync();
				}
			}
		}
        
        public static List<Member> FunctionHandler(ILambdaContext context)
        {
            Function fn = new Function();
            Services service = fn._service.GetService<Services>();
            List<Member> districts = service.List_member();

            return districts;
        }
    }
}
