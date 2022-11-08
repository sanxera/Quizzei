import List from '../pages/Quiz/List';
import Perfil from '../pages/Perfil';
import UserList from '../pages/User/List';
import Quiz from '../pages/QuizAnswer/Quiz';
import Dashboard from '../pages/Dashboard';

const routes = [
  { path: '/quiz', element: <List /> },
  { path: '/user', element: <UserList /> },
  { path: '/quiz-answer', element: <Quiz /> },
  { path: '/perfil', element: <Perfil /> },
  { path: '/dashboard', element: <Dashboard /> },
];

export default routes;