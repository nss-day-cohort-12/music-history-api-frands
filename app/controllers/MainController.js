"use strict";

Frands.controller('MainController', [
  '$http', 
  '$scope',

  function ($http, $scope) {

    $scope.tracks = [];

    $http
      .get('http://localhost:5000/api/Track')
      .success(inv => $scope.tracks = inv);

    $scope.deleteTrack = function (id) {
      $http({
        method: "DELETE",
        url: `http://localhost:5000/api/Track/${id}`
      })
      .then(
        () => console.log("Track deleted"),
        () => console.log("Track not deleted")
      );
    }
  }

]);