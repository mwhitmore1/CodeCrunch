(function() {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['authService','$state','toastr'];

    /* @ngInject */
    function AppController(authService, $state, toastr) {
        var vm = this;
        vm.loginUser = function() {
            console.log("hello world");
            authService.login(vm.loginForm).then(
                function(response) {
                    toastr.success('Login successful!');
                    $state.go('bootcamp.profile', { bootcampId: response.userID });
                },
                function(error) {
                    toastr.error("Error: " + error.message);
                    console.log("Error: " + error.message + " error.status");
                }
            );
        };

         vm.registerUser = function(){	
            authService.register(vm.registerForm).then(
                function(response){
                    console.log(response);
                    toastr.success('Registration successful!');
                    /*$state.go('/login');*/
                }, function(error){
                    toastr.error("Error: " + error.message);
                    console.log("Error: " + error.message + " error.status");
                });
        };
    }
})();