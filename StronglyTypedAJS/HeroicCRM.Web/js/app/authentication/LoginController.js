(function () {
	'use strict';

	window.app.controller('LoginController', LoginController);

	LoginController.$inject = ['$window', '$http'];
	function LoginController($window, $http) {
		var vm = this;
		vm.errorMessage = null;
		vm.loggingIn = false;
		vm.login = login;

		function login() {
			
			vm.loggingIn = true;
			vm.errorMessage = null;

			$http.post("/Authentication/Login", { emailAddress: vm.emailAddress, password: vm.password })
				.success(function() {
					$window.location.href = "/";
				})
				.error(function(data) {
					vm.errorMessage = "There was a problem logging in: " + data;
				})
				.finally(function() {
					vm.loggingIn = false;
				});
		}
	}
})();
