(function () {
    var app = angular.module('statistics', ['chart.js']);
    app.controller('revenueStatisticController', function ($scope, $filter, $http) {
        $scope.tabledata = [];
        $scope.labels = [];
        $scope.series = ['Doanh số'];

        $scope.chartdata = [];
        function getStatistic() {
            var config = {
                param: {
                    //mm/dd/yyyy
                    fromDate: '05/05/2020',
                    toDate: '05/05/2021'
                }
            }
            $http.get('/statistic/revenue?fromDate=' + config.param.fromDate + "&toDate=" + config.param.toDate).then(function (response) {
                $scope.tabledata = response.data;
                var labels = [];
                var chartData = [];
                var revenues = [];
                $.each(response.data, function (i, item) {
                    labels.push($filter('date')(item.date, 'dd/MM/yyyy'));
                    revenues.push(item.revenues);
                });
                chartData.push(revenues);

                $scope.chartdata = chartData;
                $scope.labels = labels;
            }, function (response) {
                //notificationService.displayError('Không thể tải dữ liệu');
            });
        }
        getStatistic();
    });
})();