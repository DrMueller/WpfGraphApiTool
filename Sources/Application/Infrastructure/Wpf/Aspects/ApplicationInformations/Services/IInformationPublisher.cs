using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Services
{
    public interface IInformationPublisher
    {
        void Publish(InformationEntry informationEntry);
    }
}