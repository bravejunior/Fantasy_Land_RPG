const { createApp } = Vue;

createApp({
  data() {
    return {
      imageArray: [
        "npc_baron.png",
        "npc_captain.png",
        "npc_female_soldier.png",
        "npc_prioress.png",
        "npc_prophet.png",
      ],
    };
  },
  methods: {
    handleFileUpload() {},
  },

  computed: {
    getRandomImage() {
      console.log(max);
      let max = imageArray.length;
      const random = Math.floor(Math.random() * max) + 1;

      return imageArray[random];
    },
  },
}).mount("#index-container");
