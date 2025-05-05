using Accessory.Builder.Persistence.DatabaseMigration.Common;
using Accessory.Builder.Persistence.DatabaseMigration.DbUp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Template.DatabaseMigration;

public class Program
{
    static int Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbUp(c => c.AddConsole())
            .Build();

        var dbUpService = serviceProvider.GetService<IMigrationService>();

        if (!dbUpService!.ExecuteMigrationScripts())
            return -1;

        return 0;
    }
}