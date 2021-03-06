"use strict";

Frands.controller('RegisterController', [
  '$http', 
  '$scope',
  'AuthFactory',

  function ($http, $scope, authFactory) {

    $scope.twitterOauth = function () {
      OAuth.initialize('0q22Yq9s7BSXjyePVWWKeglIq6M')
      OAuth.popup('twitter').done(function(result) {
          console.log(result)
    // do some stuff with result

        result.me().done(function(data) {
            // do something with `data`, e.g. print data.name
            console.log(data);

            $http({
              url: "http://localhost:5000/api/Listener",
              method: "POST",
              data: JSON.stringify({
                UserName: data.alias,
                EmailAddress: data.email
              })
            }).then(
            response => {
              let theListener = response.data[0];
              authFactory.setUser(theListener);
              console.log("resolve fired", theListener);
            },
            response => {
              console.log("reject fired", response);

              // Listener has already been created
              if (response.status === 409) {
                $http
                  .get(`http://localhost:5000/api/Listener?username=${data.alias}`)
                  .then(
                    response => {
                      let theListener = response.data[0];
                      console.log("Found the Listener", theListener);
                      authFactory.setUser(theListener)
                    },
                    response => console.log("Could not find that Listener", response)
                  )
              }

            }
            )
        })
      });
    };
  }
]);

