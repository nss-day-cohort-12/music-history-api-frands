"use strict";

let Frands = angular.module('Frands', [
  'ngRoute'
]);

Frands.config(['$routeProvider', 
  function ($routeProvider) {
  $routeProvider
    .when('/', {
      templateUrl: 'partials/main.html',
      controller: 'MainController'
    })
    .when('/create', {
      templateUrl: 'partials/newTrack.html',
      controller: 'NewTrackController'
    })
    .when('/register', {
      templateUrl: 'partials/register.html',
      controller: 'RegisterController'
    })
    .otherwise('/');
  }
]);