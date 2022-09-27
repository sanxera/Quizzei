import React from 'react';
import 'antd/dist/antd.min.css';
import 'react-toastify/dist/ReactToastify.css';
import { BrowserRouter as Router } from 'react-router-dom';
import { RoutesList } from './routes/routes';
import { Provider } from 'react-redux'
import store from './models/store'

import { ToastContainer } from 'react-toastify';

import './App.less'

const App = () => {
  return (
    <>
      <Provider store={store}>
        <Router>
          <RoutesList />
        </Router>
      </Provider>

      <ToastContainer />
    </>
  );
}

export default App;
