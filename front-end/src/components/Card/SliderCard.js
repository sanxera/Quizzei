import React from 'react';
import { Button as ButtonAntd } from 'antd';
import { useKeenSlider } from 'keen-slider/react';
import Card from './index';
import { DEFAULT_THEME } from '../../utils/constant';

import './index.less';

const SliderCard = ({ data, openInfoQuizzes, isMyQuiz }) => {
  const [sliderRef] = useKeenSlider({
    breakpoints: {
      "(min-width: 1000px)": {
        slides: { perView: 4.1, spacing: 2 },
      },
    },
    dragSpeed: 3
  })

  if (!data || data.length === 0) {
    return (<ButtonAntd style={{ width: '100%', minHeight: 100 }} type='dashed'>Não há quizzes</ButtonAntd>)
  }

  return (
    <div ref={sliderRef} className="keen-slider">
      {data.map((item, index) => (
        <div className="keen-slider__slide card">
          <Card
            className="card1"
            key={`quizzes-${index}`}
            isQuiz
            logo={item.imageUrl || DEFAULT_THEME}
            title={item.title}
            description={item.description}
            ownerNickName={item.ownerNickName}
            numberOfQuestions={item.numberOfQuestions}
            permissionType={item.permissionType || 1}
            onClick={() => openInfoQuizzes(item)}
            isMyQuiz={isMyQuiz}
            style={{ marginRight: 30, marginLeft: 0, minHeight: '20rem', padding: 0, width: 240 }}
          />
        </div>
      ))}
    </div>
  )
}

export default SliderCard;

