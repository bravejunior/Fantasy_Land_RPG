// Send data to the API endpoint
// function saveCharacterData() {
//   $.ajax({
//     url: "/api/character",
//     type: "POST",
//     data: characterData,
//     success: function (response) {
//       // Handle the success response if needed
//     },
//     error: function (error) {
//       // Handle the error response if needed
//     },
//   });
// }

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

$(document).ready(function () {
  $(document).on("click", "#next-btn", function () {
    // Make an AJAX request to the MainMenu endpoint
    $.ajax({
      url: "/choose-portrait",
      type: "GET",
      success: function (response) {
        // Update the main-menu-container with the MainMenu view
        $("#choose-portrait-container").show();
        $("#choose-portrait-container").html(response);
        // Clear the create-character-container
        $("#create-character-container").hide();
      },
      error: function (error) {
        console.log(error);
      },
    });
  });
});

/*var chosenProfessionDesc = "";

function typeWriter() {
  var descriptionElement = document.getElementById(
    "create-character-profession-desc"
  );
  var descriptionText = descriptionElement.getAttribute("data-description");

  var text = descriptionText;
  var speed = 8; // Adjust the typing speed (in milliseconds) as needed
  var i = 0;

  function type() {
    if (i < text.length) {
      descriptionElement.innerHTML += text.charAt(i);
      i++;
      setTimeout(type, speed);
    }
  }

  type();
  console.log(descriptionText);
}

window.addEventListener("DOMContentLoaded", typeWriter());
*/
var characterData = {
  profession: "",
  attributes: {},
  name: "",
};

var selectedProfessionIcon = null;
var currentProfessionContainer = null;
var slideIndex = 1;

showDivs(slideIndex);

function plusDivs(n) {
  showDivs((slideIndex += n));
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("profession-container");
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

  currentProfessionContainer = x[slideIndex - 1];
  if (currentProfessionContainer) {
    var professionName = currentProfessionContainer.querySelector(
      ".create-character-profession-name"
    );
    characterData.profession = professionName;

  }
}
