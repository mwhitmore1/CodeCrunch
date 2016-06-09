(function() {
    'use strict';

    angular
        .module('app')
        .controller('BootcampProfileController', BootcampProfileController);

    BootcampProfileController.$inject = [];

    /* @ngInject */
    function BootcampProfileController() {
        var vm = this;
        vm.title = 'BootcampProfileController';

        activate();

        ////////////////

        function activate() {
        }
    }
})();