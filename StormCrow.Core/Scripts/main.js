(function() {
    var root = this;

    define3RdPartyModules();
    loadPluginsAndBoot();

    function define3RdPartyModules() {
        define('jquery', [], function() { return root.jQuery; });
        define('ko', [], function() { return root.ko; });
        define('amplify', [], function() { return root.amplify; });
        define('infuser', [], function() { return root.infuser; });
        define('moment', [], function() { return root.moment; });
        define('sammy', [], function() { return root.Sammy; });
        define('toastr', [], function() { return root.toastr; });
        define('underscore', [], function() { return root._; });
    }

    function loadPluginsAndBoot() {
        //requirejs(['jquery.activity-ex'], boot);
    }

    function boot() {
        require(['bootstrapper'], function(bs) { bs.run(); });
    }

})();