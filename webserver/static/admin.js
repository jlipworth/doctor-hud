



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


$(document).ready(function() {
    get_tokens();

    $("#token_button").click(function (e) {
        $.post("/admin/generate_token").done(function (r) {});
        get_tokens();
    });
});
