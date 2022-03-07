using System.Threading.Tasks;
using Microsoft.Graph;

namespace Mmu.WpfGraphApiTool.Infrastructure.GraphApi.Services
{
    public interface IGraphServiceClientFactory
    {
        Task<GraphServiceClient> CreateAsync();
    }
}