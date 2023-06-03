$(document).ready(function () {
  $(document).on("click", "#go-back-btn", function () {
    // Make an AJAX request to the MainMenu endpoint
    $.ajax({
      url: "/main-menu",
      type: "GET",
      success: function (response) {
        // Update the main-menu-container with the MainMenu view
        $("#main-menu-container").show();
        $("#main-menu-container").html(response);
        // Clear the create-character-container
        $("#create-character-container").empty();
      },
      error: function (error) {
        console.log(error);
      },
    });
  });
});
