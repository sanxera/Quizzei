import List from '../pages/Quiz/List';
import Perfil from '../pages/Perfil';
import UserList from '../pages/User/List';
import Quiz from '../pages/QuizAnswer/Quiz';

const routes = [
  { path: '/quiz', element: <List /> },
  { path: '/user', element: <UserList /> },
  { path: '/quiz-answer', element: <Quiz /> },
  { path: '/perfil', element: <Perfil /> },
];

export default routes;