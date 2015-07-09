(function() {
	'use strict';

	window.app.directive('addRisk', addRisk);

	function addRisk() {
		return {
			scope: {
				customer: "="
			},
			templateUrl: '/risk/template/addRisk.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', '$http'];
	function controller($scope, $http) {
		var vm = this;

		vm.saving = false;
		vm.risk = {
			customerId: $scope.customer.id
		}

		vm.add = add;

		function add() {
			vm.saving = true;

			$http.post('/Risk/Add', vm.risk)
				.success(function (data) {
					$scope.customer.risks.push(data);
					//Close the modal
					$scope.$parent.$close();
				})
				.error(function (data) {
					vm.errorMessage = 'There was a problem adding the risk: ' + data;
				})
				.finally(function () {
					vm.saving = false;
				});
		}
	}
})();