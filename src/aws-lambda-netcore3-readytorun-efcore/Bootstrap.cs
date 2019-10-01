using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace aws_lambda_netcore3_readytorun
{
    public class Bootstrap
    {
        public static ServiceProvider CreateInstance()
        {
            return new ServiceCollection()
            .AddDbContext<MemberContext>(options => options.UseMySQL(LambdaConfiguration.Instance["DB_CONNECTION"]))
            .AddSingleton<Services, Services>()
            .BuildServiceProvider();
        }
    }
}