function CheckDateTypeIsValid(dateElement) {

    var value = $(dateElement).val()
    if (value == '') {
        $(dateElement).valid(false);
    }
    else {
        $(dateElement).valid();
    }
}