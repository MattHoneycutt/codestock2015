(function() {
	'use strict';

	window.app.controller('CustomerListController', CustomerListController);

	CustomerListController.$inject = ['$modal', 'customerSvc'];
	function CustomerListController($modal, customerSvc) {
		var vm = this;
		vm.add = add;
		vm.customers = customerSvc.customers;


		function add() {
			$modal.open({
				template: '<add-customer />'
			});
		}
	}
})();