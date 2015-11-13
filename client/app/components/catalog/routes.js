angular.module('dash-catalog', []).
config(function ($stateProvider) {
  $stateProvider.
  state('catalog', {
    parent: 'ts',
    url: 'catalog',
    controller: 'catalogController',
    templateUrl: 'components/catalog/index.html',
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  });
});
