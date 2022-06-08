import { createStore } from 'redux';

function reducer() {
  return {
    status: true
  }
}

export default createStore(reducer)