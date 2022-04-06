
import 'antd/dist/antd.min.css';
import { BrowserRouter as Router } from 'react-router-dom';
import { RoutesList } from './routes/routes';

import './App.less'

function App() {
  return (
    <Router>
      <RoutesList />
    </Router>
  );
}

export default App;
