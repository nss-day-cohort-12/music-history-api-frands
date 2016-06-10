"use strict";

Frands.controller('RegisterController', [
  '$http', 
  '$scope',
  'AuthFactory',

  function ($http, $scope, authFactory) {

    $scope.githubOauth = function () {
      OAuth.initialize('pQOfs7xU3oz0aLT9ocjaVSLpTHY');

      OAuth.popup('github').done(function(result) {
          console.log(result)

        result.me().done(function(data) {
            // do something with `data`, e.g. print data.name
            console.log(data);

            $http({
              url: "http://localhost:5000/api/Listener",
              method: "POST",
              data: JSON.stringify({
                username: data.alias,
                emailAddress: data.email
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

