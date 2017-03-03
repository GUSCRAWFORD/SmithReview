var angular = require('angular');
angular.module('ui.smithReview')
	.component('review', {
		template: require('./review.template.html'),
		controller: reviewController,
		bidings: {
			item:'<'
		}
	})
	.config(function ($routeProvider) {
		$routeProvider.when('/review/:itemId', {
			template: '<review item="$resolve.item"></review>',
			resolve: function (itemResource, $route) {
				return itemResource.get({ id: $route.current.params.itemId }).$promise;
			}
		})
	});

reviewController.$inject = ['reviewResource', 'smithConstraints'];
function reviewController(reviewResource, smithContstraints) {
	var ctrl = this;
	ctrl.busy = true;
	ctrl.$onInit = onInit;
	ctrl.constraints = smithContstraints;
	function onInit() {
		reviewResource.query({item:ctrl.item.Id}).$promise.then(function (items) {
			ctrl.items = items;
			ctrl.busy = false;
		});
	}
}