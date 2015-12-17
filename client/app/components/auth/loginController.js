angular.module('dash-auth').
controller('loginController', ['$scope', 'Session', '$state', '$mdToast', function ($scope, Session, $state, $mdToast) {

  $scope.waiting = false;

  $scope.login = function (email, password) {
    $scope.errorMessage = null;
    $scope.waiting = true;
    Session.save({email: email, password: password}, function (user) {
      if(user.nome){
        $mdToast.show('Bem-vindo ' + user.nome + '!');
        $state.go('index', {}, {reload: true});
      }else{
        $scope.errorMessage = user.error;
        $scope.waiting = false;
      }
    }, function (error) {
      $scope.errorMessage = error.data.error;
      $scope.waiting = false;
    });
  }

}]);
