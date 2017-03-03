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

catalogController.$inject = ['itemResource'];
function catalogController(itemResource) {
	var ctrl = this;
	ctrl.busy = true;
	itemResource.query().$promise.then(function () {
		ctrl.busy = false;
	});
}