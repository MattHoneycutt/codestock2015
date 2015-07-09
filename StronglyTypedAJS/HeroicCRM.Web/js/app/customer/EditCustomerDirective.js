(function() {
	"use strict";

	window.app.directive('editCustomer', editCustomer);

	function editCustomer() {
		return {
			scope: {
				customer: "="
			},
			templateUrl: '/customer/template/editCustomer.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', 'customerSvc'];
	function controller($scope, customerSvc) {
		var vm = this;
		vm.save = save;

		vm.saving = false;
		vm.customer = angular.copy($scope.customer);
		vm.errorMessage = null;

		function save() {
			vm.saving = true;
			customerSvc.update($scope.customer, vm.customer)
				.success(function () {
					//Close the modal
					$scope.$parent.$close();
				})
				.error(function(data) {
					vm.errorMessage = 'There was a problem saving changes to the customer: ' + data;
				})
				.finally(function() {
					vm.saving = false;
				});
		}
	}
})();