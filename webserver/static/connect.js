$(document).ready(function(){
    $("#server-dropdown").change( function() {
        console.log($('#server-dropdown option:selected').val());
        if ($('#server-dropdown option:selected').val() != " ") {
            $("#address").attr("value",$('#server-dropdown option:selected').val());
        }
    });
});

function submit_connect() {
    // TODO https
    console.log("submit: "+ $("#address").attr("value"))
    window.location = "http://" + $("#address").attr("value");
};
