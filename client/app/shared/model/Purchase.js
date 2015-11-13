angular.module('dash-model').
factory('Purchases', ['$resource', function ($resource) {

  var resource = $resource('/api/purchases/');


  return resource;
}]);
