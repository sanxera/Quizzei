import React from 'react';
import { Button as ButtonAntd } from 'antd';
import { useKeenSlider } from "keen-slider/react"
import Card from './index';

const SliderCard = ({ data, openInfoQuizzes }) => {
  const [sliderRef] = useKeenSlider({
    initial: 0,
    slides: {
      perView: 4.8,
      spacing: 1,
    },
    renderMode: 'performance'
  })

  if (!data.quizzesInfoResponses || data.quizzesInfoResponses.length === 0) {
    return (<ButtonAntd style={{ width: '80vw', minHeight: 100 }} type='dashed'>Não há quizzes</ButtonAntd>)
  }

  return (
    <div ref={sliderRef} className="keen-slider" style={{ display: 'flex', marginTop: 20, width: '80vw' }}>
      {data.quizzesInfoResponses.map((item, index) => (
        <Card
          className="keen-slider__slide card"
          key={`quizzes-${index}`}
          isQuiz
          logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
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

