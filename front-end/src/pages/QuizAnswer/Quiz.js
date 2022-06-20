import React, { useState } from 'react';
import { Steps, Button } from 'antd';
import ContentQuestions from './Content';
import { notification } from '../../utils/notification';

const { Step } = Steps;

const questions = [
  {
    question: 'Questão 1',
    options: [
      {
        description: 'Resposta 1'
      },
      {
        description: 'Resposta 2'
      },
      {
        description: 'Resposta 3'
      },
      {
        description: 'Resposta 4'
      },
    ]
  },
  {
    question: 'Questão 2',
    options: [
      {
        description: 'Resposta 1'
      },
      {
        description: 'Resposta 2'
      },
      {
        description: 'Resposta 3'
      },
      {
        description: 'Resposta 4'
      },
    ]
  },
  {
    question: 'Questão 3',
    options: [
      {
        description: 'Resposta 1'
      },
      {
        description: 'Resposta 2'
      },
      {
        description: 'Resposta 3'
      },
      {
        description: 'Resposta 4'
      },
    ]
  },
  {
    question: 'Questão 4',
    options: [
      {
        description: 'Resposta 1'
      },
      {
        description: 'Resposta 2'
      },
      {
        description: 'Resposta 3'
      },
      {
        description: 'Resposta 4'
      },
    ]
  },
  {
    question: 'Questão 5',
    options: [
      {
        description: 'Resposta 1'
      },
      {
        description: 'Resposta 2'
      },
      {
        description: 'Resposta 3'
      },
      {
        description: 'Resposta 4'
      },
    ]
  },
]

const steps = [
  {
    question: 'Questão 1',
    content: questions[0]
  },
  {
    question: 'Questão 2',
    content: questions[1]
  },
  {
    question: 'Questão 3',
    content: questions[2]
  },
  {
    question: 'Questão 4',
    content: questions[3]
  },
  {
    question: 'Questão 5',
    content: questions[4]
  },
]

const Quiz = ({ navigate }) => {

  const [current, setCurrent] = useState(0);

  const next = () => {
    setCurrent(current + 1);
  };

  const prev = () => {
    setCurrent(current - 1);
  };

  return (
    <>
      <Steps progressDot current={current}>
        {steps.map((item) => (
          <Step key={item.question} />
        ))}
      </Steps>
      <div className="steps-content">
        <ContentQuestions data={steps[current].content} />
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
          <Button type="primary" onClick={() => {
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
  )
}

export default Quiz;