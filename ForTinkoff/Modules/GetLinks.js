var GetLinksApp = angular.module('GetLinksApp', []);
GetLinksApp.controller('GetLinksController', function ($scope, GetLinksService) {
    function getLinks() {
        GetLinksService.getLinks()
            .success(function (links) {
                $scope.links = links;
                console.log($scope.links);
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }

    getLinks();
});

GetLinksApp.factory('GetLinksService', ['$http', function ($http) {

    var GetLinksService = {};
    GetLinksService.getLinks = function () {
        return $http.get('/Api/Link');
    };
    return GetLinksService;

}]);
