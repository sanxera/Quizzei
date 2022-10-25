import { createStore } from 'redux';

function reducer(state = {}, action) {
  if (action.type === 'INIT_QUIZ') {
    return { ...state, data: action.data }
  }

  if (action.type === 'PERFIL') {
    return { ...state, data: action.data }
  }

  return state
}

const store = createStore(reducer)

export default store;