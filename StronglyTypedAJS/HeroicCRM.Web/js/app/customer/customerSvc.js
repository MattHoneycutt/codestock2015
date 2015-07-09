(function() {
	window.app.factory('customerSvc', customerSvc);

	customerSvc.$inject = ['$http'];
	function customerSvc($http) {
		var customers = [];

		loadCustomers();

		var svc = {
			add: add,
			update: update,
			customers: customers,
			getCustomer: getCustomer
		};

		return svc;

		function loadCustomers() {
			$http.post('/Customer/All')
				.success(function(data) {
					customers.addRange(data);
				});

		}

		function add(customer) {
			return $http.post('/Customer/Add', customer)
				.success(function(customer) {
					customers.unshift(customer);
				});
		}

		function update(existingCustomer, updatedCustomer) {
			return $http.post('/Customer/Update', updatedCustomer)
				.success(function(customer) {
					angular.extend(existingCustomer, customer);
				});
		}

		function getCustomer(id) {
			for (var i = 0; i < customers.length; i++) {
				if (customers[i].Id == id) return customers[i];
			}

			return null;
		}
	}
})();