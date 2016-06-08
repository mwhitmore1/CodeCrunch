(function() {
       'use strict';

       angular
           .module('app')
           .controller('addChapterController', addChapterController);

       addChapterController.$inject = [];

       /* @ngInject */
       function addChapterController() {
           var vm = this;
           vm.title = 'addChapterController';
           vm.preview = false;

        

           ////////////////


           // vm.newChapter = function(addNewChapters) {
           //     addChapterFactory.newChapters(addNewChapters).then(
           //         function(response) {
           //             vm.chapters.push(response.data);

           //         },
           //         function(error) {
           //             $log.error('failure getting chapters', error
           //             });
           //         vm.newChapter = {};

           }
       })();