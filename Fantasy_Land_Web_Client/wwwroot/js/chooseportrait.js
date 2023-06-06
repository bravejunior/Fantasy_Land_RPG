var characterData = {
  profession: "",
  portrait_id: 0,
  attributes: {},
  name: "",
};

var selectedPortrait = null;
var currentPortraitContainer = null;
var slideIndex = 1;

showDivs(slideIndex);

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
    var PortraitId =
      currentPortraitContainer.getAttribute("data-portait-id").innerText;
    characterData.portrait_id = PortraitId;
  }
}

descriptionElement.getAttribute("data-description");
