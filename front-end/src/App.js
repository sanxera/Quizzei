
import 'antd/dist/antd.css';
import { BrowserRouter as Router } from 'react-router-dom';
import { RoutesList } from './routes/routes';

import './App.css'

function App() {
  return (
    <div id="app">
      <Router>
        <RoutesList />
      </Router>
    </div>
  );
}

export default App;
