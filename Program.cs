
using GestionEtudiants;

public class Program {
    public static async Task Main(string[] args)
    {
        var host = hostBuilderCreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    public static IHostBuilder hostBuilderCreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStaticWebAssets();
            webBuilder.UseStartup<Startup>();
        });
}