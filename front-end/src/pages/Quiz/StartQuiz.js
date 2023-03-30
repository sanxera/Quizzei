import React, { useState } from 'react';
import { connect } from 'react-redux';
import { Divider, Row, Col, Typography, Modal, Alert } from 'antd';
import {
  UserOutlined,
  FileSearchOutlined
} from '@ant-design/icons';
import { Button } from '../../components/Button';
import { InputWrapper } from '../../components/InputWrapper';
import { listQuestions, startQuiz } from '../../services/quiz';
import { notification } from '../../utils/notification';
import { DEFAULT_THEME } from '../../utils/constant';

import styles from './styles.less';

const { Title, Text } = Typography;

const StartQuiz = ({ navigate, visible, rowData, onClose, dispatch }) => {
  const [password, setPassword] = useState('');

  if (!visible || !rowData) return <div />;

  async function onClickStartQuiz() {
    const { quizInfoUuid } = rowData;
    if (!quizInfoUuid) return;

    const { quizProcessCreatedUuid } = await startQuiz({ quizInfoUuid, password });
    if (!quizProcessCreatedUuid) return notification({ status: 'error', position: 'bottom-center', message: 'Senha incorreta' });

    const { questions } = await listQuestions(quizInfoUuid);

    await dispatch({
      type: 'INIT_QUIZ',
      data: {
        quizProcessUuid: quizProcessCreatedUuid,
        quizInfoUuid,
        questions
      },
    });

    await onClose();
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
          <img alt="example" style={{ width: '100%', height: 250, borderRadius: 10 }} src={rowData?.imageUrl || DEFAULT_THEME} />
        </Col>

        <Col span={24} style={{ display: 'flex', justifyContent: 'center' }} >
          <Title style={{ color: '#FFFFFF' }} level={5}>{rowData.title}</Title>
        </Col>


        <Col span={24}>
          <Text style={{ color: '#FFFFFF' }}>{rowData.description}</Text>
        </Col>

        {rowData.permissionType && [2, 3].includes(rowData.permissionType) && (
          <div>
            <Divider />

            <Alert message="Aviso: O quiz que está tendo iniciar possui senha. Digite a senha para continuar." type="warning" showIcon />
            <InputWrapper type="password" style={{ marginTop: 10, opacity: 0.9 }} placeholder="Digite a senha" onChange={e => setPassword(e.target.value)} />
          </div>
        )}
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