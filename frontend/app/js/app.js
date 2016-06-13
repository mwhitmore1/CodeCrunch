(function() {
    'use strict';
    angular.module('app', [
            'ui.router',
            'LocalStorageModule',
            'toastr',
            'xeditable'
        ])

    .run(function(editableOptions){
        editableOptions.theme = 'bs3';
    })
      
    .config(function($stateProvider, $urlRouterProvider, $httpProvider) {
        
            $urlRouterProvider.otherwise("home");

            $stateProvider
                .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController as home' })
                .state('discussion', { url: '/discussion', templateUrl: '/templates/discussion/discussion.html', controller: 'DiscussionController as discussion' })
                .state('browseTracks', { url: '/browseTracks', templateUrl: '/templates/home/browseTracks.html', controller: 'BrowseTracksController as browseTracks' })
                .state('bootcamp', { url: '/bootcamp', templateUrl: '/templates/bootcamp/bootcamp.index.html', controller: 'BootcampController as bootcamp' })
                    .state('bootcamp.dashboard', { url: '/dashboard', templateUrl: '/templates/bootcamp/bootcamp.dashboard.html', controller: 'BootcampDashboardController as bootcampDashboard' })
                    .state('bootcamp.tracks', { url: '/tracks', templateUrl: '/templates/bootcamp/bootcamp.tracks.html', controller: 'BootcampTracksController as bootcampTracks' })
                    .state('bootcamp.addChapter', { url: '/addChapter', templateUrl: '/templates/bootcamp/bootcamp.addChapter.html', controller: 'BootcampAddChapterController as bootcampAddChapter' })
                    .state('bootcamp.profile', { url: '/profile?bootcampId', templateUrl: '/templates/bootcamp/bootcamp.profile.html', controller: 'BootcampProfileController as bootcampProfile' })
                    .state('bootcamp.modules', { url: '/modules?modules', templateUrl: '/templates/bootcamp/bootcamp.modules.html', controller: 'BootcampModuleController as bootcampModules' })
                    .state('bootcamp.moduleDetail', { url: '/moduleDetail', templateUrl: '/templates/bootcamp/bootcamp.module.detail.html', controller: 'BootcampModuleDetailController as bootcampModuleDetail' })
                    .state('bootcamp.students', { url: '/students', templateUrl: '/templates/bootcamp/bootcamp.students.html', controller: 'BootcampStudentsController as bootcampStudents' })
                .state('student', { url: '/student', templateUrl: '/templates/student/student.index.html', controller: 'StudentsController as student' })
                    .state('student.profile', { url: '/profile', templateUrl: '/templates/student/student.profile.html', controller: 'StudentProfileController as studentProfile' })
                    .state('student.progress', { url: '/progress', templateUrl: '/templates/student/student.progress.html', controller: 'StudentProgressController as studentProgress' })
                    .state('student.viewchapter', { url: '/viewchapter', templateUrl: '/templates/student/student.viewchapter.html', controller: 'StudentViewChapterController as studentViewChapter' })
            $httpProvider.interceptors.push('authInterceptor');
        })
        .value('apiUrl', 'http://localhost:57079/api/');
})();
