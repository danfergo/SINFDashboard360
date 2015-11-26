angular.module('dash-layouts',['dash-sidebar']).
config(function ($stateProvider, $urlRouterProvider) {

  $stateProvider.
  state('ls', {
    url: '/',
    abstract:true,
    templateUrl: 'shared/layouts/sidebar.html',
    resolve:{
      currentSession: ['Session', function(Session){
        return Session.get().$promise;
      }]
    }
   }).
  state('lt', {
    url: '/',
    abstract:true,
    templateUrl: 'shared/layouts/toolbar.html',
    resolve:{
      currentSession: ['Session', function(Session){
        return Session.get().$promise;
      }]
    }
  }).
  state('ts', {
    url:'/',
    abstract:true,
    templateUrl:'shared/layouts/both.html',
    controller: ['$scope','currentSession', function($scope,currentSession){
      $scope.pageTitle = "COMPANY";
      $scope.currentSession = currentSession;
    }],
    resolve:{
      'currentSession': ['Session', function(Session){
        return Session.get().$promise;
      }]
    }
  });

});
