define(
    'dataservice.session-tests-function',
    ['jquery', 'amplify', 'config'],
    function($,amplify,config) {

    	var doNothing = function () { };

    	var retrievalTestOrganizationId = 1;

    	config.useMocks(true);
    	config.currentUserId = 3;
    	config.currentUser = function () { return { id: function () { return 3; } }; };
    	config.logger = { success: doNothing() };
    	config.dataserviceInit();

        var findDs = function() {
            return window.testFn(amplify);
        };

        module('Organization Data Services return data');

        asyncTest('getOrganizations return array Organizations objects',
            function() {
                var ds = findDs();

                ds.getOrganizations({
                    success: function(result) {
                        ok(result && result.length > 0, 'Got SessionBriefts');
                        start();
                    },
                    error: function(result) {
                        ok(false, 'Failed with: ' + result.responseText);
                    }
                });
            });

        asyncTest('getOrganization return array Organization objects',
			function() {
				var ds = findDs();

				ds.getOrganizations({
					success: function(result) {
						ok(result && result.length > 0, 'Got SessionBriefts');
						start();
					},
					error: function(result) {
						ok(false, 'Failed with: ' + result.responseText);
					}
				});
			});
    }
);