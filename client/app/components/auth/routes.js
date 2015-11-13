angular.module('dash-auth', ['dash-model']).
controller('logoutController', ['Session', '$state', function (Session, $state) {

  Session.delete(function () {
    $state.go('login');
  });

}]).
config(function ($stateProvider) {
  $stateProvider.
  state('login', {
    parent: 'lt',
    url: 'login',
    controller: 'loginController',
    templateUrl: 'components/auth/login.html',
    data: {
      permissions: {
        except: ['user'],
        redirectTo: 'index'
      }
    }
  }).
  state('logout', {
    parent: 'lt',
    url: 'logout',
    controller: 'logoutController'
  });
});
