using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.HttpServices
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto platform);
    }
}