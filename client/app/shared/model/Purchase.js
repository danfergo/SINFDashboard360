angular.module('dash-model').
factory('Purchase', ['$resource', function ($resource) {

  var resource = $resource('/api/purchases/');


  return resource;
}]);
