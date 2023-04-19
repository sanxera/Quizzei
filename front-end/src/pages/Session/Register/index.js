import React from 'react';
import { Typography, Row, Col } from 'antd';
import loginImage from '../../../image/login.png'
import FormComponent from './Form';

const { Title } = Typography;


const Register = ({ navigate }) => {
  return (
    <Row>
      <Col span={16} style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
        <img
          alt="logo"
          src={loginImage}
          style={{ width: '100%', height: '100vh' }} />
      </Col>
      <Col style={{ display: 'flex', alignItems: 'center', flexDirection: 'column', justifyContent: 'center' }} span={8}>
        <Title style={{ textAlign: 'center', marginBottom: 25, color: '#47a7f0' }} level={2} >Cadastro</Title>
        <FormComponent navigate={navigate} />
      </Col>
    </Row>
  )
}

export default Register;