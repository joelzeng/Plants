<template>
  <v-flex>
    <div v-if="!isOverSixHours">
      <h2>{{ waterStatus }}</h2>
    </div>
    <div class="need-water" v-else>
      <h2>Really Thirsty!</h2>
    </div>
    <img v-if="isWatering" class="plant-vase-img" src="../assets/flower_water.png" >
    <img v-else-if="!needsWater" class="plant-vase-img" src="../assets/flower_alive.png">
    <img v-else class="plant-vase-img" src="../assets/flower_dead.png">
    <img class="plant-vase-img" src="../assets/vase.png">
    <div>
      <v-btn :disabled="justWatered != null" v-if="!isWatering" color="primary" dark @click="waterFlower">Water</v-btn>
      <v-btn v-if="isWatering" color="red" @click="cancelWatering">Cancel</v-btn>
    </div>
  </v-flex>
</template>

<script>
import * as PlantApi from '@/api/PlantApi'

var ONE_HOUR = 60 * 60 * 1000
var SIX_HOURS = 6 * ONE_HOUR

export default {
  props: {
    id: {
      type: String
    },
    lastTimeWatered: {
      type: String
    },
    waterLevel: {
      type: Number
    }
  },
  data () {
    return {
      watering: null,
      justWatered: null
    }
  },
  computed: {
    waterStatus () {
      if (this.watering) {
        return 'Watering Plant'
      }
      return this.needsWater ? 'Needs Water' : 'Happy Plant'
    },
    needsWater () {
      const now = new Date()
      const wateredTime = new Date(this.lastTimeWatered)
      return now - wateredTime > ONE_HOUR
    },
    isWatering () {
      return this.watering != null
    },
    isOverSixHours () {
      const now = new Date()
      const wateredTime = new Date(this.lastTimeWatered)
      return now - wateredTime > SIX_HOURS
    }
  },
  methods: {
    waterFlower () {
      if (this.needsWater) {
        this.watering = setTimeout(() => {
          this.updateWateringPlant()
        }, 10000)
      }
    },
    async updateWateringPlant () {
      try {
        const newPlant = await PlantApi.waterPlant(this.id)
        this.$emit('updatePlant', newPlant)
        this.disableWaterButton()
      } catch (err) {
        console.log(err)
      } finally {
        this.cancelWatering()
      }
    },
    cancelWatering () {
      clearTimeout(this.watering)
      this.watering = null
    },
    disableWaterButton () {
      this.justWatered = setTimeout(() => {
        clearTimeout(this.justWatered)
        this.justWatered = null
      }, 30000)
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
