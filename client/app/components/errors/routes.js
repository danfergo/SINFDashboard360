angular.module('dash-errors', []).
config(function ($stateProvider) {
  $stateProvider.
  state('404', {
    parent: 'lt',
    url: '404',
    templateUrl: 'components/errors/404.html'
  });
});
