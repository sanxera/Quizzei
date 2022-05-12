import React from 'react';
import { Row, Col } from 'antd'
import FormComponent from './Form';

const RegisterForm = ({ profileID }) => {
  return (
    <Row justify='center' align='center' style={{ backgroundColor: '#FFFF', width: '26rem', borderRadius: 30, height: '25rem' }}>
      <Col>
        <FormComponent profileID={profileID} />
      </Col>
    </Row>
  )
}

export default RegisterForm;