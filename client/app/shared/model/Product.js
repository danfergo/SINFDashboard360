angular.module('dash-model').
factory('Product', ['$resource', function ($resource) {

  var resource = $resource('/api/products/:id',{},{
  	'get':  {method:'GET', isArray:true}
  });


  return resource;
}]);
