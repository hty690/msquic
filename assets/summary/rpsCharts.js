var colors = ["#3498db", "#2ecc71", "#f1c40f", "#8e44ad", "#e74c3c", "#34495e", "#e67e22", "#7f8c8d"];

// Useful configuration values
var dataLineWidth = 2
var dataRawPointRadius = 4

// Global option configuration
Chart.defaults.global.responsive = true
Chart.defaults.global.tooltips.position = 'nearest'
Chart.defaults.global.tooltips.mode = 'x'

function createScaleLabel(name) {
    return {
        display: true,
        labelString: name,
        fontSize: 14,
        fontStyle: 'bold'
    };
}

function createRpsOptions(chartToMake) {
    return {
        maintainAspectRatio: false,
        scales: {
            xAxes: [{
                type: 'linear',
                position: 'bottom',
                scaleLabel: createScaleLabel(chartToMake.XName),
            }],
            yAxes: [{
                display: true,
                scaleLabel: createScaleLabel("Requests Per Second"),
                ticks: { min: 0 }
            }]
        }
    }
}

function createRpsDataset(dataset, color) {
    return {
        type: "scatter",
        label: dataset.LegendValue,
        data: dataset.DataPairs,
        showLine: true,
        fill: false,
        tension: 0,
        backgroundColor: color,
        borderColor: color,
        borderWidth: dataLineWidth,
        pointRadius: dataRawPointRadius,
    }
}

function createRpsDatasets(chartData) {
    var arr = []
    var index = 0
    for (var dataset of chartData) {
        arr.push(createRpsDataset(dataset, colors[index]))
        index++;
        if (index >= colors.length) {
            index = 0;
        }
    }
    return {
        datasets: arr
    };
}

window.onload = function() {
    var templateDiv = document.getElementById("Template");

    var chartsDiv = document.getElementById("ChartsDiv");
    chartsDiv.innerHTML = ""

    var chartList = [];

    var index = 0;
    for (var chartToMake of periodicRpsGraphs) {
        var newNode = templateDiv.cloneNode(true);
        newNode.id = newNode.id + index;
        var canvasNode = newNode.querySelector("#canvas");
        canvasNode.id = canvasNode.id + index;

        var headerNode = newNode.querySelector("#HeaderName");
        headerNode.innerText = `RPS per ${chartToMake.LegendName}, ${chartToMake.XName}`
        headerNode.id = headerNode.id + index;

        var summaryTextNode = newNode.querySelector("#SummaryText");
        summaryTextNode.innerText = "This test measures average requests completed per second while simulating HTTP-style traffic between the client and server."
        summaryTextNode.id = summaryTextNode.id + index;

        var createData = [canvasNode, chartToMake];
        chartList.push(createData);

        chartsDiv.appendChild(newNode);
        index++;
    }

    for (var chartData of chartList) {
        new Chart(chartData[0].getContext('2d'), {
            data: createRpsDatasets(chartData[1].Data),
            options: createRpsOptions(chartData[1])
        });
    }
}