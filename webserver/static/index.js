var obj;
var metric_dict = {};
var useRandomData = false;
var last_saved_note;

function gauge(dom, input, name, unit, max, colorStyle) {
    var option = {
        tooltip : {
            formatter: "{a} : {c}"
        },
        series: [
            {
                name: name,
                type: 'gauge',
                max: max,
                width: '100%',
                height: '100%',
                detail: {formatter:'{value}'},
                data: [{value: 0, name: unit}],
                title : {
                    offsetCenter: [0, 60]
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
                        fontSize : 32
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
                data:['Systolic','Diastolic'],
                selectedMode: false
            },
            xAxis: {
                type : 'category',
                boundaryGap : false,
                data : []
            },
            yAxis: {
                name: '(mmHg)',
                type: 'value',
                max: 160,
                min: 40,
                boundaryGap: [0, '100%'],
                splitLine: {
                    show: false
                }
            },
            series: [
            {
                cursor: 'default',
                name: 'Systolic',
                type: 'line',
                label:{ normal:{show:true, fontSize: 18, position: [5, -20]} },
                showSymbol: true,
                animation: false,
                hoverAnimation: true,
                data: [],
            },
            {
                cursor: 'default',
                name: 'Diastolic',
                type: 'line',
                label:{ normal:{show:true, fontSize: 18, position: [5, 10] } },
                showSymbol: true,
                animation: false,
                hoverAnimation: true,
                data: [],
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
                    if(count > 11) {
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
                cursor: 'default',
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
                        show: true,
                        fontSize: 26
                    }
                },
                data: [0]
            },
            {
                cursor: 'default',
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

function onClick (href, toggle_switch, type) {
    var collapse_content_selector = href
    //make the collapse content to be shown or hide
    $(collapse_content_selector).toggle(function(){
        if($(this).css('display')=='none'){
        //change the button label to be 'Show' + type
        toggle_switch.innerHTML = 'Show ' + type;
        }else{
        //change the button label to be 'Hide'
        toggle_switch.innerHTML = 'Hide ' + type;
        }
    });
}

$(document).ready(function() {
    var websocket_proto = window.location.href.indexOf("https://") == 0 ? "wss://" : "ws://";

    var data_socket = new WebSocket(websocket_proto + location.host + "/data");

    data_socket.onmessage = function (e) {
        //$("#testo").html(e.data);
        obj = JSON.parse(e.data);
        for (var metric in obj) {
            metric_dict[metric] = obj[metric];
        }
        // document.getElementById("testo").innerHTML = "";
        // for (var metric in metric_dict) {
        //     document.getElementById("testo").innerHTML += metric + ": " +
        //     metric_dict[metric] + "<br>";
        // }
    };

    var input = '';
    var drake = dragula([document.getElementById('sensor1'), document.getElementById('sensor2')])
    bar(document.getElementById('SpO2'), 'sp_o2');
    gauge(document.getElementById('etCO2'), 'etCO2', 'etCO2', '(mmHg)', 60, [[0.5833, '#9b9b9b'],[0.75, '#ffcc00'],[1, '#9b9b9b']]);
    gauge(document.getElementById('respiration_rate'), 'respiration_rate', 'respiration rate', '(BPM)', 25, [[0.4, '#9b9b9b'],[0.8, '#ffcc00'],[1, '#9b9b9b']]);
    gauge(document.getElementById('heart_rate'), 'heart_rate', 'heart rate', '(BPM)', 150, [[0.33, '#9b9b9b'],[0.66, '#ffcc00'],[1, '#ff4500']]);
    line_chart(document.getElementById('line_chart'), 'systolic', 'diastolic');

    last_saved_note = $("#doctornotes").val();

    setInterval(function() {
        if ($("#doctornotes").val() != last_saved_note) {
            last_saved_note = $("#doctornotes").val();
            $.post("/save_note", {doctornote: last_saved_note});
        }
    }, 2000);
});
