"use strict";

Frands.controller('MainController', [
  '$http', 
  '$scope',
  'AuthFactory',

  function ($http, $scope, authFactory) {

    console.log(authFactory.getUser());

    $scope.tracks = [];

    let userId = authFactory.getUser().ListenerId;

    $http
      .get(`http://localhost:5000/api/Track/?ListenerId=${userId}`)
      .success(inv => $scope.tracks = inv);

    // $http
    //   .get('http://localhost:5000/api/Track')
    //   .success(inv => $scope.tracks = inv);

    // $scope.viewTrack = function (id) {
    //   $http({
    //     method: "GET",
    //     url: `http://localhost:5000/api/Track/${id}`
    //   })
    //   .then(
    //     () => console.log("Getting track details"),
    //     () => console.log("Failed to get track details")
    //   );      
    // }

  }

]);