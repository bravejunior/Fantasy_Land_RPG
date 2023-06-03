$(document).ready(function () {
  $("#play-game-btn").click(function () {
    // Make an AJAX request to the CreateCharacter endpoint
    $.ajax({
      url: "/create-character",
      type: "GET",
      success: function (response) {
        // Update the create-character-container with the CreateCharacter partial view
        $("#create-character-container").html(response);
        // Hide the main-menu-container
        $("#main-menu-container").hide();
      },
      error: function (error) {
        console.log(error);
      },
    });
  });
});