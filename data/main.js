
var t, sd;

function submit_connect() {
    window.location = t.value;
};

$(document).ready(function() {
    t = document.getElementById('address');
    sd = document.getElementById('server-dropdown');

    sd.value = '';
    t.value = '';

    sd.onchange = function() {
        if (sd.value !== '') {
            t.value = sd.value;
        }
    };


});
