"use strict";

Frands.controller('MainController', [
  '$http', 
  '$scope',

  function ($http, $scope) {

    $scope.tracks = [];

      // console.log(authFactory.getUser());

    $http
      .get('http://localhost:5000/api/Track')
      .success(inv => $scope.tracks = inv);

    $scope.viewTrack = function (id) {
      $http({
        method: "GET",
        url: `http://localhost:5000/api/Track/${id}`
      })
      .then(
        () => console.log("Getting track details"),
        () => console.log("Failed to get track details")
        );      
    }

  }

]);