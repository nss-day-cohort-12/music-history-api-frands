"use strict";

Frands.factory('AuthFactory', [

function () {

  let currentUser = null;

  return {
    getUser () {
      return currentUser;
    },
    setUser (user) {
      currentUser = user;
    }
  }
}


]);