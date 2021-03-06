var DemoApp = angular.module('DemoApp', ['dx']);

DemoApp.controller('DemoController', function DemoController($scope) {

    var topCarServicesJson = angular.fromJson($('#topCarServices').data("json"));
    var topServicesJson = angular.fromJson($('#topProiftServices').data("json"));
    var mostProfitableEmployee = angular.fromJson($('#mostProfitableEmployee').data("json"));
    var topEmployeeCount = angular.fromJson($('#topEmployeeCount').data("json"));

    $scope.topEmployeeCountChart = {
        palette: "bright",
        rotated: true,
        dataSource: topEmployeeCount,
        title: "Rank Employee by count of orders",
        legend: {
            orientation: "horizontal",
            itemTextPosition: "right",
            horizontalAlignment: "right",
            verticalAlignment: "bottom",
            columnCount: 4
        },
        "export": {
            enabled: false
        },
        series: {
            label: {
                visible: true,
                backgroundColor: "#c18e92"
            },
            color: "#79cac4",
            type: "bar",
            argumentField: "Lfm",
            valueField: "Count"
        }
    };

    $scope.mostProfitableEmployeeChart = {
        palette: "bright",
        dataSource: mostProfitableEmployee,
        title: "Rank Employee by profit",
        rotated: true,
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
            type: "bar",
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
                    return arg.valueText + '($)';
                }
            }
        }]
    };
    $scope.chartOptionsClients = {
        palette: "bright",
        dataSource: topServicesJson,
        title: "Rank Services by profit",
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

    $scope.chartOptions = {
        palette: "bright",
        dataSource: topCarServicesJson,
        title: "Rank Car Services by profit",
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