var obj;
var metric_dict = {};

(function () {
    var data_socket = new WebSocket("ws://" + location.host + "/data");

    data_socket.onmessage = function (e) {
        //$("#testo").html(e.data);
        obj = JSON.parse(e.data);
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

function gauge(dom, input, name) {
    var option = {
        tooltip : {
            formatter: "{a} <br/>{b} : {c}%"
        },
        series: [
            {
                name: name,
                type: 'gauge',
                detail: {formatter:'{value}%'},
                data: [{value: 50, name: 'heart rate'}]
            }
        ]
    };
    var myChart = echarts.init(dom);
    //(Math.random() * 100).toFixed(2) - 0
    setInterval(function () {
            option.series[0].data[0].value = metric_dict[heart_rate];
            myChart.setOption(option, true);
        },2000);
}

$(document).ready(function() {
    var input = ''
    gauge(document.getElementById('heartRate'), input, 'heart_rate')
});


