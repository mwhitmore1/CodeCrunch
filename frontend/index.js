var myApp = angular.module('myApp',[]); 

myApp.controller('DemoCtrl', ['$scope', '$http', function($scope, $http) {

activate();

function activate() {
	$http({
	method: 'GET',
	url: 'demo.json'
	}).then(function (response) {

		debugger;

	})
}












	$scope.yourName = "Origin Code Academy";

var myPlanets = [
  {
    "id": 1,
    "name": "mercury",
    "gravity": 0.38
  },
  {
    "id": 2,
    "name": "venus",
    "gravity": 0.91
  },
  {
    "id": 3,
    "name": "earth",
    "gravity": 1
  },
  {
    "id": 4,
    "name": "mars",
    "gravity": 0.38
  }
];

// add to $scope
$scope.planets = myPlanets;

}]);