using Mainapp.MenuDialogs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ContactsDomain.Interfaces;
using ContactsDomain.Services;

var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => 
{
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<IContactsList, ContactsList>();
    services.AddTransient<MainDialog>();
}).Build();

var mainDialog = host.Services.GetRequiredService<MainDialog>();


while (true)
{
    mainDialog.MainMenu();
  
}
