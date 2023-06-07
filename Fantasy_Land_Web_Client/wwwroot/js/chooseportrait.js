function plusDivs(n) {
  showDivs((slideIndex += n));
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("portrait-container");
  if (n > x.length) {
    slideIndex = 1;
  }
  if (n < 1) {
    slideIndex = x.length;
  }
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }
  x[slideIndex - 1].style.display = "block";

  currentPortraitContainer = x[slideIndex - 1];
  if (currentPortraitContainer) {
    var image = currentPortraitContainer.querySelector("img");
    var PortraitId = image.getAttribute("data-portait-id");
    characterData.portrait_id = PortraitId;
  }
}

var selectedPortrait = null;
var currentPortraitContainer = null;
var slideIndex = 1;

showDivs(slideIndex);

$(document).on("click", "#go-back-port-btn", function () {
  // Make an AJAX request to the MainMenu endpoint
  $.ajax({
    url: "/choose-profession",
    type: "GET",
    success: function (response) {
      // Update the main-menu-container with the MainMenu view
      $("#choose-profession-container").show();
      $("#choose-profession-container").html(response);
      // Clear the create-character-container
      $("#choose-portrait-container").empty();
      $("#choose-portrait-container").hide();
      characterData.portrait_id = portraitid;
    },
    error: function (error) {
      console.log(error);
    },
  });
});

$(document).ready(function () {
  $(document).on("click", "#next-port-btn", function () {
    // Make an AJAX request to the MainMenu endpoint
    $.ajax({
      url: "/choose-attributes",
      type: "GET",
      success: function (response) {
        $("#choose-portrait-container").hide();
        $("#choose-attributes-container").show();
        $("#choose-attributes-container").html(response);
      },
      error: function (error) {
        console.log(error);
      },
    });
  });
});
