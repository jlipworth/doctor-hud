

var t = document.getElementById('address');
var sd = document.getElementById('server-dropdown');

sd.value = '';
t.value = '';

sd.onchange = function() {
    if (sd.value !== '') {
        t.value = sd.value;
    }
};



function submit_connect() {
    // TODO https
    window.location = "http://" + t.value;
};
