// make functions ready when the document is loaded
$(document).ready(function () {

    $('.hide-button').on('click', () => {
        $('.signature').slideToggle()
    });

    // search function for causes, takes input uses lowercase version to find, toggles the undesired posts 
    $("#mySearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".signature").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });


    // animates footer button when mouse is over, returns to normal when mouse is off 
    $("#totop-button").mouseenter(function () {
        $("#totop-button").animate({ fontSize: '80px' }, 40);

        $("#totop-button").mouseleave(function () {
            $("#totop-button").animate({ fontSize: '50px' }, 40);
        });

    });

    // fade out animation for footer button when scrolling, 400 px down from top appears, above fades out   
    var btn = $('#totop-button')
    $(window).on("scroll", function () {
        var scrollPos = $(window).scrollTop();
        if (scrollPos <= 400) {
            $("#totop-button").fadeOut();
        } else {
            $("#totop-button").fadeIn();
        }
    });

    // on click scroll to top of page animation 
    btn.on('click', function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 },);
    });

});
