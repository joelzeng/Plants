<template>
  <div>
    <span :key="item.id" v-for="item in plants">
        {{ item }}
    </span>
  </div>
</template>

<script>
import * as PlantApi from '../api/PlantApi'

export default {
  data () {
    return {
      plants: []
    }
  },
  async mounted () {
    try {
      // const data = await this.$axios.get('https://localhost:5001/api/plant')
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
h1, h2 {
  font-weight: normal;
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
