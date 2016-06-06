(function() {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['authService', 'toastr'];

    /* @ngInject */
    function RegisterController(authService, toastr) {
        var vm = this;
        vm.title = 'RegisterController';

        vm.registerUser = function(){
        	console.log("registerUser called");
        	authService.register(vm.form).then(
        		function(response){
        			toastr.success('Registration successful!');
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