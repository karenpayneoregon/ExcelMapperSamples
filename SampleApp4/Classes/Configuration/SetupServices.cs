using Microsoft.Extensions.Options;
using SampleApp4.Models.Configuration;

namespace SampleApp4.Classes.Configuration;
internal class SetupServices
{
    private readonly EntityConfiguration _settings;
    private readonly ConnectionStrings _options;

    public SetupServices(IOptions<ConnectionStrings> options, IOptions<EntityConfiguration> settings)
    {
        _options = options.Value;
        _settings = settings.Value;
    }
    /// <summary>
    /// Read connection strings from appsettings
    /// </summary>
    public void GetConnectionStrings()
    {
        DataConnections.Instance.Connection = _options.Connection;
    }
    public void GetEntitySettings()
    {
        EntitySettings.Instance.CreateNew = _settings.CreateNew;
    }
}
