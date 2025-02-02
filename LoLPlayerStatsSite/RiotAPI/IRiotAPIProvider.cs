using LoLPlayerStatsSite.RiotAPI.DTOs;

namespace LoLPlayerStatsSite.RiotAPI
{
    public interface IRiotAPIProvider
    {
        Task<RiotGetUserResponseDto> GetSingleUserByGameNameAndTag(string gameName, string tag);
    }
}
