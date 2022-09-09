import React, { useState, useEffect } from 'react';
import { Steps, Button, Skeleton } from 'antd';
import { connect } from 'react-redux';
import ContentQuestions from './Content';
import { notification } from '../../utils/notification';
import { answerQuestions } from '../../services/quiz';

const { Step } = Steps;

const Quiz = ({ navigate, data: { quizProcessUuid, questions: data } }) => {
  const [loading, setLoading] = useState(false);
  const [current, setCurrent] = useState(0);
  const [steps, setSteps] = useState([]);
  const [answerQuestionsData, setAnswerQuestions] = useState({ quizProcessUuid, answers: [] })

  useEffect(() => {
    init();
  }, [])

  function init() {
    let arrSteps = [];
    data.map(item => arrSteps.push({ question: item.description, content: item }));
    setSteps(arrSteps);
  }

  function onClickOption(indexOption, data) {
    setLoading(true);
    answerQuestionsData.answers.push(data);
    steps[current].content.options[indexOption].isLinked = true;
    setAnswerQuestions(answerQuestionsData);
    setLoading(false);
  }



  if (steps.length === 0) return <Skeleton />;

  const next = () => {
    setCurrent(current + 1);
  };

  const prev = () => {
    setCurrent(current - 1);
  };

  return (
    <>
      <Steps progressDot current={current}>
        {steps.map(item => (
          <Step key={item.question} />
        ))}
      </Steps>
      {loading ? (<div />) : (
        <>
          <div className="steps-content">
            <ContentQuestions data={steps[current].content} onClick={onClickOption} />
          </div>
          <div style={{ display: 'flex', justifyContent: 'center', marginTop: 250 }}>


            {current > 0 && (
              <Button
                style={{
                  margin: '0 8px',
                }}
                onClick={() => prev()}
              >
                Voltar
              </Button>
            )}

            {current === steps.length - 1 && (
              <Button type="primary" onClick={async () => {
                await answerQuestions(answerQuestionsData);
                notification({ status: 'success', message: 'Quiz enviado!' });
                setTimeout(() => {
                  navigate('/quiz');
                }, 1000)
              }} >
                Finalizar Quiz
              </Button>
            )}

            {current < steps.length - 1 && (
              <Button type="primary" onClick={() => next()}>
                Avançar
              </Button>
            )}
          </div>
        </>
      )}
    </>
  )
}

export default connect(state => ({ data: state.data }))(Quiz);