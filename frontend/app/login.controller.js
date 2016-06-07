(function() {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['authService', 'toastr'];

    /* @ngInject */
    function LoginController(authService, toastr) {
        var vm = this;
        vm.title = 'LoginController';

        vm.loginUser = function(){
            console.log("loginUser called")
        	authService.login(vm.form).then(
        		function(response){
        			toastr.success('Login successful!');
        		}, function(error){
        			toastr.error("Error: " + error.message);
        			console.log("Error: " + error.message + " error.status");
        		});
        };
        activate();

        ////////////////

        function activate() {
        }
    }
})();			