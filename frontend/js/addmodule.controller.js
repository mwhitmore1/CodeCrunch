(function() {
    'use strict';

    angular
        .module('app')
        .controller('ModuleController', ModuleController);

    ModuleController.$inject = ['ModuleFactory', '$state', 'toastr', 'authService'];

    /* @ngInject */
    function ModuleController(ModuleFactory, $state, toastr, authService) {
        var vm = this;
        vm.title = 'ModuleController';
        vm.modules = [];

        ////////////////

        vm.grabModules = function (){
        	ModuleFactory.getModules(vm.modules)
        				 .then(
        				 	function(response){
        				 		console.log(response)
        				 		vm.modules = response.data;
        				 		console.log(data);
        				 	},
        				 	function(message){
        				 		toastr.warning(message);
        				 	}
        				 );
        }

        vm.grabModules();
  
    }
})();