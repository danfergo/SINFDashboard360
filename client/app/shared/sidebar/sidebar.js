angular.module('dash-sidebar', []).
controller('SidebarController', ['$scope', 'Session', '$mdSidenav',function ($scope, Session, $mdSidenav) {
  $scope.$mdSidenav = $mdSidenav;
  $scope.menu = [
    {
      state: 'index',
      title: 'Início',
      icon: 'dashboard'
    },
    {
      state: 'purchases',
      title: 'Compras',
      icon: 'shopping_cart'
    },
    {
      state: 'catalog',
      title: 'Catalogo',
      icon: 'shop'
    },
    {
      state: 'humanResources',
      title: 'Recursos Humanos',
      icon: 'assignment_ind'
    },
    {
      state: 'sales',
      title: 'Vendas',
      icon: 'receipt'
    },
    {
      state: 'accounting',
      title: 'Contabilidade',
      icon: 'assessment'
    },
    {
      state: 'clients',
      title: 'Clientes',
      icon: 'face'
    }

  ];

  $scope.wait = function(){
    $scope.wait = true;
  }
}]).
directive('dashSidebar', ['Session', '$rootScope', function (Session) {
 /*function link(scope) {

    scope.$watch(function () {
      return Session.getSessionInCache();
    }, function (value) {
      if (value && value[0] == 200) {  resolved
        $('body').removeClass('no-sidenav-left');
      } else { rejected
        $('body').addClass('no-sidenav-left');
        scope.$mdSidenav('left').close();
      }
    });
  }*/

  return {
    restrict: 'A',  // Forces the directive to be an attribute.
    //link: link,
    controller: 'SidebarController',
    templateUrl: '/shared/sidebar/sidebar.html',
    scope: false
  };
}]);


