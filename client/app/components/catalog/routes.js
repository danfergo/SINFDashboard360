angular.module('dash-catalog', []).
config(function ($stateProvider) {
  $stateProvider.
  /**state('catalog', {
    parent: 'ts',
    url: 'catalog',
    controller: 'catalogCategoriesController',
    templateUrl: 'components/catalog/categories.html',
    data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }
  }).**/
  state('catalog', {
    parent: 'ts',
    url: 'catalog',
    controller: 'catalogController',
    templateUrl: 'components/catalog/index.html',
    resolve: {
        /*'products' : ['Product', function(Product){
          return Product.get().$promise;
        }],
        'productCategories' : ['ProductCategory', function(ProductCategory){
          return ProductCategory.query().$promise;
        }]*/
    }
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  });
});
