import React from 'react';
import { Divider, Row, Col, Button, Typography } from 'antd';

const { Title, Text } = Typography;

const StartQuiz = ({ visible, data, onClose }) => {
  if (!visible || !data) return <div />;

  return (
    <div style={{ display: 'flex', width: 300, backgroundColor: 'white', height: '100%' }}>
      <Divider type='vertical' style={{ height: '100%' }} />

      <Row gutter={32} justify='center' style={{ padding: 20 }}>
        <Col spam={24}>
          <Title level={3}>{data.title}</Title>
        </Col>
        <Divider />

        <Col style={{ marginBottom: 20 }} spam={24}>
          <img alt="example" style={{ width: 150, height: 150 }} src={data.image} />
        </Col>

        <Divider />

        <Col span={24}>
          <Text>{data.description}</Text>
        </Col>

        <Col span={24} style={{ display: 'flex', justifyContent: 'center' }}>
          <Button type='primary' shape='round'>Iniciar Quiz</Button>
        </Col>
      </Row>
    </div>
  )
}

export default StartQuiz;