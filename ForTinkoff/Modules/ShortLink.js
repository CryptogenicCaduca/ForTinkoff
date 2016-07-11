var ShortLinkApp = angular.module('ShortLinkApp', []);
ShortLinkApp.controller('ShortLinkController', function ($scope, ShortLinkService) {

    getLinks();
    function getLinks() {
        ShortLinkService.getLinks()
            .success(function (links) {
                $scope.links = links;
                console.log($scope.links);
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }
});

ShortLinkApp.factory('ShortLinkService', ['$http', function ($http) {

    var ShortLinkService = {};
    ShortLinkService.getLinks = function () {
        return $http.get('/Api/Link');
    };
    return ShortLinkService;

}]);
