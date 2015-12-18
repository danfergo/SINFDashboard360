angular.module('dash-providers', []).
config(function ($stateProvider) {
  $stateProvider.
  state('providers', {
    parent: 'ts',
    url: 'providers',
    controller: 'providersController',
    templateUrl: 'components/providers/providers.html'
  });
});