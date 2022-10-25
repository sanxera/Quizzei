import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { connect } from 'react-redux';
import { Steps, Skeleton } from 'antd';
import ContentQuestions from './Content';
import { Button } from '../../components/Button'
import { notification } from '../../utils/notification';
import { answerQuestions } from '../../services/quiz';

import styles from './index.less';
import { FinishedModal } from './FinishedModal';

const { Step } = Steps;

const Quiz = ({ data: { quizProcessUuid, questions: data } }) => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [current, setCurrent] = useState(0);
  const [steps, setSteps] = useState([]);
  const [finallyData, setFinallyData] = useState({});
  const [showFinallyModal, setShowFinallyModal] = useState(false);
  const [answerQuestionsData, setAnswerQuestions] = useState({ quizProcessUuid, answers: [] })

  useEffect(() => {
    init();
  }, [])

  function init() {
    let arrSteps = [];
    data.map(item => arrSteps.push({ question: item.description, content: item }));
    setSteps(arrSteps);
  }

  async function onClickOption(indexOption, data) {
    await setLoading(true);
    await answerQuestionsData.answers.push(data);
    steps[current].content.selectedOption = indexOption;
    await setAnswerQuestions(answerQuestionsData);
    await setSteps(steps)
    setLoading(false);
  }

  async function onFinishQuiz() {
    const response = await answerQuestions(answerQuestionsData);
    const { totalQuestions, correctAnswers } = response;
    if (!totalQuestions || !correctAnswers) {
      notification({ status: 'error', message: 'Ocorreu um erro ao finalizar o quiz' });
      return;
    }

    await setFinallyData({ totalQuestions, correctAnswers });
    await setShowFinallyModal(true);
  }

  function onClickModal() {
    navigate('/quiz')
  }

  if (steps.length === 0 || loading) return <Skeleton />;

  const next = () => {
    setCurrent(current + 1);
  };

  const prev = () => {
    setCurrent(current - 1);
  };

  return (
    <div>
      <Steps progressDot current={current}>
        {steps.map(item => (
          <Step key={item.question} />
        ))}
      </Steps>

      <>
        <div className="steps-content">
          <ContentQuestions data={steps[current].content} onClick={onClickOption} />
        </div>
        <div style={{ display: 'flex', justifyContent: 'center', marginTop: 10 }}>


          {current > 0 && (
            <Button
              className={styles.btnPrev}
              title="Voltar"
              style={{
                margin: '0 8px',
              }}
              onClick={() => prev()}
            />
          )}

          {current === steps.length - 1 && (
            <Button
              className={styles.btnNext}
              title="Finalizar Quiz"
              onClick={onFinishQuiz} />
          )}

          {current < steps.length - 1 && (
            <Button className={styles.btnNext} title="Avançar" onClick={() => next()} />
          )}
        </div>
      </>

      <FinishedModal visible={showFinallyModal} data={finallyData} onClick={onClickModal} />
    </div >
  )
}

export default connect(state => ({ data: state.data }))(Quiz);