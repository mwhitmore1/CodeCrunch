(function() {
    'use strict';

    angular
        .module('app')
        .controller('DiscussionController', DiscussionController);

    DiscussionController.$inject = ['serviceGenerator', 'apiUrl'];

    /* @ngInject */
    function DiscussionController(serviceGenerator, apiUrl) {
        var vm = this;
        vm.title = 'DiscussionController';
        var moduleId = 1;
        var url = apiUrl + 'api/ModuleQuestions';
        var service = serviceGenerator(url, 'Questions');

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