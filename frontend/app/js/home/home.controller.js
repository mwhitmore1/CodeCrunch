(function() {
    'use strict';

    angular.module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['authService', 'toastr'];

    function HomeController(authService, toastr) {
        var vm = this;

        vm.loginUser = function() {
            console.log("loginUser called")
            authService.login(vm.form).then(
                function(response) {
                    toastr.success('Login successful!');
                },
                function(error) {
                    toastr.error("Error: " + error.message);
                    console.log("Error: " + error.message + " error.status");
                }
            );
        };

         vm.registerUser = function(){
            authService.register(vm.form).then(
                function(response){
                    toastr.success('Registration successful!');
                }, function(error){
                    toastr.error("Error: " + error.message);
                    console.log("Error: " + error.message + " error.status");
                });
        };
    }

})();
