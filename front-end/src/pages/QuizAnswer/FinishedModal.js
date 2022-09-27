import React from 'react';
import { Col, Modal, Rate, Row, Typography } from 'antd';
import { Button } from '../../components/Button';

import styles from './index.less';

const { Text, Title } = Typography;

export function FinishedModal({ visible, data, onClick }) {
  if (!visible) return <div />

  return (
    <Modal
      className={styles.finishedModal}
      visible={visible}
      width={400}
      // bodyStyle={{ minHeight: 500 }}
      closable={false}
      footer={null}
      destroyOnClose
    >
      <Row>
        <Col style={{ textAlign: 'center', marginBottom: 20 }} span={24}>
          <Title style={{ color: '#FFFFFF' }} level={4} strong>Quiz Finalizado!</Title>
        </Col>

        <Col span={24}>
          <Text style={{ color: '#FFFFFF' }} strong>Questões acertadas: </Text>
          {`${data.correctAnswers} / ${data.totalQuestions}`}
        </Col>

        <Col span={24}>
          <Text style={{ color: '#FFFFFF' }} strong>Avaliar quiz: </Text>
          <Rate style={{ marginLeft: 10 }} />
        </Col>

        <Col style={{ display: 'flex', justifyContent: 'center', marginTop: 30 }} span={24}>
          <Button
            title="Fechar"
            type="primary"
            onClick={onClick}
          />
        </Col>
      </Row>

    </Modal>
  )
}