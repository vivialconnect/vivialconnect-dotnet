using AutoMapper;

namespace VivialConnect.Mappings
{
    /// <summary>
    /// Configuration class that initializes the profile mappings.
    /// </summary>
    public class ResourceConfiguration
    {
        private static IMapper mapper;

        public static IMapper GetMapper()
        {
            if (mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AccountProfile>();
                    cfg.AddProfile<MessageProfile>();
                    cfg.AddProfile<NumberProfile>();
                    cfg.AddProfile<ConnectorProfile>();
                });
                mapper = config.CreateMapper();
            }

            return mapper;
        }
    }
}
