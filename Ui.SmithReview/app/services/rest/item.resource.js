var angular = require('angular');
angular.module('app.smithReview').service('itemResource', itemResource);
itemResource.$inject = ['$resource', 'restEndpoint', 'smithContraints'];
function itemResource($resource, restEndpoint, smithContraints) {
	return $resource(restEndpoint + 'items', {
		page: smithContraints.defaultPage,
		perPage: smithContraints.defaultPerPage,
		orderBy: smithContraints.defaultOrderBy
	});
}