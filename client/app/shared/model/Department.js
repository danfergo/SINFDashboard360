angular.module('dash-model').
factory('Deparment', ['$resource', function ($resource) {

  var resource = $resource('/api/departments/');


  return resource;
}]);
