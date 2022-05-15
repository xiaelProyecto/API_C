using API_C.Model;
using System.Threading.Tasks;

namespace API_C.ICollections
{
    public interface ITokenCollection
    {
        Task<Mytoken> GetToken();
    }
}
