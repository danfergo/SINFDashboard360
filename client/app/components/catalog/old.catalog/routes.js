angular.module('dash-catalog', []).
config(function ($stateProvider) {
  $stateProvider.
  state('catalog', {
    parent: 'ts',
    url: 'catalog',
    controller: 'catalogCategoriesController',
    templateUrl: 'components/catalog/categories.html',
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  }).
  state('catalogCategory', {
    parent: 'ts',
    url: 'catalog/:categoryId',
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
