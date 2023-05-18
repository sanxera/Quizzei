import React, { useState } from 'react';
import { Col, Modal, Row, Typography, Button as ButtonAntd, Progress } from 'antd';
import { Smiley, SmileyXEyes, SmileySad, SmileyMeh, SmileyWink, CheckCircle, XCircle, Check, X, Circle } from 'phosphor-react'
import { Button } from '../../components/Button';

import './index.less';
import { ratingQuiz } from '../../services/quiz';

const { Text, Title } = Typography;

const feedBackButtons = [
  {
    value: 1,
    icon: <SmileyXEyes size={50} color="yellow" />,
  },
  {
    value: 2,
    icon: <SmileySad size={50} color="yellow" />,
  },
  {
    value: 3,
    icon: <SmileyMeh size={50} color="yellow" />,
  },
  {
    value: 4,
    icon: <Smiley size={50} color="yellow" />,
  },
  {
    value: 5,
    icon: <SmileyWink size={50} color="yellow" />,
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
      className="finishedModal"
      visible={visible}
      
      width={550}
      bodyStyle={{ height: '90%' }}
      closable={false}
      footer={null}
      destroyOnClose
    >
      <Row type="flex" justify='center' gutter={30}>
        <Col>
          <Title className='text-modal' level={4} strong>Quiz Finalizado!</Title>
        </Col>
        <Col span={24}>
          <ButtonAntd type='primary'>TESTE</ButtonAntd>
          <Button
            className="btn-finished-quiz"
            title="Voltar para tela de quizzes"
            onClick={onFinished}
          />
        </Col>

        <Col className='col-container' span={24}>
          <Text className='text-modal'>Precisão</Text>
          <Progress
            type='line'
            percent={percent}
            success={{ percent: 50 }}
          />
        </Col>

        <Col className='col-container rate-quiz' span={24}>
          <Text className='text-modal' strong>Avaliar quiz:</Text>
          <div style={{ display: 'flex', justifyContent: 'center' }}>
            {feedBackButtons.map(item => (
              <ButtonAntd className='btn-rate-quiz' shape='circle' type='link' style={{ marginRight: 15 }} icon={item.icon} onClick={() => setRating(item.value)} />
            ))}
          </div>
        </Col>

        <Col span={24}>
          <Text className='text-modal' style={{ fontSize: 15 }} strong>Performace</Text>
        </Col>

        <Col className='col-container performance-left' span={10}>
          <Row type="flex" justify='center' gutter={10}>
            <Col>
              <CheckCircle color="lime" size={70} />
            </Col>
            <Col style={{ display: 'flex', flexDirection: 'column', textAlign: 'center', fontSize: 25, lineHeight: 1, justifyContent: 'center' }}>
              <Text className='text-modal' strong>1</Text>
              <Text className='text-modal' strong>Correta(s)</Text>
            </Col>
          </Row>
        </Col>

        <Col className='col-container performance-right' span={10}>
          <Row type="flex" justify='center' >
            <Col>
              <XCircle color="red" size={70} />
            </Col>
            <Col style={{ display: 'flex', flexDirection: 'column', textAlign: 'center', fontSize: 25, lineHeight: 1, justifyContent: 'center' }}>
              <Text className='text-modal' strong>1</Text>
              <Text className='text-modal' strong>Incorreta(s)</Text>
            </Col>
          </Row>
        </Col>

        <Col span={24}>
          <Text className='text-modal' style={{ fontSize: 15 }} strong>Sumário</Text>
        </Col>

        <Col className='col-container' span={24}>
          <Row>
            <Col style={{ color: '#000', backgroundColor: '#ffff', minHeight: 50, borderLeft: '10px solid lime', borderRadius: 5, padding: 10, marginBottom: 20 }} span={24}>
              1. QUESTAO QUE ACERTOU

              <Row className="summary-row">
                <Col span={24}>
                  <Check color="lime" /> 1. Opção 1
                </Col>
                <Col span={24}>
                  <Circle color="#7d7d7d" /> 2. Opção 2
                </Col>
                <Col span={24}>
                  <Circle color="#7d7d7d" /> 3. Opção 3
                </Col>
              </Row>
            </Col>
            <Col style={{ color: '#000', backgroundColor: '#ffff', minHeight: 50, borderLeft: '10px solid red', borderRadius: 5, padding: 10 }} span={24}>
              2. QUESTAO QUE ERROU

              <Row className="summary-row">
                <Col span={24}>
                  <Circle color="#7d7d7d" /> 1. Opção 1
                </Col>
                <Col span={24}>
                  <X color="red" /> 2. Opção 2
                </Col>
                <Col span={24}>
                  <Circle color="#7d7d7d" /> 3. Opção 3
                </Col>
              </Row>
            </Col>
          </Row>
        </Col>
      </Row>

    </Modal>
  )
}