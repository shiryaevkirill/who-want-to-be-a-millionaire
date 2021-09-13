// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

jQuery(document).ready(function () {
    $('button.myLinkModal').click(function (event) {
        event.preventDefault();
        $('#myOverlay').fadeIn(297, function () {
            $('#myModal')
                .css('display', 'block')
                .animate({ opacity: 1 }, 198);
        });
    });

    $('#myModal__close, #myOverlay, .restart').click(function () {
        $('#myModal').animate({ opacity: 0 }, 198, function () {
            $(this).css('display', 'none');
            $('#myOverlay').fadeOut(297);
        });
    });

    var numberInputs = $('[type="number"]');
    $.each(numberInputs, function (index, item) {
        if ($(this).data('val-range')) {
            var min = $(this).data('val-range-min');
            var max = $(this).data('val-range-max');
            $(this).attr('min', min);
            $(this).attr('max', max);
            console.log("test")
        }
    })
});

