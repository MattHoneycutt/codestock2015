(function() {
	"use strict";

	window.app.directive('addCustomer', addCustomer);

	function addCustomer() {
		return {
			templateUrl: '/customer/template/addCustomer.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', 'customerSvc'];
	function controller($scope, customerSvc) {
		var vm = this;
		vm.add = add;

		vm.saving = false;
		vm.customer = {};
		vm.errorMessage = null;

		function add() {
			vm.saving = true;
			customerSvc.add(vm.customer)
				.success(function () {
					//Close the modal
					$scope.$close();
				})
				.error(function(data) {
					vm.errorMessage = 'There was a problem adding the customer: ' + data;
				})
				.finally(function() {
					vm.saving = false;
				});
		}
	}
})();