import React from 'react';
import { Row, Col, Button, Typography } from 'antd';
import CardWrapper from '../../../components/CardWrapper';
import Container from '../../../components/Container';

import './index.css'

const { Title } = Typography;

const RegisterProfile = ({ onSelect }) => {
  return (
    <Container style={{ backgroundImage: 'linear-gradient(#6DA7EC, #FFFF)', padding: '10px 10px 0px 10px' }}>
      <div className='header'>
        <Title level={2}>Quizzei</Title>
        <Button size='large' shape='round' ghost>LOGIN</Button>
      </div>
      <div className='main'>
        <Title style={{ color: 'white' }} level={2}>Quem é voce?</Title>
        <Row gutter={50} justify='center'>
          <Col>
            <CardWrapper logo="https://cf.quizizz.com/img/signup/occupation_icons/personal_icon_v2.png" title="USUÁRIO PADRÃO" onClickCard={() => onSelect(1)} />
          </Col>
          <Col>
            <CardWrapper logo="https://cf.quizizz.com/img/signup/occupation_icons/school_icon_v2.png" title="INSTITUIÇÃO DE ENSINO" onClickCard={() => onSelect(2)} />
          </Col>
          <Col>
            <CardWrapper  logo="https://cf.quizizz.com/img/signup/occupation_icons/office_icon_v2.png" title="PERFIL DO GOVERNO" onClickCard={() => onSelect(3)} />
          </Col>
        </Row>
      </div>
    </Container>
  )
}

export default RegisterProfile;