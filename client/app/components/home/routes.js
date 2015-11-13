angular.module('dash-home', []).
config(function ($stateProvider) {
  $stateProvider.
  state('index', {
    parent: 'ts',
    url: '',
    controller: 'indexController',
    templateUrl: 'components/home/index.html'
  });
});