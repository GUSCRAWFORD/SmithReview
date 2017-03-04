var angular = require('angular');
angular.module('ui.smithReview')
	.component('review', {
		template: require('./review.template.html'),
		controller: reviewController,
		bindings: {
			item:'<'
		}
	})
	.config(function ($routeProvider) {
		$routeProvider.when('/review/:itemId', {
			template: '<review item="$resolve.item"></review>',
			resolve: {
				item:function (itemResource, $route) {
					return itemResource.get({ id: $route.current.params.itemId }).$promise;
				}
			}
		})
	});

reviewController.$inject = ['reviewResource', 'smithConstraints'];
function reviewController(reviewResource, smithContstraints) {
	var ctrl = this;
	ctrl.busy = true;
	ctrl.busyMessage;
	ctrl.$onInit = onInit;
	ctrl.edit = edit;
	ctrl.discardEdit = discardEdit;
	ctrl.saveEdit = saveEdit;
	ctrl.constraints = smithContstraints;

	function edit(val) {
		ctrl.editing = {
			Rating: val,
			Comment: '',
			Reviewing: { Id: ctrl.item.Id }
		};
	}
	function discardEdit() {
		ctrl.editing = null;
		ctrl.item.AverageRating = ctrl.defaultRating;
	}
	function saveEdit() {
		ctrl.busy = true;
		ctrl.busyMessage = "Saving your review...";
		reviewResource.save(ctrl.editing).$promise.then(function () {
			ctrl.busy = ctrl.busyMessage = false;
			ctrl.item.AverageRating = ctrl.defaultRating;
			ctrl.$onInit();
			ctrl.editing = null;
		});
	}
	function onInit() {

		ctrl.defaultRating = ctrl.item.AverageRating;
		reviewResource.query({
			item: ctrl.item.Id,
			perPage: smithContstraints.defaultPerPage,
			orderBy: smithContstraints.defaultOrderBy
		}).$promise.then(function (reviews) {
			ctrl.reviews = reviews;
			ctrl.busy = false;
		});
	}
}