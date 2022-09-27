import React from 'react';
import { connect } from 'react-redux';
import { Divider, Row, Col, Typography, Modal } from 'antd';
import {
  UserOutlined,
  FileSearchOutlined
} from '@ant-design/icons';
import { Button } from '../../components/Button';
import { listQuestions, startQuiz } from '../../services/quiz';

import styles from './styles.less';

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

    await navigate('/quiz-answer');
  }

  return (
    <Modal
      className={styles.startQuizModal}
      onCancel={onClose}
      destroyOnClose
      closable={false}
      footer={null}
      visible
      width={400}
      bodyStyle={{ margin: 0, padding: 0 }}
    >
      <Row justify='center' style={{ width: '100%', padding: 20, textAlign: 'center' }}>
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

        <Col span={12}>
          <div style={{ display: 'flex', justifyContent: 'space-between' }}>
            <div style={{ display: 'flex', alignItems: 'center' }}>
              <UserOutlined /> Luiz Eduardo
            </div>
            <div style={{ display: 'flex', alignItems: 'center' }}>
              <FileSearchOutlined /> 10
            </div>
          </div>
        </Col>

        <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 30 }}>
          <Button title="Iniciar quiz" onClick={() => onClickStartQuiz()} />
        </Col>
      </Row>
    </Modal>
  )
}

export default connect(state => ({ ...state }))(StartQuiz);