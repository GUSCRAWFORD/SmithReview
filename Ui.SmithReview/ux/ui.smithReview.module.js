var angular = require('angular');
require('angular-bootstrap-npm');
require('angular-animate');
require('angular-route');
var smithReviewApp = require('../app/app.smithReview.module');
angular.module('ui.smithReview', ['app.smithReview', 'ui.bootstrap', 'ngAnimate', 'ngRoute']);

angular.element(function () {
	angular.bootstrap(document, ['ui.smithReview']);
});
require('./catalog');
require('./review');