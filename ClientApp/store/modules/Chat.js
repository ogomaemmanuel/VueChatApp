import axios from "axios"
const state = {
  usersToChatWith: [],
  messageSent: false,
  chatMessages: [],
  gifs:null
}
const mutations = {
  ADD_USER_TO_CHAT_LIST (state, newUser) {
    if (!state.usersToChatWith.find(user => user.id == newUser.id)) {
      state.usersToChatWith.push(newUser)
    }
  },
  REMOVE_USER_FROM_CHAT_LIST (state, userId) {
    state.usersToChatWith = state.usersToChatWith.filter(
      userToChatWith => userToChatWith.id !== userId
    )
  },
  SET_MESSAGE_HAS_BEEN_SENT (state, status) {
    state.messageSent = status
  },
  ADD_CHAT_MESSAGE (state, newMessage) {
    state.chatMessages.push(newMessage)
  },
  ADD_GIFS (state,gifs){
    state.gifs=gifs
  }
}
const getters = {
  usersToChatWith: state => state.usersToChatWith,
  chatMessages: state => state.chatMessages,
  gifs:state=>state.gifs,
}
const actions = {
  addUserToChatlist ({ commit }, newUser) {
    commit("ADD_USER_TO_CHAT_LIST", newUser)
  },
  removeUserFromChatlist ({ commit }, userId) {
    commit("REMOVE_USER_FROM_CHAT_LIST", userId)
  },
  sendChatMessage ({ dispatch, commit }, outGoingMessage) {
    axios.post(`/api/chats`, outGoingMessage).then(({ data }) => {
      commit("SET_MESSAGE_HAS_BEEN_SENT")
      dispatch("addChatMessage", data)
    })
  },

  sendChatVideoMessage ({ dispatch, commit }, outGoingMessage) {
    axios.post(`/api/chats/video-chat`, outGoingMessage).then(({ data }) => {
      commit("SET_MESSAGE_HAS_BEEN_SENT")
      dispatch("addChatMessage", data)
    })
  },

  
  addChatMessage ({ commit }, newChatMessage) {
    commit("ADD_CHAT_MESSAGE", newChatMessage)
  },

  getGifs ({commit }){
    axios.get(`api/chats/gifs`).then(({data})=>{
      let gifList=data.results.flatMap(result=>result.media).map(x=>x.mediumgif)
      commit("ADD_GIFS",gifList)
    })
  },
  searchGifs ({commit },{q}){
    axios.get(`api/chats/search`,{
      params:{
         q
      }
    }).then(({data})=>{
      let gifList=data.results.flatMap(result=>result.media).map(x=>x.mediumgif)
      commit("ADD_GIFS",gifList)
    })
  }
}
export default {
  state,
  mutations,
  getters,
  actions
}
