$(function () {
   
    $("#tblFixturex").on("click", ".btnFixtureDelete", function () {
        var btn = $(this);
        bootbox.confirm("Fixturu silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Fixture/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {

    $("#tblLeagues").on("click", ".btnLeaguesDelete", function () {
        var btn = $(this);
        bootbox.confirm("Ligi silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Leagues/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});


$(function () {

    $("#tblPlayer").on("click", ".btnPlayerDelete", function () {
        var btn = $(this);
        bootbox.confirm("Oyuncuyu  silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Player/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});
$(function () {

    $("#tblTeam").on("click", ".btnTeamDelete", function () {
        var btn = $(this);
        bootbox.confirm("Oyuncuyu  silmek istediğinize eminmisiniz ? ", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({

                    type: "GET",
                    url: "/Team/Delete/" + id,
                    success: function () {

                        btn.parent().parent().remove();
                    }


                });
            }

        });
    });

});


function CheckDateTypeIsValid(dateElement) {

    var value = $(dateElement).val()
    if (value == '') {
        $(dateElement).valid(false);
    }
    else {
        $(dateElement).valid();
    }
}