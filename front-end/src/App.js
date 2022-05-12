import React from 'react';
import 'antd/dist/antd.min.css';
import 'react-toastify/dist/ReactToastify.css';
import { BrowserRouter as Router } from 'react-router-dom';
import { RoutesList } from './routes/routes';
import { Provider } from 'react-redux'
import store from './models/store'
import Container from './components/Container';

import { ToastContainer } from 'react-toastify';

import './App.less'

const App = () => {
  return (
    <>
      <Provider store={store}>
        <Container>
          <Router>
            <RoutesList />
          </Router>
        </Container>
      </Provider>

      <ToastContainer />
    </>
  );
}

export default App;
