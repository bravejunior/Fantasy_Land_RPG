$(document).ready(function () {
  const { createApp } = Vue;

  createApp({
    data() {
      return {
        capabilities: {},
        minCapabilityValue: 0,
        maxCapabilityValue: 10,
        totalPoints: 10,
      };
    },
    mounted() {
      var capabilityElements =
        document.getElementsByClassName("capability-name");
      console.log(capabilityElements);
      var capabilityName = "";

      for (var i = 0; i < capabilityElements.length; i++) {
        var capabilityElement = capabilityElements[i];
        capabilityName = capabilityElement.getAttribute("data-capability-name");
        console.log(capabilityName);
        this.capabilities[capabilityName] = 0;
      }

      //   this.capabilitys = JSON.parse(@Html.Raw(Json.Serialize(Model)));
    },
    methods: {
      decreaseValue(capabilityName) {
        if (this.capabilities[capabilityName] > this.minCapabilityValue) {
          this.capabilities[capabilityName]--;
          this.totalPoints++;
        }
      },
      increaseValue(capabilityName) {
        if (
          this.capabilities[capabilityName] < this.maxCapabilityValue &&
          this.totalPoints > 0
        ) {
          this.capabilities[capabilityName]++;
          this.totalPoints--;
        }
      },
    },
  }).mount("#create-character-capability-container");

  $(document).on("click", "#next-attr-btn", function () {
    // Make an AJAX request to the MainMenu endpoint
    $.ajax({
      url: "/choose-capabilities",
      type: "POST",
      data: {
        capabilities: window.characterData.capabilities,
      },
      success: function (response) {
        $("#choose-capabilities-container").hide();
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

        $("#choose-capabilities-container").hide();
      },
      error: function (error) {
        console.log(error);
      },
    });
  });
});
