angular.module('dash-accounting', []).
config(function ($stateProvider) {
  $stateProvider.
  state('accounting', {
    parent: 'ts',
    url: 'accounting',
    controller: 'accountingController',
    templateUrl: 'components/accounting/index.html',
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  });
});
