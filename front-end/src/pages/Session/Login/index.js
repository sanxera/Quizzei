import React from 'react';
import { connect } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Row, Col, Typography } from 'antd'
import FormComponent from './Form';
import { login } from '../../../services/session';
import { notification } from '../../../utils/notification';
import loginImage from '../../../image/LogoArt.png'

import './styles.css';

const { Title } = Typography;

const Signin = () => {
  const navigate = useNavigate();
  async function onSubmit(data) {
    if (!data || !data.email || !data.password) return notification({ status: 'error', message: 'Informe email e senha.' });

    const isLogged = await login(data);
    const notificationProps = {
      status: isLogged ? 'success' : 'error',
      position: isLogged ? 'bottom-center' : 'top-right',
      message: isLogged ? 'Bem vindo' : 'Email ou senha inválidos'
    };
    notification(notificationProps);

    if (isLogged) {
      await navigate('/quiz');
      return;
    }
  };

  return (
    <Row className='row-container' >
      <Col className='login-container' span={16}>
        <img className='logo' alt="logo" src={loginImage} />
      </Col>
      <Col className='login-container' span={8}>
        <Title className='login-title' level={2} >Quizzei</Title>
        <FormComponent onSubmit={onSubmit} />
      </Col>
    </Row>
  )
}

export default connect(state => ({ ...state }))(Signin);