using AutoMapper;
using VivialConnect.Resources.Account;

namespace VivialConnect.Mappings
{
    /// <summary>
    /// Account profile that estabilishes the account to
    /// account mapping.
    /// </summary>
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, Account>();
        }
    }
}
