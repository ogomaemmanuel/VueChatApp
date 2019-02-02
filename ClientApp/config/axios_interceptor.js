import axios from 'axios'
import store from "../store/index"


axios.interceptors.request.use(function (config) {
  const token = store.getters.auth.accessToken

  if ( token) {
    config.headers.Authorization = `Bearer ${token}`
  }

  return config
}, function (err) {
  return Promise.reject(err)
})