angular.module('dash-auth').
controller('loginController', ['$scope', 'Session', '$state', '$mdToast', function ($scope, Session, $state, $mdToast) {


  $scope.login = function (email, password) {
    $scope.errorMessage = null;
    Session.save({email: email, password: password}, function (user) {
      $mdToast.show(
        $mdToast.simple()
          .content('Bem-vindo ' + user.nome + '!')
          .hideDelay(1500)
      );
      $state.go('agenda', {}, {reload: true});
    }, function (error) {
      $scope.errorMessage = error.data.error;
    });
  }

}]);
