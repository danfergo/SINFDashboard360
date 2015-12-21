angular.module('dash-home', []).
config(function ($stateProvider) {
  $stateProvider.
  state('index', {
    parent: 'ts',
    url: '',
    controller: 'indexController',
    templateUrl: 'components/home/index.html',
    resolve: {
    	'purchases': ['Purchase','$filter',function(Purchase,$filter){
    		return Purchase.query({
			 	min_date: $filter('date')(moment().subtract(365,'days').toDate(),'dd-MM-yyyy'),
			 	max_date: $filter('date')(moment().toDate(),'dd-MM-yyyy'),
			});
    	}],
    	'sales' : ['Sale', '$filter', function(Sale,$filter) {
    		return Sales.query({
			 	min_date: $filter('date')(moment().subtract(365,'days').toDate(),'dd-MM-yyyy'),
			 	max_date: $filter('date')(moment().toDate(),'dd-MM-yyyy'),
			});
    	}]
    }
  });
});