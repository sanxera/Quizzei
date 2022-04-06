import React from 'react';
import { Row, Col, Typography } from 'antd'
import FormComponent from './Form';
import Container from '../../../components/Container';

const { Title } = Typography;

const Signin = ({ navigate }) => {
  return (
    <Container>
      <Row style={{ height: '100%' }}>
        <Col span={16}>
          <div style={{ height: '100%', backgroundImage: 'linear-gradient(#6DA7EC, #FFFF)', borderRight: '0.5px solid' }} />
        </Col>
        <Col style={{ marginTop: 150, display: 'flex', justifyContent: 'center' }} span={8}>
          <div style={{ width: '23rem' }}>
            <Title style={{ textAlign: 'center', marginBottom: 50 }} level={2} >Quizzei</Title>
            <FormComponent navigate={navigate} />
          </div>
        </Col>
      </Row>
    </Container >
  )
}

export default Signin;