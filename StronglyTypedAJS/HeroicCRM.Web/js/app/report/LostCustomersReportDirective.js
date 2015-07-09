(function() {
	'use strict';

	window.app.directive('lostCustomersReport', lostCustomersReport);

	function lostCustomersReport() {
		return {
			scope: true,
			templateUrl: '/report/template/lostCustomersReport.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$http'];
	function controller($http) {
		var vm = this;

		vm.isLoading = true;

		$http.post('/Report/LostCustomers')
			.success(function (customers) {
				vm.customers = customers;
				vm.isLoading = false;
			});
	}
})();