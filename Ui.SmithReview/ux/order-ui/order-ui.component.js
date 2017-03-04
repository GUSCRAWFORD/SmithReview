var angular = require('angular');
angular.module('ui.smithReview')
	.component('orderUi', {
		template: require('./order-ui.template.html'),
		controller: orderUiController
	});

orderUiController.$inject = ['smithConstraints'];
function orderUiController(smithContstraints) {
	var ctrl = this;
	ctrl.$onInit = onInit;
	ctrl.constraints = smithContstraints;
	function onInit() {

	}
}