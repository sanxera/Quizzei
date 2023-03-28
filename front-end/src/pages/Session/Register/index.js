import React from 'react';
import { Typography, Row, Col } from 'antd';
import LayoutWrapper from '../../../components/Layout/Layout';
import loginImage from '../../../image/LogoArt.png'
import FormComponent from './Form';

const { Title } = Typography;


const Register = ({ navigate }) => {
  return (
    <LayoutWrapper
      hasHeader={false}
      hasFooter={false}
      style={{ backgroundColor: '#FFFF', }}
    >
      <Row style={{ marginTop: 60 }} justify="center">
        <Col span={16} style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
          <img
            alt="logo"
            src={loginImage}
            style={{ width: '90%', height: 'auto', marginBottom: 50 }} />
        </Col>
        <Col style={{ display: 'flex', alignItems: 'center', flexDirection: 'column', marginTop: 20 }} span={8}>
          <Title style={{ textAlign: 'center', marginBottom: 50, color: '#47a7f0' }} level={2} >Cadastro</Title>
          <FormComponent navigate={navigate} />
        </Col>
      </Row>
    </LayoutWrapper>
  )
}

export default Register;