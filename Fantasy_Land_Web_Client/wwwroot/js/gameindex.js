$(document).ready(function () {
  // Make an AJAX request to the CreateCharacter endpoint
  $.ajax({
    url: "/main-menu",
    type: "GET",
      success: function (response) {
      // Check if the response is a partial view or main menu view
      if (response.isPartial) {
        // Update the create-character-container with the partial view
        $("#main-menu-container").html(response.partialView);
      } else {
        // Update the main-menu-container with the main menu view
        $("#main-menu-container").html(response);
      }
    },
    error: function (error) {
      console.log(error);
    },
  });
});
