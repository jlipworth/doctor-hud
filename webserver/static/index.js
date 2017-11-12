var obj;
var metric_dict = {};
var useRandomData = false;

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

function gauge(dom, input, name, max, colorStyle) {
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
                data: [{value: 0, name: name}],
                title : {
                    offsetCenter: [0, 70]
                },
                pointer : {
                    width : 4
                },
                splitLine: {
                    show: true,
                    length: 10,
                    lineStyle: {
                        color: 'auto'
                    }
                },
                axisLine: {
                    show: true,
                    lineStyle: {
                        color: colorStyle,
                        width: 10
                    }
                },
                detail : {
                     textStyle: {
                        color: 'auto',
                        fontSize : 15
                     }
                }
            }
        ]
    };
    var myChart = echarts.init(dom);
    setInterval(function () {
            var currentValue;
            if (!useRandomData) {
                currentValue = metric_dict[input]
            } else {
                currentValue = (Math.random() * 100).toFixed(2) - 0
            }
            option.series[0].data[0].value = currentValue;
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
                    var currentValue1, currentValue2;
                    if (!useRandomData) {
                        currentValue1 = metric_dict[input1]
                        currentValue2 = metric_dict[input2]
                    } else {
                        currentValue1 = (Math.random() * 100).toFixed(2) - 0
                        currentValue2 = (Math.random() * 100).toFixed(2) - 0
                    }
                    count++;
                    if(count > 10) {
                        option.xAxis.data.shift();
                        option.series[0].data.shift();
                        option.series[1].data.shift();
                    }
                    var d = new Date();
                    var currentTime = d.getHours() + ':'+ d.getMinutes() + ':'+ d.getSeconds();
                    option.xAxis.data.push(currentTime);
                    option.series[0].data.push(currentValue1);
                    option.series[1].data.push(currentValue2);
                    myChart.setOption(option, true);
                },1000);
}

function bar(dom, input) {
    option = {
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        xAxis: {
            axisLine: {show: false},
            axisTick: {show: false},
            splitLine: { show: false },
            axisLabel: { show: false }
        },
        yAxis: {
            data: ['SpO2'],
            axisLine: {show: false},
            axisTick: {show: false},
            axisLabel: {show: true}
          },
        series: [
            {
                name: 'SpO2',
                type: 'bar',
                stack: 'sum',
                itemStyle: {
                    normal: {
                        color: '#2196f3'
                    }
                },
                label: {
                    normal: {
                        formatter:'{c}%',
                        show: true
                    }
                },
                data: [0]
            },
            {
                type: 'bar',
                stack: 'sum',
                itemStyle: {
                    normal: {
                        color: '#bcbcbc'
                    }
                },
                data: [100]
            }
        ]
    };
    var myChart = echarts.init(dom);
        setInterval(function () {
                var currentValue;
                if (!useRandomData) {
                    currentValue = metric_dict[input]
                } else {
                    currentValue = (Math.random() * 100).toFixed(1) - 0
                }
                option.series[0].data[0] = currentValue;
                option.series[1].data[0] = 100 - currentValue;
                myChart.setOption(option, true);
            },1000);
}

$(document).ready(function() {
    var input = '';
    bar(document.getElementById('SpO2'), 'sp_o2');
    gauge(document.getElementById('etCO2'), 'etCO2', 'etCO2', 60, [[0.5833, '#9b9b9b'],[0.75, '#ffcc00'],[1, '#9b9b9b']]);
    gauge(document.getElementById('respiration_rate'), 'respiration_rate', 'respiration rate', 25, [[0.4, '#9b9b9b'],[0.8, '#ffcc00'],[1, '#9b9b9b']]);
    gauge(document.getElementById('heart_rate'), 'heart_rate', 'heart rate', 150, [[0.33, '#9b9b9b'],[0.66, '#ffcc00'],[1, '#ff4500']]);
    line_chart(document.getElementById('line_chart'), 'systolic', 'diastolic');
});
