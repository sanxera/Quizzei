import React from 'react';
import { Row, Col, Typography } from 'antd'
import FormComponent from './Form';

const { Title } = Typography;

const Signin = ({ navigate }) => {
  return (
    <Row
      style={{ height: '100%' }}
    >
      <Col span={16}>
        <div style={{ height: '100%', backgroundColor: '#6DA7EC' }} />
      </Col>
      <Col style={{ marginTop: 150, display: 'flex', justifyContent: 'center' }} span={8}>
        <div style={{ width: '23rem' }}>
          <Title style={{ textAlign: 'center', marginBottom: 50 }} level={2} >Quizzei</Title>
          <FormComponent navigate={navigate} />
        </div>
      </Col>
    </Row >
  )
}

export default Signin;