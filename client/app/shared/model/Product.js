angular.module('dash-model').
factory('Product', ['$resource', function ($resource) {

  var resource = $resource('/api/products/');


  return resource;
}]);
