
(function () {
    var metric_dict = {}
    var data_socket = new WebSocket("ws://" + location.host + "/data");

    data_socket.onmessage = function (e) {
        //$("#testo").html(e.data);
        var obj = JSON.parse(e.data);
        for (var metric in obj) {
            metric_dict[metric] = obj[metric];
        }
        document.getElementById("testo").innerHTML = "";
        for (var metric in metric_dict) {
            document.getElementById("testo").innerHTML += metric + ": " + 
            metric_dict[metric] + "<br>";
        }
    };

})();
