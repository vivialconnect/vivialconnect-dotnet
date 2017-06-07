using AutoMapper;

namespace VivialConnect.Mappings
{
    /// <summary>
    /// Configuration class that initializes the profile mappings.
    /// </summary>
    public class ResourceConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<MessageProfile>();
                cfg.AddProfile<NumberProfile>();
                cfg.AddProfile<ConnectorProfile>();
            });
        }
    }
}
