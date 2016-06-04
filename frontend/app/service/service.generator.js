(function(){
    'use strict';

    angular
        .module('app')
        .factory('ServiceGenerator', ServiceGenerator);
        
        ServiceGenerator.$inject = ["$http", "$q"]; 

        function ServiceGenerator ($http, $q) {
            return function (endpoint, entityName) {
                return {
                    getAll: function getAll() {
                        var deferred = $q.defer();

                        $http.get(endpoint)
                            .success(function (data) {
                                deferred.resolve(data);
                            })
                            .error(function (error) {
                                console.log(error);
                                toastr.error("There was a problem fetching " + entityName.toLowerCase() + "s.");
                                deferred.reject("There was a problem fetching " + entityName.toLowerCase() + "s.");
                            });

                        return deferred.promise;
                    },
                    getById: function getById(id) {
                        var deferred = $q.defer();

                        $http.get(endpoint + '/' + id)
                            .success(function (data) {
                                deferred.resolve(data);
                            })
                            .error(function (error) {
                                console.log(error);
                                toastr.error("There was a problem fetching that " + entityName.toLowerCase() + ".");
                                deferred.reject("There was a problem fetching that " + entityName.toLowerCase() + ".");
                            });

                        return deferred.promise;
                    },
                    create: function create(entity) {
                        var deferred = $q.defer();

                        $http.post(endpoint, entity)
                            .success(function (data) {
                                toastr.success("Created " + entityName.toLowerCase() + " successfully.");
                                deferred.resolve(data);
                            })
                            .error(function (error) {
                                console.log(error);
                                toastr.error("There was a problem creating that " + entityName.toLowerCase() + ".");
                                deferred.reject("There was a problem creating that " + entityName.toLowerCase() + ".");
                            });

                        return deferred.promise;
                    },
                    update: function update(entity) {
                        var deferred = $q.defer();

                        $http.put(endpoint + '/' + entity.Id, entity)
                            .success(function (data) {
                                toastr.success("Saved " + entityName.toLowerCase() + " successfully.");
                                deferred.resolve(data);
                            })
                            .error(function (error) {
                                console.log(error);
                                toastr.error("There was a problem updating this " + entityName.toLowerCase() + ".");
                                deferred.reject("There was a problem updating this " + entityName.toLowerCase() + ".");
                            });

                        return deferred.promise;
                    },
                    remove: function remove(id) {
                        var deferred = $q.defer();

                        $http.delete(endpoint + '/' + id)
                            .success(function (data) {
                                toastr.success("Deleted " + entityName.toLowerCase() + " successfully.");
                                deferred.resolve(data);
                            })
                            .error(function (error) {
                                console.log(error);
                                toastr.error("There was a problem deleting " + entityName.toLowerCase() + ".");
                                deferred.reject("There was a problem deleting that " + entityName.toLowerCase() + ".");
                            });

                        return deferred.promise;
                    }
                };
            };
        }
})();