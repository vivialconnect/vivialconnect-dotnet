using AutoMapper;
using VivialConnect.Resources.Connector;

namespace VivialConnect.Mappings
{
    /// <summary>
    /// Connector profile that estabilishes the connector
    /// to connector mapping.
    /// </summary>
    public class ConnectorProfile : Profile
    {
        public ConnectorProfile()
        {
            CreateMap<Connector, Connector>();
        }
    }
}
