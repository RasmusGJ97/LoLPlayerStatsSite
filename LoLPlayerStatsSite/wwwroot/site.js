function ToggleChampionSelectModal() {
    var myModal = document.querySelector('#ChampionSelectModal');
    var modal = bootstrap.Modal.getOrCreateInstance(myModal);

    modal.toggle();
}