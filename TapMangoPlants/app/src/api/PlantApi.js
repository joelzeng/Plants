import axios from 'axios'

export async function getPlants () {
  const { data } = await axios.post('https://localhost:5001/api/plant/GetAll')
  return data
}

export async function waterPlant(id) {
  const { data } = await axios.post('https://localhost:5001/api/plant/WaterPlant', { Id: id })
  return data
}