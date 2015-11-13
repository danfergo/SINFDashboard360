angular.module('dash-layouts',['dash-sidebar']).
config(function ($stateProvider, $urlRouterProvider) {

  $stateProvider.
  state('ls', {
    url: '/',
    abstract:true,
    templateUrl: 'shared/layouts/sidebar.html',
   }).
  state('lt', {
    url: '/',
    abstract:true,
    templateUrl: 'shared/layouts/toolbar.html',
  }).
  state('ts', {
    url:'/',
    abstract:true,
    templateUrl:'shared/layouts/both.html',
    controller: ['$scope', function($scope){
      $scope.pageTitle = "COMPANY";
    }]
  });

});
