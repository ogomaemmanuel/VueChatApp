import axios from "axios"
import router from "../../routers/routes"
const state = {
  auth: {}
}
const mutations = {
  SET_AUTH (state, newAuth) {
    state.auth = newAuth
  }
}
const getters = {
  auth: state => state.auth
}
const actions = {
  login (store, userCredetials) {
    axios.post(`/api/accounts/login`, userCredetials).then(({ data }) => {
      store.commit("SET_AUTH", data)
      router.push("/home")
    })
  },
  register (store, userDetails) {
    axios.post(`/api/accounts/register`, userDetails).then(({ data }) => {
      store.commit("SET_AUTH", data)
      router.push("/")
    })
  }
}

export default {
  state,
  mutations,
  actions,
  getters
}
