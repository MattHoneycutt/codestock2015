(function() {
	'use strict';

	window.app.directive('customerDetails', customerDetails);
	function customerDetails() {
		return {
			scope: {
				customer: '='
			},
			templateUrl: '/customer/template/customerDetails.tmpl.cshtml',
			controller: controller,
			controllerAs: 'vm'
		}
	}

	controller.$inject = ['$scope', '$modal'];
	function controller($scope, $modal) {
		var vm = this;

		vm.customer = $scope.customer;
		vm.selectedView = 'details';
		vm.setView = setView;
		vm.edit = edit;
		vm.addOpportunity = addOpportunity;
		vm.addRisk = addRisk;
		vm.customer = $scope.customer;

		function setView(view) {
			vm.selectedView = view;
		}


		function edit() {
			$modal.open({
				template: '<edit-customer customer="customer" />',
				scope: angular.extend($scope.$new(true), { customer: vm.customer })
			});
		}

		function addOpportunity() {
			$modal.open({
				template: '<add-opportunity customer="customer" />',
				scope: angular.extend($scope.$new(true), { customer: vm.customer })
			});
		}

		function addRisk() {
			$modal.open({
				template: '<add-risk customer="customer" />',
				scope: angular.extend($scope.$new(true), { customer: vm.customer })
			});
		}
	}
})();