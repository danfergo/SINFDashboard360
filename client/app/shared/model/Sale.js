angular.module('dash-model').
factory('Sale', ['$resource', function ($resource) {

  var resource = $resource('/api/sales/');


  return resource;
}]);
