angular.module('dash-humanResources').
controller('humanResourcesController', ['$scope', 'Deparment', function ($scope, Deparment) {
  $scope.$parent.pageTitle = "Recursos Humanos";
  $scope.departments = null;

  $scope.getTotalSalaries = function (department) {
    var total = 0;
    for (var e in department.employees) {
      total += department.employees[e].salary;
    }
    return total;
  };

  Deparment.query(function (data) {
    $scope.departments = data;

    $scope.labelsSalaries = [];
    $scope.dataSalaries = [];

    $scope.dataCollaborators = [];
    $scope.labelsCollaborators = [];

    for (var i = 0; i < data.length; i++) {
      $scope.dataSalaries.push($scope.getTotalSalaries(data[i]));
      $scope.labelsSalaries.push(data[i].description);

      $scope.dataCollaborators.push(data[i].employees.length);
      $scope.labelsCollaborators.push(data[i].description);

    }
  });

  $scope.toggle = function (event) {
    $(event.currentTarget).toggleClass('active');
  };

}]);
