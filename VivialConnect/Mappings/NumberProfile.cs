using AutoMapper;
using VivialConnect.Resources.Number;

namespace VivialConnect.Mappings
{
    /// <summary>
    /// Number profile that estabilishes the number to
    /// number mapping.
    /// </summary>
    public class NumberProfile : Profile
    {
        public NumberProfile()
        {
            CreateMap<Number, Number>();
        }
    }
}
