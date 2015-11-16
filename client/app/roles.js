angular.module('amep')
  .run(['Permission', 'Session', '$q', function (Permission, Session, $q) {
    Permission
      .defineRole('user', function (stateParams) {
        var deferred = $q.defer();
        Session.get(function (data) {
          if (data.nome) {
            deferred.resolve(); // Session exists , we are logged in :)
          } else {
            deferred.reject();  // Error with request
          }
        }, function () {
          deferred.reject();  // Error with request
        });

        return deferred.promise;
      });
  }]);
