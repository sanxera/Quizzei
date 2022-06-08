import React from 'react';
import { Typography, Button, Row, Col } from 'antd';
import LayoutWrapper from '../../../components/Layout/Layout';
import loginImage from '../../../image/login.jpg'
import FormComponent from './Form';

const { Title } = Typography;


const Register = ({ navigate }) => {
  return (
    <LayoutWrapper
      hasHeader
      header={
        <div style={{ display: 'flex', justifyContent: 'end', padding: 10 }}>
          <Button type="link" style={{ borderBottom: '1px solid' }} onClick={() => navigate('/')}>
            <Title level={3} style={{ color: '#06a7c3' }}>Login</Title>
          </Button>
        </div>
      }
      hasFooter={false}
      style={{ backgroundColor: '#FFFF', }}
    >
      <Row>
        <Col span={16} style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
          <img
            alt="logo"
            src={loginImage}
            style={{ width: '90%', height: 'auto', marginBottom: 50 }} />
        </Col>
        <Col style={{ display: 'flex', alignItems: 'center', flexDirection: 'column', justifyContent: 'center', marginBottom: 70 }} span={8}>
          <Title style={{ textAlign: 'center', marginBottom: 50, color: '#06a7c3' }} level={2} >Cadastro</Title>
          <FormComponent navigate={navigate} />
        </Col>
      </Row>
    </LayoutWrapper>
  )
}

export default Register;