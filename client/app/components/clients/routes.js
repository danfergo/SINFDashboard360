angular.module('dash-clients', []).
config(function ($stateProvider) {
  $stateProvider.
  state('clients', {
    parent: 'ts',
    url: 'clients',
    controller: 'clientsController',
    templateUrl: 'components/clients/index.html',
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  });
});
