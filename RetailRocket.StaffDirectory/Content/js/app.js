(function () {
    $(document).ready(function() {
        setActiveNavigation();
        $('#datetimepicker').datetimepicker({
            format: 'L'
        });
    });

    function setActiveNavigation() {
        var pathname = window.location.pathname;
        $(".nav li").removeClass("active");

        if (pathname.toUpperCase().indexOf('DEPARTMENT') > -1 || pathname.length == 1) {
            $('#departmentNav').addClass('active');
        } else {
            $('#staffNav').addClass('active');
        }
    }
})();

