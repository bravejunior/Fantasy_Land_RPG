﻿/*
var descriptionElement = document.getElementById(
  "create-character-profession-desc"
);
var descriptionText = descriptionElement.getAttribute("data-description");

function typeWriter() {
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
  console.log("sss");
}

window.addEventListener("DOMContentLoaded", typeWriter());
*/
// Call the typewriter function when the page loads


function plusDivs(n) {
  showDivs((si += n));
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("profession-container");
  if (n > x.length) {
    si = 1;
  }
  if (n < 1) {
    si = x.length;
  }
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }
  x[si - 1].style.display = "block";
  currentProfessionContainer = x[si - 1];
  if (currentProfessionContainer) {
    var professionName = currentProfessionContainer.querySelector(
      ".create-character-profession-name"
    );
    characterData.profession = professionName.textContent;
  }
}
var currentProfessionContainer = null;
var si = 1;
var currentPortraitContainer = null;
var slideIndex = 1;

showDivs(si);

$(document).on("click", "#go-back-prof-btn", function () {
  // Make an AJAX request to the MainMenu endpoint
  $.ajax({
    url: "/play",
    type: "GET",
    success: function (response) {
      document.open();
      document.write(response);
      document.close();
    },
    error: function (error) {
      console.log(error);
    },
  });
});

$(document).on("click", "#next-prof-btn", function () {
  // Make an AJAX request to the MainMenu endpoint
  $.ajax({
    url: "/choose-portrait",
    type: "GET",
    success: function (response) {
      chosenProfession = characterData.profession;

      $("#choose-portrait-container").show();
      $("#choose-portrait-container").html(response);

      $("#choose-profession-container").hide();

      characterData.profession = chosenProfession;
    },
    error: function (error) {
      console.log(error);
    },
  });
});