

// TODO make times in local time, not UTC

function get_tokens()
{
    $.getJSON("/admin/get_tokens", function (l) {
        var s = '<tr><th class="data_td">Token</th><th class="data_td">Expires on</th><th class="data_td">Created on</th></tr>';

        for (var i in l) {
            s += '<tr><td class="data_td">' + l[i][0] + '</td><td class="data_td">' + l[i][1] + '</td><td class="data_td">' + l[i][2] + '</td></tr>'
        }

        $("#token_table").html(s);
    });
}

function get_accesses()
{
    $.getJSON("/admin/get_accesses", function (l) {
        var s = '<tr><th class="data_td">Username</th><th class="data_td">Access begins</th><th class="data_td">Access ends</th></tr>';

        for (var i in l) {
            s += '<tr><td class="data_td">' + l[i][0] + '</td><td class="data_td">' + l[i][1] + '</td><td class="data_td">' + l[i][2] + '</td></tr>'
        }

        $("#access_table").html(s);
    });
}


$(document).ready(function() {
    get_tokens();
    get_accesses();

    $('#access_begins').val(new Date().toJSON().slice(0, 16));
    $('#access_ends').val(new Date().toJSON().slice(0, 16));

    $("#token_button").click(function (e) {
        $.post("/admin/generate_token").done(function (r) {get_tokens();});
    });

    $("#access_form").submit(function (e) {
        e.preventDefault();

        $.post("/admin/give_access", {
            "username": $("#access_username option:selected").text(),
            "access_begins": $("#access_begins").val(),
            "access_ends": $("#access_ends").val()
        }).done(function (r) {get_accesses();});
    });
});
