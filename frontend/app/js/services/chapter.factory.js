(function() {
    'use strict';

    angular
        .module('app')
        .factory('chapterFactory', chapterFactory);

    moduleFactory.$inject = ['serviceGenerator', 'apiUrl'];

    /* @ngInject */
    function chapterFactory(serviceGenerator, apiUrl) {
        return serviceGenerator(apiUrl, 'chapter');
    }
})();
