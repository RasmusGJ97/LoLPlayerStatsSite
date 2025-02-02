using LoLPlayerStatsSite.RiotAPI;
using LoLPlayerStatsSite.RiotAPI.DTOs;
using LoLPlayerStatsSite.Services;
using Microsoft.AspNetCore.Components;

namespace LoLPlayerStatsSite.Components.Pages.PlayerStatsPage
{
    public partial class PlayerStatsPage
    {
        private string _searchGameName { get; set; }
        private string _searchGameTag { get; set; }  
        
        private RiotGetUserResponseDto _riotGetUserResponseDto { get; set; }

        [Inject] private IPlayerStatsService _playerStatsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _riotGetUserResponseDto = new RiotGetUserResponseDto();
        }

        private async void ResetForm()
        {
            _searchGameName = "";
            _searchGameTag = "";

            await InvokeAsync(StateHasChanged);
        }

        private async Task GetSingleUserFromNameAndTag()
        {
            var result = await _playerStatsService.GetSingleUserIdWithGameNameAndTag(_searchGameName, _searchGameTag);

            if (result != null)
            {
                _riotGetUserResponseDto = result;
            }

            ResetForm();
        }
    }
}
