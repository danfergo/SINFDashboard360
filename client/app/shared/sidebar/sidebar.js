angular.module('dash-sidebar', []).
controller('SidebarController', ['$scope', 'Session', '$mdSidenav', function ($scope, Session, $mdSidenav) {
  $scope.$mdSidenav = $mdSidenav;
  $scope.session = false;

  Session.get(function (data) {
    $scope.session = data; // Session exists , we are logged in :)
  })

  $scope.menu = [
    {
      state: 'index',
      title: 'Home',
      icon: 'dashboard'
    },
    {
      state: 'purchases',
      title: 'Purchases',
      icon: 'shopping_cart'
    },
    {
      state: 'catalog',
      title: 'Products Catalog',
      icon: 'shop'
    },
    {
      state: 'humanResources',
      title: 'Human Resources',
      icon: 'assignment_ind'
    },
    {
      state: 'sales',
      title: 'Sales',
      icon: 'receipt'
    },
    {
      state: 'accounting',
      title: 'Accounting',
      icon: 'assessment'
    },
    {
      state: 'clients',
      title: 'Clients',
      icon: 'face'
    }

  ];

}]).
directive('dashSidebar', ['Session', '$rootScope', function (Session) {
  function link(scope) {

    scope.$watch(function () {
      return Session.getSessionInCache();
    }, function (value) {
      if (value && value[0] == 200) { // resolved
        $('body').removeClass('no-sidenav-left');
      } else { //rejected
        $('body').addClass('no-sidenav-left');
        scope.$mdSidenav('left').close();
      }
    });
  }

  return {
    restrict: 'A',  // Forces the directive to be an attribute.
    link: link,
    controller: 'SidebarController',
    templateUrl: '/shared/sidebar/sidebar.html'
  };
}]);


