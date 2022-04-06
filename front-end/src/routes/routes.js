import React from 'react';
import { Result, Button } from 'antd';
import { Route, Routes, useNavigate } from 'react-router-dom';
import Signin from '../pages/Session/Login/index';
import ProtectedRoutes from './protectedRoutes';
import Register from '../pages/Session/Register/index';

export const RoutesList = () => {
  const navigate = useNavigate();
  return (
    <Routes>
      <Route path="/" element={<Signin navigate={navigate} />} />
      <Route path="/register" element={<Register />} />
      <Route path="/recovery-password" element={<div>Recuperar senha</div>} />
      <Route element={<ProtectedRoutes />}>
        <Route path="/dashboard" element={<div>DASHBOARD</div>} />
      </Route>

      <Route path="*" element={
        <Result
          status="404"
          title="404"
          subTitle="Deculpe, esta pagina nao existe."
          extra={<Button type="primary">Voltar a página inicial</Button>}
        />
      } />
    </Routes>
  )
}
