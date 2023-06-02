import React, { useState } from 'react';
import { CheckCircleOutlined, CloseCircleOutlined, FrownOutlined, MehOutlined, SmileOutlined } from '@ant-design/icons';
import { Col, Modal, Row, Typography, Progress, Divider, Rate } from 'antd';
import { Check, X, Circle } from 'phosphor-react'
import { Button } from '../../components/Button';
import { ratingQuiz } from '../../services/quiz';

import './index.less';
import { getReportPerQuizProcess } from '../../services/report';

const { Text, Title } = Typography;

const customIcons = {
  1: <FrownOutlined />,
  2: <FrownOutlined />,
  3: <MehOutlined />,
  4: <SmileOutlined />,
  5: <SmileOutlined />,
};

export function FinishedModal({ visible, data, quizProcessUuid, onClick }) {
  const [rating, setRating] = useState(0);
  const [showSummary, setShowSummary] = useState(false);
  const [summary, setSummary] = useState({});
  const percent = (data.correctAnswers * 100) / data.totalQuestions;
  if (!visible) return <div />

  async function onFinished() {
    if (rating && rating > 0) {
      await ratingQuiz(quizProcessUuid, rating);
    }

    onClick();
  }


  async function loadingSummary() {
    const summary = await getReportPerQuizProcess(quizProcessUuid);
    console.log("🚀  ~ file: FinishedModal.js:57 ~ loadingSummary ~ summary:", summary)
    setSummary(summary);
    setShowSummary(true);
  }

  return (
    <Modal
      className="finishedModal"
      visible={visible}
      centered
      width={600}
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
          <Button
            className="btn-finished-quiz"
            title="Finalizar revisão & Voltar para tela de quizzes"
            onClick={onFinished}
          />
        </Col>

        <Col className='col-container' span={24}>
          <Text className='text-modal'>Precisão</Text>
          <Progress
            type='line'
            percent={percent}
            // success={{ percent: 50 }}
          />
        </Col>

        <Col className='col-container rate-quiz' span={24}>
          <Text className='text-modal' strong>Avaliar quiz:</Text>
          <div style={{ display: 'flex', justifyContent: 'center' }}>
            <Rate
              style={{ fontSize: 50 }}
              defaultValue={rating}
              character={({ index }) => customIcons[index + 1]}
              onChange={value => setRating(value)}
            />
          </div>
        </Col>

        <Col span={24}>
          <Text className='text-modal' style={{ fontSize: 15 }} strong>Performace (Total: {data.totalQuestions} questões)</Text>
        </Col>

        <Col className='col-container performance-left' span={9}>
          <Row type="flex" justify='center' gutter={10}>
            <Col>
              <CloseCircleOutlined className='performance-icon incorrect' />
            </Col>
            <Col style={{ display: 'flex', flexDirection: 'column', textAlign: 'center', fontSize: 15, lineHeight: 1, justifyContent: 'center' }}>
              <Text className='text-modal' strong>{data.totalQuestions - data.correctAnswers}</Text>
              <Text className='text-modal' strong>Incorreta(s)</Text>
            </Col>
          </Row>
        </Col>

        <Col className='col-container performance-right' span={9}>
          <Row type="flex" justify='center' gutter={10}>
            <Col>
              <CheckCircleOutlined className='performance-icon correct' />
            </Col>
            <Col style={{ display: 'flex', flexDirection: 'column', textAlign: 'center', fontSize: 15, lineHeight: 1, justifyContent: 'center' }}>
              <Text className='text-modal' strong>{data.correctAnswers}</Text>
              <Text className='text-modal' strong>Correta(s)</Text>
            </Col>
          </Row>
        </Col>

        <Col span={24} style={{ marginTop: 15 }}>
          <Button
            className="btn-finished-quiz"
            title="Ver sumário"
            onClick={loadingSummary}
          />
        </Col>

        {showSummary && (
          <Col className='col-container' span={24}>
            {summary.questions.map((question, index) => (
              <Row>
                <Col style={{ color: '#000', backgroundColor: '#ffff', minHeight: 50, borderLeft: `10px solid ${question.userAnswerIsCorrect ? 'lime' : 'red'}`, borderRadius: 5, padding: 10, marginBottom: 20 }} span={24}>
                  {index + 1}. {question.description}

                  <Divider />

                  <Row className="summary-row">
                    {question.options.map((option, index) => {
                      const code = 'a'.charCodeAt(0);
                      const letterOption = String.fromCharCode(code + index);
                      const optionIcon = option.userCheck === true ?
                        option.isCorrect === true ? <Check size={20} color="lime" /> : <X size={20} color="red" />
                        : <Circle size={20} color="#7d7d7d" />;
                      return (
                        <>
                          <Col span={1}>
                            {optionIcon}
                          </Col>
                          <Col span={23}>
                            {letterOption.toUpperCase()}. {option.description}
                          </Col>
                        </>
                      )
                    })}
                  </Row>
                </Col>
              </Row>
            ))}
          </Col>
        )}
      </Row>
    </Modal>
  )
}