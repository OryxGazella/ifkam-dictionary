using System.Threading.Tasks;
namespace Ifkam.Services.Contracts
{
    public interface ILookupService
    {
        Task<string> Lookup(string word);
    }
}