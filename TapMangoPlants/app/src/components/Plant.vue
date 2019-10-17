<template>
  <v-flex>
    <img class="plant-vase-img" src="../assets/vase.png">
  </v-flex>
</template>

<script>

export default {
  props: {
    lastWateredTime: {
      type: String
    },
    waterlevel: {
      type: Number
    }
  },
  data () {
    return {
      msg: 'afsasdf'
    }
  }
}
</script>

<style>
.plant-vase-img {
  width: 200px;
}
</style>
