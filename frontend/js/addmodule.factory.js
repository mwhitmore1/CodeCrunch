(function() {
    'use strict';

    angular
        .module('app')
        .factory('ModuleFactory', ModuleFactory);

    ModuleFactory.$inject = ['$http', 'apiUrl', '$q', 'toastr'];

    /* @ngInject */
    function ModuleFactory($http, apiUrl, $q, 'toastr') {
        var service = {
            getModules : getModules
        };
        return service;

        ////////////////

        //Grabs the current modules from the database
        function getModules(){
        	var defer = $q.defer();

        	$http.get(apiUrl + 'modules')
        	     .then(
        	     	function(response){
        	     		defer.resolve(response);
        	     	},
        	     	function(err){
        	     		defer.reject(err.data.message);
        	     	}
        	     );
        	     return defer.promise;
        }//end of getModules function
    }//end of ModuleFactory function
})();