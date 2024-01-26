// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    $(document).ready(function () {
        $(".datepicker").datepicker({
            dateFormat: 'yy-mm-dd', // Change the date format
            showOtherMonths: true, // Show dates from other months
            selectOtherMonths: true // Allow selecting dates from other months
        });
    });
</script>
