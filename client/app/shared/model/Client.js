angular.module('dash-model').
factory('Client', ['$resource', function ($resource) {

  var resource = $resource('/api/clients/');


  return resource;
}]);
