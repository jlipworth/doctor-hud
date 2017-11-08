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

function gauge(dom, input, name, max) {
    var option = {
        tooltip : {
            formatter: "{a} <br/>{b} : {c}%"
        },
        series: [
            {
                name: name,
                type: 'gauge',
                max: max,
                width: '100%',
                height: '100%',
                detail: {formatter:'{value}'},
                data: [{value: 0, name: name}]
            }
        ]
    };
    var myChart = echarts.init(dom);
    //(Math.random() * 100).toFixed(2) - 0
    //metric_dict[input]
    setInterval(function () {
            option.series[0].data[0].value = metric_dict[input];
            myChart.setOption(option, true);
        },1000);
}

function line_chart(dom, input1, input2) {
    var option = {
            tooltip: {
                trigger: 'axis',/*
                formatter: function (params) {
                    params = params[0];
                    var date = new Date(params.name);
                    return date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear() + ' : ' + params.value[1];
                },*/
                axisPointer: {
                    animation: false
                }
            },
            legend: {
                data:['Systolic','Diastolic']
            },
            xAxis: {
                type : 'category',
                boundaryGap : false,
                data : [0]
            },
            yAxis: {
                type: 'value',
                boundaryGap: [0, '100%'],
                splitLine: {
                    show: false
                }
            },
            series: [
            {
                name: 'Systolic',
                type: 'line',
                label:{ normal:{show:true} },
                showSymbol: true,
                hoverAnimation: false,
                data: [0]
            },
            {
                name: 'Diastolic',
                type: 'line',
                label:{ normal:{show:true} },
                showSymbol: true,
                hoverAnimation: false,
                data: [0]
            }
            ]
        };
        var myChart = echarts.init(dom);
        var count = 0
        setInterval(function () {
                    count++;
                    if(count > 10) {
                        option.xAxis.data.shift();
                        option.series[0].data.shift();
                        option.series[1].data.shift();
                    }
                    var d = new Date();
                    var currentTime = d.getHours() + ':'+ d.getMinutes() + ':'+ d.getSeconds();
                    option.xAxis.data.push(currentTime);
                    //(Math.random() * 100).toFixed(2) - 0
                    //metric_dict[input]
                    option.series[0].data.push(metric_dict[input1]);
                    option.series[1].data.push(metric_dict[input2]);
                    myChart.setOption(option, true);
                },1000);
}

$(document).ready(function() {
    var input = ''
    gauge(document.getElementById('etCO2'), 'etCO2', 'etCO2', 40)
    gauge(document.getElementById('respiration_rate'), 'respiration_rate', 'respiration rate', 25)
    gauge(document.getElementById('heart_rate'), 'heart_rate', 'heart rate', 150)
    line_chart(document.getElementById('line_chart'), 'systolic', 'diastolic')
});


