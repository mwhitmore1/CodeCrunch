(function() {
    'use strict';

    angular
        .module('app')
        .controller('BootcampAddChapterController', BootcampAddChapterController);

    BootcampAddChapterController.$inject = [];

    /* @ngInject */
    function BootcampAddChapterController() {
        var vm = this;
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
