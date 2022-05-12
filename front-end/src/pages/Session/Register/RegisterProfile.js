import React from 'react';
import { Row, Col, Typography } from 'antd';
import CardWrapper from '../../../components/CardWrapper';

import './index.css'

const { Title } = Typography;

const RegisterProfile = ({ onSelect }) => {
  return (
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
          <CardWrapper logo="https://cf.quizizz.com/img/signup/occupation_icons/office_icon_v2.png" title="PERFIL DO GOVERNO" onClickCard={() => onSelect(3)} />
        </Col>
      </Row>
    </div>
  )
}

export default RegisterProfile;