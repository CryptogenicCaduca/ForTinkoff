var ShortenLinkApp = angular.module('ShortenLinkApp', []);
ShortenLinkApp.controller('eventHandlerController', function($scope, PostLinkService) {
    $scope.longLink = 'https://msdn.microsoft.com/ru-ru/library/aa288467(v=vs.71).aspx';
    function postLink() {
        PostLinkService.postLink($scope.longLink)
            .success(function(link) {
                $scope.shortLink = link;
                console.log($scope.link);
                alert('Here is your short link, ' + $scope.shortLink);
            })
            .error(function(error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
                alert('Error, ' + $scope.status);
            });
    }

    $scope.shortenLink = function() {
        postLink();
    }
});


ShortenLinkApp.factory('PostLinkService', [
    '$http', function($http) {

        var PostLinkService = {};
        PostLinkService.postLink = function($longLink) {
            return $http.post('/Api/Link', '"' + $longLink + '"');
        };
        return PostLinkService;

    }
]);