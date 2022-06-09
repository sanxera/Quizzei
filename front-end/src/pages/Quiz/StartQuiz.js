import React from 'react';
import { Divider, Row, Col, Button, Typography } from 'antd';
import {
  InfoCircleOutlined,
  QuestionCircleOutlined,
  FileSearchOutlined
} from '@ant-design/icons';

const { Title, Text } = Typography;

const StartQuiz = ({ visible, data, onClose }) => {
  if (!visible || !data) return <div />;

  return (
    <Row justify='center' style={{ padding: 30, height: '40%', borderRadius: 30, backgroundColor: '#F7F7F7', color: '#0000', marginTop: 150 }}>
      <Col span={24} style={{ display: 'flex', justifyContent: 'center' }} >
        <Title level={5}>{data.title}</Title>
      </Col>

      <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 30, marginBottom: 30 }}>
        <img alt="example" style={{ width: 200, height: 200 }} src='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg' />
      </Col>

      <Divider />

      <Col span={24}>
        <Text>{data.description}</Text>
      </Col>

      <Col span={12} style={{ marginTop: 30 }}>
        <div style={{ display: 'flex', justifyContent: 'space-between' }}>
          <div style={{ display: 'flex' }}>
            <InfoCircleOutlined /> Luiz Eduardo
          </div>
          <div style={{ display: 'flex' }}>
            <InfoCircleOutlined /> Luiz Eduardo
          </div>
        </div>
      </Col>

      <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}>
        <Button className='btn-main' type='primary' shape='round'>Iniciar Quiz</Button>
      </Col>
    </Row>
  )
}

export default StartQuiz;