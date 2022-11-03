import React, { useState } from 'react';
import { Col, Modal, Row, Typography, Button as ButtonAntd, Progress, Divider } from 'antd';
import { Smiley, SmileyXEyes, SmileySad, SmileyMeh, SmileyWink } from 'phosphor-react'
import { Button } from '../../components/Button';

import styles from './index.less';
import { ratingQuiz } from '../../services/quiz';

const { Text, Title } = Typography;


const feedBackButtons = [
  {
    value: 1,
    icon: <SmileyXEyes size={25} />,
  },
  {
    value: 2,
    icon: <SmileySad size={25} />,
  },
  {
    value: 3,
    icon: <SmileyMeh size={25} />,
  },
  {
    value: 4,
    icon: <Smiley size={25} />,
  },
  {
    value: 5,
    icon: <SmileyWink size={25} />,
  },
]

export function FinishedModal({ visible, data, quizProcessUuid, onClick }) {
  const [rating, setRating] = useState(null);
  const percent = (data.correctAnswers * 100) / data.totalQuestions;
  if (!visible) return <div />

  async function onFinished() {
    if (rating && rating > 0) {
      await ratingQuiz(quizProcessUuid, rating);
    }

    onClick();
  }

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
      <Row justify='center'>
        <Col style={{ textAlign: 'center', marginBottom: 20 }} span={24}>
          <Title style={{ color: '#FFFFFF' }} level={4} strong>Quiz Finalizado!</Title>
          <Divider style={{ backgroundColor: '#FFFF' }} />
          <Progress type='circle' percent={percent}
            // status={percent < 50 ? 'exception' : 'success'} 
            success={{ percent: 50 }}
          />
        </Col>

        <Col style={{ textAlign: 'center' }} span={24}>
          <Text style={{ color: '#FFFFFF' }} strong>Questões acertadas: </Text>
          {`${data.correctAnswers} / ${data.totalQuestions}`}
        </Col>

        <Divider style={{ backgroundColor: '#FFFF' }} />

        <Col style={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', alignItems: 'center' }} span={24}>
          <Text style={{ color: '#FFFFFF', marginRight: 10 }} strong>Avaliar quiz:</Text>
          <div style={{ display: 'flex', marginTop: 15 }}>
            {feedBackButtons.map(item => (
              <ButtonAntd shape='circle' style={{ marginRight: 15 }} icon={item.icon} onClick={() => setRating(item.value)} />
            ))}
          </div>
        </Col>

        <Divider style={{ backgroundColor: '#FFFF' }} />

        <Col style={{ display: 'flex', justifyContent: 'center' }} span={24}>
          <Button
            title="Finalizar"
            type="primary"
            onClick={onFinished}
          />
        </Col>
      </Row>

    </Modal>
  )
}