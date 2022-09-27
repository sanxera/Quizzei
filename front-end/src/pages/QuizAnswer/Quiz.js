import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Steps, Skeleton } from 'antd';
import { connect } from 'react-redux';
import ContentQuestions from './Content';
import { Button } from '../../components/Button'
import { notification } from '../../utils/notification';
import { answerQuestions } from '../../services/quiz';

import styles from './index.less';

const { Step } = Steps;

const Quiz = ({ data: { quizProcessUuid, questions: data } }) => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [current, setCurrent] = useState(0);
  const [steps, setSteps] = useState([]);
  const [answerQuestionsData, setAnswerQuestions] = useState({ quizProcessUuid, answers: [] })

  useEffect(() => {
    init();
  }, [])

  // useEffect(() => {
  //   setLoading(false);
  // }, [steps])

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

    // setTimeout(() => {
      setLoading(false);
    // }, 500);
  }
  console.log(steps)

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
              onClick={async () => {
                await answerQuestions(answerQuestionsData);
                notification({ status: 'success', message: 'Quiz enviado!' });
                setTimeout(() => {
                  navigate('/quiz');
                }, 1000)
              }} />
          )}

          {current < steps.length - 1 && (
            <Button className={styles.btnNext} title="Avançar" onClick={() => next()} />
          )}
        </div>
      </>
    </div >
  )
}

export default connect(state => ({ data: state.data }))(Quiz);