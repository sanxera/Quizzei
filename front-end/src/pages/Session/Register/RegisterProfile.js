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
          <CardWrapper
            logo="https://img.freepik.com/free-vector/employees-cv-candidates-resume-corporate-workers-students-id-isolate-flat-design-element-job-applications-avatars-personal-information_335657-2605.jpg?w=2000"
            title="USUÁRIO PADRÃO"
            onClick={() => onSelect(1)} />
        </Col>
        <Col>
          <CardWrapper
            logo="https://thumbs.dreamstime.com/b/home-education-online-e-learning-quarantine-students-face-masks-watch-lecture-given-teacher-computer-monitor-study-187995042.jpg"
            title="INSTITUIÇÃO DE ENSINO"
            onClick={() => onSelect(2)} />
        </Col>
        <Col>
          <CardWrapper
            logo="https://img.freepik.com/free-vector/hospital-receptionist-pointing-man-without-mask-nurse-patient-quarantine-flat-vector-illustration-medicine-pandemic_74855-8427.jpg?w=2000"
            title="PERFIL DO GOVERNO"
            onClick={() => onSelect(3)} />
        </Col>
      </Row>
    </div>
  )
}

export default RegisterProfile;