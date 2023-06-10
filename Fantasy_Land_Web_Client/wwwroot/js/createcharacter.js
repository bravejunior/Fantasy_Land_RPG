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

// Make an AJAX request to the CreateCharacter endpoint

// $.ajax({
//   url: "/choose-profession",
//   type: "GET",
//   success: function (response) {
//     console.log(response);
//     $("#choose-profession-container").html(response);
//   },
//   error: function (error) {
//     console.log(error);
//   },
// });

$.ajax({
  url: "/choose-profession",
  type: "POST",
  data: {
    professions: window.characterData.professions,
  },
  success: function (response) {
    $("#choose-profession-container").html(response);
  },
  error: function (error) {
    console.log(error);
  },
});
