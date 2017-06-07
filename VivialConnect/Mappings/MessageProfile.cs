using AutoMapper;
using VivialConnect.Resources.Message;

namespace VivialConnect.Mappings
{
    /// <summary>
    /// Message profile that estabilishes the message
    /// to message mapping.
    /// </summary>
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, Message>();
        }
    }
}
