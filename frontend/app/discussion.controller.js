(function() {
    'use strict';

    angular
        .module('app')
        .controller('DiscussionController', DiscussionController);

    DiscussionController.$inject = ['ServiceGenerator', 'apiUrl'];

    /* @ngInject */
    function DiscussionController(ServiceGenerator, apiUrl) {
        var vm = this;
        vm.title = 'DiscussionController';
        var moduleId = 1;
        var url = apiUrl + 'api/ModuleQuestions/Module/' + moduleId;
        var service = ServiceGenerator(url, 'Questions');

        activate();

        ////////////////

        function activate() {
        	service.getAll().then(function(response){
        		vm.discussions = response.data;
        	}, function(error){
        		vm.discussion = null;
        	});
        }
    }
})();