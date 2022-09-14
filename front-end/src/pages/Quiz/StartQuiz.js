import React from 'react';
import { Divider, Row, Col, Button, Typography, Modal } from 'antd';
import { connect } from 'react-redux';
import {
  UserOutlined,
  FileSearchOutlined
} from '@ant-design/icons';
import { listQuestions, startQuiz } from '../../services/quiz';

const { Title, Text } = Typography;

const StartQuiz = ({ navigate, visible, data, onClose, dispatch }) => {
  if (!visible || !data) return <div />;

  async function onClickStartQuiz() {
    const { quizInfoUuid } = data;
    if (!quizInfoUuid) return;
    const { quizProcessCreatedUuid } = await startQuiz(quizInfoUuid);
    const { questions } = await listQuestions(quizInfoUuid);

    await dispatch({
      type: 'INIT_QUIZ',
      data: {
        quizProcessCreatedUuid,
        questions
      },
    });

    await navigate('/quiz-answer')
  }

  return (
    <Modal
      onCancel={onClose}
      destroyOnClose
      closable={false}
      footer={[]}
      visible
    >
      <Row justify='center' style={{ width: '100%', padding: 0, margin: 0 }}>
        <Col span={24} style={{ marginBottom: 30, width: '100%' }}>
          <img alt="example" style={{ width: '100%' }} src='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg' />
        </Col>

        <Col span={24} style={{ display: 'flex', justifyContent: 'center' }} >
          <Title level={5}>{data.title}</Title>
        </Col>


        <Col span={24}>
          <Text>{data.description}</Text>
        </Col>

        <Divider />

        <Col span={12} style={{ marginTop: 30 }}>
          <div style={{ display: 'flex' }}>
            <div style={{ display: 'flex', marginRight: 50, alignItems: 'center' }}>
              <UserOutlined /> Luiz Eduardo
            </div>
            <div style={{ display: 'flex', alignItems: 'center' }}>
              <FileSearchOutlined /> 10
            </div>
          </div>
        </Col>

        <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}>
          <Button className='btn-main' type='primary' onClick={() => onClickStartQuiz()}>Iniciar Quiz</Button>
        </Col>
      </Row>
    </Modal>
  )
}

export default connect(state => ({ ...state }))(StartQuiz);