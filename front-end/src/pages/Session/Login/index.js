import React from 'react';
import { Row, Col, Typography } from 'antd'
import FormComponent from './Form';
import loginImage from '../../../image/login.jpg'
import { login } from '../../../services/session';
import LayoutWrapper from '../../../components/Layout/Layout';
import { notification } from '../../../utils/notification';

const { Title } = Typography;

const Signin = ({ navigate }) => {
  async function onSubmit(data) {
    if (!data || !data.email || !data.password) return notification({ status: 'error', message: 'Informe email e senha.' });

    const isLogged = await login(data);
    const status = isLogged ? 'success' : 'error';
    const position = isLogged ? 'bottom-center' : 'top-right';
    const message = isLogged ? 'Bem vindo!' : 'Email ou senha inválidos!';
    notification({ status, position, message });

    setTimeout(async () => {
      if (isLogged) {
        await navigate('/quiz');
        return;
      }
    }, 1000)
  };

  return (
    <LayoutWrapper hasHeader={false} hasFooter={false} style={{ backgroundColor: '#FFFF', }}>
      <Row>
        <Col span={16} style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
          <img alt="logo" src={loginImage} style={{ width: '90%', height: 'auto', marginBottom: 50 }} />
        </Col>
        <Col style={{ display: 'flex', alignItems: 'center', flexDirection: 'column', justifyContent: 'center', marginBottom: 70 }} span={8}>
          <Title style={{ textAlign: 'center', marginBottom: 50, color: '#06a7c3' }} level={2} >Quizzei</Title>
          <FormComponent onSubmit={onSubmit} />
        </Col>
      </Row>
    </LayoutWrapper>
  )
}

export default Signin;