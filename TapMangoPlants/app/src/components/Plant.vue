<template>
  <v-flex>
    <div v-if="!isOverSixHours">
      <h2>{{ waterStatus }}</h2>
    </div>
    <div class="need-water" v-else>
      <h2>Really Thirsty!</h2>
    </div>
    <img v-if="isWatering" class="plant-vase-img" src="../assets/flower_water.png" >
    <img v-else-if="waterLevel === 1" class="plant-vase-img" src="../assets/flower_alive.png">
    <img v-else class="plant-vase-img" src="../assets/flower_dead.png">
    <img class="plant-vase-img" src="../assets/vase.png">
    <div>
      <v-btn v-if="!isWatering" color="primary" dark @click="waterFlower">Water</v-btn>
      <v-btn v-if="isWatering" color="red" @click="cancelWatering">Cancel</v-btn>
    </div>
  </v-flex>
</template>

<script>

export default {
  props: {
    lastWateredTime: {
      type: String
    },
    waterLevel: {
      type: Number
    }
  },
  data () {
    return {
      watering: false
    }
  },
  computed: {
    waterStatus () {
      if (this.watering) {
        return 'Watering Plant'
      }
      return this.waterLevel > 0 ? 'Happy Plant' : 'Needs Water'
    },
    isWatering () {
      return this.waterLevel === 0 && this.watering
    },
    isOverSixHours () {
      // there is a bug for different dates but you get the gist
      if (this.waterLevel === 1) {
        return false
      }
      const now = new Date()
      const wateredTime = new Date(this.lastWateredTime)
      if (wateredTime.getDate() < now.getDate()) {
        return true
      }
      return now.getHours() - wateredTime.getHours() > 6
    }
  },
  methods: {
    waterFlower () {
      if (this.waterLevel === 0) {
        this.watering = true
        setTimeout(() => { this.watering = false }, 10000)
      }
    },
    cancelWatering () {
      this.watering = false
    }
  }
}
</script>

<style>
.plant-vase-img {
  width: 200px;
}
.need-water {
  background: orange
}
</style>
