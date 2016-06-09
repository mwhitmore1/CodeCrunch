(function() {
    'use strict';

    angular
        .module('app')
        .controller('BootcampModulesController', BootcampModulesController);

    BootcampModulesController.$inject = [];

    /* @ngInject */
    function BootcampModulesController() {
        var vm = this;
        vm.title = 'BootcampModulesController';

        activate();

        ////////////////

        function activate() {
        }
    }
})();