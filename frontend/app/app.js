(function(){
	'use strict';
	angular.module('app', [
		'ui.router',
		'LocalStorageModule',
		'toastr'
		])
		 .config(function($stateProvider, $urlRouterProvider, $httpProvider){
			$urlRouterProvider.otherwise("login");
			$stateProvider
			.state('addchapter', { url: '/addchapter', templateUrl: '/addchapter.html', controller: 'AddChapterController as addChapter'})
			.state('login', { url: '/student/profile', templateUrl: '/student.profile.html', controller: 'StudentProfileController as studentProfile'})
			.state('posts', { url: '/posts', templateUrl: '/templates/posts.html', controller: 'PostsController as posts'})
			.state('main', {url: '/main', templateUrl: '/index_main.html', controller: 'MainController as main'});
			$httpProvider.interceptors.push('authInterceptor');
		 })	
		 .value('apiUrl', 'http://localhost:57079/');
})();
