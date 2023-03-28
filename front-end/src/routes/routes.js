import React from 'react';
import { Result, Button } from 'antd';
import { Route, Routes, useNavigate } from 'react-router-dom';
import Signin from '../pages/Session/Login/index';
import ProtectedRoutes from './protectedRoutes';
import Register from '../pages/Session/Register/index';
import LayoutWrapper from '../components/Layout/Layout';
import routes from './router.config';

export const RoutesList = () => {
  const navigate = useNavigate();
  return (

    <Routes>
      <Route path="/" element={<Signin />} />
      <Route path="/register" element={<Register navigate={navigate} />} />
      <Route path="/recovery-password" element={<div>Recuperar senha</div>} />
      <Route element={<ProtectedRoutes />}>
        {routes.map((route, index) =>
          <Route key={`route${index}`} path={route.path} element={
            <LayoutWrapper>
              {route.element}
            </LayoutWrapper >
          } />
        )}
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
    </Routes>
  )
}
