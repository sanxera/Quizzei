import React from 'react';
import { Divider, Row, Col, Button, Typography } from 'antd';

const { Title, Text } = Typography;

const StartQuiz = ({ visible, data, onClose }) => {
  if (!visible || !data) return <div />;

  return (
    <Row justify='center' style={{ padding: 30, height: '40%', borderRadius: 30, backgroundColor: '#F7F7F7', color: '#0000', marginTop: 150 }}>
      <Col span={24}>
        <Title level={5}>{data.title}</Title>
      </Col>

      <Col span={24}>
        <img alt="example" style={{ width: 200, height: 200 }} src={data.image} />
      </Col>

      <Divider />

      <Col span={24}>
        <Text>{data.description}</Text>
      </Col>

      <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 30 }}>
        <Button type='primary' shape='round'>Iniciar Quiz</Button>
      </Col>
    </Row>
  )
}

export default StartQuiz;