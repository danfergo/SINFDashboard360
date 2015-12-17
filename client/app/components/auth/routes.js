angular.module('dash-auth', ['dash-model']).
controller('logoutController', ['Session', '$state', '$mdToast', function (Session, $state, $mdToast) {

  Session.delete(function () {
    $mdToast.show('Até breve!');
    $state.go('index');
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
    controller: 'logoutController',
    templateUrl: 'components/auth/logout.html',
  });
});
