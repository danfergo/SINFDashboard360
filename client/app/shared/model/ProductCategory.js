angular.module('dash-model').
factory('ProductCategory', ['$resource', function ($resource) {

  var resource = $resource('/api/ProductCategories/');


  return resource;
}]);
