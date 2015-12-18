angular.module('dash-model').
factory('Provider', ['$resource', function ($resource) {

  var resource = $resource('/api/providers/');


  return resource;
}]);
