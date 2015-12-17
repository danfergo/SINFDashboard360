angular.module('dash-layouts',['dash-sidebar']).
config(function ($stateProvider, $urlRouterProvider) {

  $stateProvider.
  state('ls', {
    url: '/',
    abstract:true,
    templateUrl: 'shared/layouts/sidebar.html',
    resolve:{
      currentSession: ['Session', function(Session){
        return Session.get().$promise;
      }]
    }
   }).
  state('lt', {
    url: '/',
    abstract:true,
    templateUrl: 'shared/layouts/toolbar.html',
    resolve:{
      currentSession: ['Session', function(Session){
        return Session.get().$promise;
      }]
    }
  }).
  state('ts', {
    url:'/',
    abstract:true,
    templateUrl:'shared/layouts/both.html',
    controller: ['$scope','currentSession', function($scope,currentSession){
      $scope.pageTitle = "Loja X";
      $scope.currentSession = currentSession;

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


    }],
    resolve:{
      'currentSession': ['Session', function(Session){
        return Session.get().$promise;
      }]
    }
  });

});
