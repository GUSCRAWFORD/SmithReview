var angular = require('angular');
angular.module('ui.smithReview')
	.component('catalog', {
		template: require('./catalog.template.html'),
		controller: catalogController
	})
	.config(function ($routeProvider) {
		$routeProvider.when('/', {
			template: '<catalog></catalog>'
		})
	});

catalogController.$inject = ['itemResource','smithConstraints'];
function catalogController(itemResource, smithContstraints) {
	var ctrl = this;
	ctrl.busy = true;
	ctrl.$readOnly = true;
	ctrl.$onInit = onInit;
	ctrl.constraints = smithContstraints;
	function onInit() {
		itemResource.query({ page: smithContstraints.defaultPage,
			perPage: smithContstraints.defaultPerPage,
			orderBy: smithContstraints.defaultOrderBy
		}).$promise.then(function (items) {
			ctrl.items = items;
			ctrl.busy = false;
		});
	}
}