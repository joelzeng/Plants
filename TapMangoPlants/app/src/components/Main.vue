<template>
  <div>
    <h1>TapPlants</h1>
    <v-layout class="main">
      <v-flex :key="item.id" v-for="item in plants">
          <Plant :id="item.id"
                 :waterLevel="item.waterLevel"
                 :lastTimeWatered="item.lastTimeWatered"
                 @updatePlant="onUpdatePlant"/>
      </v-flex>
    </v-layout>
  </div>
</template>

<script>
import * as PlantApi from '@/api/PlantApi'
import Plant from '@/components/Plant'

export default {
  components: {
    Plant
  },
  data () {
    return {
      plants: []
    }
  },
  methods: {
    onUpdatePlant (newPlant) {
      var plant = this.plants.find(p => p.id === newPlant.id)
      plant.lastTimeWatered = newPlant.lastTimeWatered
    }
  },
  async mounted () {
    try {
      const data = await PlantApi.getPlants()
      this.$set(this, 'plants', data)
    } catch (err) {
      console.error(err)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.main {
  margin-top: 10vh;
}

ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
