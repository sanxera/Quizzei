import React from 'react';
import { Result, Button } from 'antd';
import { Route, Routes, useNavigate } from 'react-router-dom';
import Signin from '../pages/Session/Login/index';
import ProtectedRoutes from './protectedRoutes';
import Register from '../pages/Session/Register/index';
import LayoutWrapper from '../components/Layout/Layout';
import List from '../pages/Quiz/List';
// import CreateQuiz from '../pages/Quiz/Create';

export const RoutesList = () => {
  const navigate = useNavigate();
  return (
    <Routes>
      <Route path="/" element={<Signin navigate={navigate} />} />
      <Route path="/register" element={<Register />} />
      <Route path="/recovery-password" element={<div>Recuperar senha</div>} />
      <Route element={< ProtectedRoutes />}>
        <Route path="/quiz" element={
          <LayoutWrapper navigate={navigate}>
            <List />
          </LayoutWrapper>
        }
        />
      </Route >

      <Route path="*" element={
        <Result
          status="404"
          title="404"
          subTitle="Deculpe, esta pagina nao existe."
          extra={<Button type="primary">Voltar a página inicial</Button>}
        />
      } />
    </Routes >
  )
}
