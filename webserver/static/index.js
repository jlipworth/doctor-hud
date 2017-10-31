

(function () {

    var data_socket = new WebSocket("ws://" + location.host + "/data");

    data_socket.onmessage = function (e) {
        $("#testo").html(e.data);
    };

})();
