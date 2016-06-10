"use strict";

Frands.controller('ViewTrackController', [
  '$http', 
  '$scope',

  function ($http, $scope) {

    $scope.track = {};

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