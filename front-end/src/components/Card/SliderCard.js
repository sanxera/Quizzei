import React from 'react';
import { Button as ButtonAntd } from 'antd';
import Card from './index';

import './index.less';

const SliderCard = ({ data, openInfoQuizzes }) => {
  if (!data.quizzesInfoResponses || data.quizzesInfoResponses.length === 0) {
    return (<ButtonAntd style={{ width: '80vw', minHeight: 100 }} type='dashed'>Não há quizzes</ButtonAntd>)
  }

  return (
    <div className="slider-card">
      {data.quizzesInfoResponses.map((item, index) => (
        <Card
          className="card"
          key={`quizzes-${index}`}
          isQuiz
          logo={item.imageUrl || 'https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'}
          title={item.title}
          description={item.description}
          ownerNickName={item.ownerNickName}
          numberOfQuestions={item.numberOfQuestions}
          onClick={() => openInfoQuizzes(item)}
          style={{ marginRight: 30, marginLeft: 0, minHeight: '20rem', padding: 0, width: 240 }}
        />
      ))}
    </div>
  )
}

export default SliderCard;

