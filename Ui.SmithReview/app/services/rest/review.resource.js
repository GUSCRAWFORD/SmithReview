var angular = require('angular');
angular.module('app.smithReview').service('reviewResource', reviewResource);
reviewResource.$inject = ['$resource', 'restEndpoint', 'smithContraints'];
function reviewResource($resource, restEndpoint, smithContraints) {
	return $resource(restEndpoint + 'reviews', {
		item:'@item',
		page: smithContraints.defaultPage,
		perPage: smithContraints.defaultPerPage,
		orderBy: smithContraints.defaultOrderBy
	});
}