import React from 'react';
import { Result, Button } from 'antd';
import { Route, Routes, useNavigate } from 'react-router-dom';
import Signin from '../pages/Session/Login/index';
import ProtectedRoutes from './protectedRoutes';
import Register from '../pages/Session/Register/index';
import LayoutWrapper from '../components/Layout/Layout';
import List from '../pages/Quiz/List';
import UserList from '../pages/User/List';
import Quiz from '../pages/QuizAnswer/Quiz';

export const RoutesList = () => {
  const navigate = useNavigate(); // TODO colocar o navigate em um redux global 
  return (
    <Routes>
      <Route path="/" element={<Signin navigate={navigate} />} />
      <Route path="/register" element={<Register navigate={navigate} />} />
      <Route path="/recovery-password" element={<div>Recuperar senha</div>} />
      <Route element={< ProtectedRoutes />}>
        <Route path="/quiz" element={
          <LayoutWrapper navigate={navigate}>
            <List navigate={navigate} />
          </LayoutWrapper>
        }
        />
        <Route path="/user" element={
          <LayoutWrapper navigate={navigate}>
            <UserList />
          </LayoutWrapper>
        }
        />

        <Route path="/quiz-answer" element={
          <LayoutWrapper navigate={navigate}>
            <Quiz navigate={navigate} />
          </LayoutWrapper>
        }
        />
      </Route >

      <Route path="*" element={
        <div style={{ height: '100vh', width: '100%' }}>
          <Result
            status="404"
            title="404"
            subTitle="Desculpe, esta pagina nao existe."
            extra={<Button type="primary" onClick={() => navigate('/')}>Voltar a página inicial</Button>}
          />
        </div>
      } />
    </Routes >
  )
}
