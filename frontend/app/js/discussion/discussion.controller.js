(function() {
    'use strict';

    angular
        .module('app')
        .controller('DiscussionController', DiscussionController);

    DiscussionController.$inject = ['serviceGenerator', 'apiUrl', '$http'];

    /* @ngInject */
    function DiscussionController(serviceGenerator, apiUrl, $http) {
        var vm = this;
        vm.title = 'DiscussionController';
        var moduleId = 1;
        var url = apiUrl + 'api/QuestionsForModule/' + moduleId;
        var questionsForModule = serviceGenerator(url, 'Questions');
        
        var postAnswerUrl = apiUrl + 'api/ModuleAnswers';
        var moduleAnswers = serviceGenerator(postAnswerUrl, 'answers');

        vm.postAnswer = function(data){
            moduleAnswers.create(data);
        };

        activate();
        
        //////////////

        function activate() {
        	questionsForModule.getAll().then(function(response){
        		vm.questions = response;
                console.log(vm.questions);
        	}, function(error){
        		vm.questions = null;
        	});
        }
    }
})();