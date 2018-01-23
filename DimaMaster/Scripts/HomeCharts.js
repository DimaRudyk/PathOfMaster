var DemoApp = angular.module('DemoApp', ['dx']);

DemoApp.controller('DemoController', function DemoController($scope) {

    var topCarServicesJson = angular.fromJson($('#topCarServices').data("json"));

    $scope.chartOptions = {
        palette: "bright",
        dataSource: topCarServicesJson,
        title: "Rank by profit",
        legend: {
            orientation: "horizontal",
            itemTextPosition: "right",
            horizontalAlignment: "right",
            verticalAlignment: "bottom",
            columnCount: 4
        },
        "export": {
            enabled: true
        },
        series: [{
            argumentField: "Lfm",
            valueField: "TotalSum",
            label: {
                visible: true,
                font: {
                    size: 16
                },
                connector: {
                    visible: true,
                    width: 0.5
                },
                position: "columns",
                customizeText: function (arg) {
                    return arg.valueText + " (" + arg.percentText + ")";
                }
            }
        }]
    };
});