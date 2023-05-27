// Handle dropdown toggle
$("#login-button").on("click", function () {
  $(this).next(".dropdown-menu").toggle();
});
// Hide dropdown on click outside
$(document).on("click", function (e) {
  if (
    !$("#login-button").is(e.target) &&
    !$(".dropdown-menu").is(e.target) &&
    $(".dropdown-menu").has(e.target).length === 0
  ) {
    $(".dropdown-menu").hide();
  }
});
