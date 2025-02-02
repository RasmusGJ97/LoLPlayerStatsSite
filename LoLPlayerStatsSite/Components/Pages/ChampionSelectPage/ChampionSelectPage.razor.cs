
using LoLPlayerStatsSite.Db.Models;
using LoLPlayerStatsSite.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LoLPlayerStatsSite.Components.Pages.ChampionSelectPage
{
    public partial class ChampionSelectPage
    {
        private List<ChampionRating> _ratingList = new List<ChampionRating>();
        private List<ChampionRating> _filteredChampionRatings = new List<ChampionRating>();

        private int _selectedChampionRating { get; set; }

        [Inject] private IJSRuntime _js { get; set; }
        [Inject] private IChampionRatingService _championRatingService {  get; set; }


        protected override async Task OnInitializedAsync()
        {
           await SetChampionRatings();
        }

        async Task SetChampionRatings()
        {
            _ratingList = await _championRatingService.GetAllChampionRatingsAsync();
            _filteredChampionRatings = _ratingList;
        }

        void SetSelectedChampionRating(int championRatingId)
        {
            _selectedChampionRating = championRatingId;
        }

        async void SelectCROpenModal(int championRatingId)
        {
            SetSelectedChampionRating(championRatingId);
            await _js.InvokeVoidAsync("ToggleChampionSelectModal");

        }

        async Task OnChampionRatingCreateSuccess()
        {
            await SetChampionRatings();
        }        
        async Task OnChampionRatingChangeSuccess()
        {
            ResetForm();
        }

        async void ResetForm()
        {
            _selectedChampionRating = 0;

            await SetChampionRatings();
            await InvokeAsync(StateHasChanged);
        }

        private void ApplyFilter(string lane)
        {
            if (lane == "All")
            {
                _filteredChampionRatings = _ratingList;
            }
            else
            {
                _filteredChampionRatings = _ratingList.Where(x => x.Lane == lane).ToList();
            }
        }

        private async void DeleteChampionRating(ChampionRating championRating)
        {
            var result = await _championRatingService.DeleteChampionRating(championRating);
            if (result)
            {
                await _championRatingService.SaveASync();
            }

            ResetForm();
        }

    }
}
