import React, { useState } from 'react';
import { Row, Col, Typography } from 'antd'
import FormComponent from './Form';
import { getAuthority, setAuthority } from '../../../utils/auth';
import { login } from '../../../services/session';
import { ToastContainer, toast } from 'react-toastify';
const { Title } = Typography;

const Signin = ({ navigate }) => {
  async function onSubmit(values) {
    const response = await login(values);
    if (response && !response.logged) {
      toast.error("Email ou senha inválidos!", {
        position: "top-right",
        autoClose: 2000,
        theme: 'colored',
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        progress: undefined,
        // onClose: () => setToastVisible(false),
      })
      return;
    }

    await setAuthority(response);
    const authData = await getAuthority();
    if (authData) await navigate('/quiz');
  };

  return (
    <Row>
      <Col span={16}>
        <div style={{ height: '100%', backgroundColor: '#6DA7EC', borderRight: '0.5px solid' }} />
      </Col>
      <Col style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column', marginBottom: 150 }} span={8}>
        <Title style={{ textAlign: 'center', marginBottom: 50 }} level={2} >Quizzei</Title>
        <FormComponent onSubmit={onSubmit} />
      </Col>
    </Row>
  )
}

export default Signin;