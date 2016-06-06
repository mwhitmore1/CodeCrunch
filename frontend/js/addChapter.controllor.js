(function() {
       'use strict';

       angular
           .module('app')
           .controller('addChapterController', addChapterController);

       addChapterController.$inject = ['$log', 'addChapterFactory'];

       /* @ngInject */
       function addChapterController($log, addChapterFactory) {
           var vm = this;
           vm.title = 'addChapterController';

           activate();

           ////////////////

           vm.newChapter = function(addNewChapters) {
               addChapterFactory.newChapters(addNewChapters).then(
                   function(response) {
                       vm.chapters.push(response.data);

                   },
                   function(error) {
                       $log.error('failure getting chapters', error
                       });
                   vm.newChapter = {};
               }
           }
       })();