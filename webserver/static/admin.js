

// TODO make times in local time, not UTC

function get_tokens()
{
    $.getJSON("/admin/get_tokens", function (l) {
        var s = '<tr><th>Token</th><th>Expires on</th><th>Created on</th></tr>';

        for (var i in l) {
            s += '<tr><td>' + l[i][0] + '</td><td>' + l[i][1] + '</td><td>' + l[i][2] + '</td></tr>'
        }

        $("#token_table").html(s);
    });
}

function get_accesses()
{
    $.getJSON("/admin/get_accesses", function (l) {
        var s = '<tr><th>Username</th><th>Access begins</th><th>Access ends</th></tr>';

        for (var i in l) {
            s += '<tr><td>' + l[i][0] + '</td><td>' + l[i][1] + '</td><td>' + l[i][2] + '</td></tr>'
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
        $.post("/admin/generate_token").done(function (r) {});
        get_tokens();
    });

    $("#access_form").submit(function (e) {
        e.preventDefault();

        $.post("/admin/give_access", {
            "username": $("#access_username option:selected").text(),
            "access_begins": $("#access_begins").val(),
            "access_ends": $("#access_ends").val()
        }).done(function (r) {});

        get_accesses();
    });
});
