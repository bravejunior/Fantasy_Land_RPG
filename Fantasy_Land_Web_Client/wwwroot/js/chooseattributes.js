﻿$(document).ready(function () {
  const { createApp } = Vue;

  createApp({
    data() {
      return {
        attributes: {},
        minAttributeValue: 7,
        maxAttributeValue: 21,
        totalPoints: 20,
      };
    },
    mounted() {
      var attributeElements = document.getElementsByClassName("attribute-name");
      var attributeName = "";

      for (var i = 0; i < attributeElements.length; i++) {
        var attributeElement = attributeElements[i];
        attributeName = attributeElement.getAttribute("data-attribute-name");
        this.attributes[attributeName] = 10;
      }

      //   this.attributes = JSON.parse(@Html.Raw(Json.Serialize(Model)));
    },
    methods: {
      decreaseValue(attributeName) {
        if (this.attributes[attributeName] > this.minAttributeValue) {
          this.attributes[attributeName]--;
          this.totalPoints++;
        }
      },
      increaseValue(attributeName) {
        if (
          this.attributes[attributeName] < this.maxAttributeValue &&
          this.totalPoints > 0
        ) {
          this.attributes[attributeName]++;
          this.totalPoints--;
        }
      },
    },
  }).mount("#create-character-attribute-container");

  $(document).on("click", "#next-attr-btn", function () {
    // Make an AJAX request to the MainMenu endpoint
    $.ajax({
      url: "/choose-capabilities",
      type: "POST",
      data: {
        capabilities: window.characterData.capabilities,
      },
      success: function (response) {
        $("#choose-attributes-container").hide();
        $("#choose-capabilities-container").show();
        $("#choose-capabilities-container").html(response);
      },
      error: function (error) {
        console.log(error);
      },
    });
  });

  $(document).on("click", "#go-back-attr-btn", function () {
    // Make an AJAX request to the MainMenu endpoint
    $.ajax({
      url: "/choose-portrait",
      type: "GET",
      success: function (response) {
        $("#choose-portrait-container").show();
        $("#choose-portrait-container").html(response);

        $("#choose-attributes-container").hide();
      },
      error: function (error) {
        console.log(error);
      },
    });
  });
});
