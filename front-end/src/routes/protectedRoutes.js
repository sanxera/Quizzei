import React from 'react';
import { Outlet, Navigate } from 'react-router-dom';
import { getAuthority } from '../utils/auth';

const ProtectedRoutes = () => {
  const isAuth = getAuthority();
  return isAuth ? <Outlet /> : <Navigate to="/" />;
}

export default ProtectedRoutes;