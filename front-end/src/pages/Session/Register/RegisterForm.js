import React from 'react';
import { Row, Col, Typography } from 'antd'
import Container from '../../../components/Container';
import FormComponent from './Form';

const { Title } = Typography;

const RegisterForm = ({ profileID }) => {
  return (
    <Container>
      <Row style={{ height: '100%' }}>
        <Col span={16}>
          <div style={{ height: '100%', backgroundImage: 'linear-gradient(#6DA7EC, #FFFF)', borderRight: '0.5px solid' }} />
        </Col>
        <Col style={{ marginTop: 150, display: 'flex', justifyContent: 'center' }} span={8}>
          <div style={{ width: '23rem' }}>
            <FormComponent profileID={profileID} />
          </div>
        </Col>
      </Row>
    </Container>
  )
}

export default RegisterForm;