import axios from 'axios'

export async function getPlants () {
  const { data } = await axios.get('https://localhost:5001/api/plant')
  return data
}
