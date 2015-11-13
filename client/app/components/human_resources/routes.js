angular.module('dash-humanResources', []).
config(function ($stateProvider) {
  $stateProvider.
  state('humanResources', {
    parent: 'ts',
    url: 'humanResources',
    controller: 'humanResourcesController',
    templateUrl: 'components/human_resources/index.html',
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  });
});
