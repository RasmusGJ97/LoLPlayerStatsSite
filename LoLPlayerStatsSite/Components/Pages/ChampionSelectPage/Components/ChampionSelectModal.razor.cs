using LoLPlayerStatsSite.Components.Pages.ChampionSelectPage.Model;
using LoLPlayerStatsSite.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LoLPlayerStatsSite.Components.Pages.ChampionSelectPage.Components
{
    public partial class ChampionSelectModal
    {
        [Inject] IChampionRatingService ChampionRatingService { get; set; }
        [Inject] private IJSRuntime _js { get; set; } = default!;

        [Parameter] public EventCallback OnChampionRatingChanged { get; set; }
        [Parameter] public EventCallback OnChampionRatingCreated { get; set; }
        [Parameter] public EventCallback OnResetForm { get; set; }
        [Parameter] public int SelectedChampionRating { get; set; }

        private bool IsEditing => SelectedChampionRating > 0;
        private ChampionSelectFormModel _championSelectFormModel;


        protected override async Task OnParametersSetAsync()
        {
            if (IsEditing)
            {
                var championRatingToChange = await ChampionRatingService.GetSingleChampionRatingAsync(SelectedChampionRating);

                if (championRatingToChange != null)
                {
                    _championSelectFormModel = ChampionSelectFormModel.Create(championRatingToChange);
                }
                await InvokeAsync(StateHasChanged);
            }
            else
            {
                _championSelectFormModel = new ChampionSelectFormModel();
            }
        }

        async Task ResetForm()
        {
            StateHasChanged();
            await OnResetForm.InvokeAsync();
        }

        void ToggleToLearn()
        {
            _championSelectFormModel.ToLearn = !_championSelectFormModel.ToLearn;
        }

        private async Task CreateOrUpdateChampionRating()
        {
            if (IsEditing)
            {
                var existingRating = await ChampionRatingService.GetSingleChampionRatingAsync(_championSelectFormModel.Id);
                await ChampionRatingService.UpdateChampionRating(_championSelectFormModel, existingRating);
                await ChampionRatingService.SaveASync();
                await OnChampionRatingChanged.InvokeAsync();
            }
            else
            {
                await ChampionRatingService.CreateChampionRating(_championSelectFormModel);
                await ChampionRatingService.SaveASync();
                await OnChampionRatingCreated.InvokeAsync();
            }



            //await InvokeAsync(StateHasChanged);
            await _js.InvokeVoidAsync("ToggleChampionSelectModal");
            await ResetForm();
        }
    }
}
