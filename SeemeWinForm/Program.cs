using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SeemeWinForm;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // ?????? ASP.NET Core ???-?????????? ? ????????? ??????
        var webAppTask = Task.Run(() =>
        {
            CreateHostBuilder(new string[] { }).Build().Run();
        });

        // ???????? ??????? ???-?????????? (????? ????? ???????? ????????, ???? ?????)
        // ????????, Thread.Sleep(5000); // ????????? 5 ??????

        // ?????? Windows Forms ??????????
        Application.Run(new Form1()); // ???????? ?? ???? ??????? ????? Windows Forms

        // ???????????: ????????? ?????????? ???-??????????
        webAppTask.Wait();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>(); // ???????? ?? ??? ????? Startup
    });
}