(function () {
	'use strict';

	window.app.directive('inputValidationIcons', inputValidationIcons);

	function inputValidationIcons() {
		return {
			require: '^form',
			scope: {
				field: '='
			},
			template:
				'<span ng-show="vm.canBeValidated() && vm.isValid()" ' +
					'class="fa fa-2x fa-check-square form-control-feedback"></span>' +
				'<span ng-show="vm.canBeValidated() && !vm.isValid()" ' +
					'class="fa fa-2x fa-exclamation-triangle form-control-feedback"></span>',
			controller: controller,
			controllerAs: 'vm',
			link: function (scope, element, attrs, formCtrl) {
				scope.form = formCtrl;
			}
		}
	}

	controller.$inject = ['$scope'];
	function controller($scope) {
		var vm = this;

		vm.field = $scope.field;
		vm.canBeValidated = canBeValidated;
		vm.isValid = isValid;

		function canBeValidated() {
			return ($scope.form[vm.field].$touched || $scope.form.$submitted);
		}

		function isValid() {
			return $scope.form[vm.field].$valid;
		}
	}
})();