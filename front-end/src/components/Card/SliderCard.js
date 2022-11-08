import React, { useState } from 'react';
import { Button as ButtonAntd } from 'antd';
import { useKeenSlider } from "keen-slider/react"
import Card from './index';

import './index.less';

function Arrow(props) {
  const disabeld = props.disabled ? " arrow--disabled" : ""
  return (
    <svg
      onClick={props.onClick}
      className={`arrow ${props.left ? "arrow--left" : "arrow--right"
        } ${disabeld}`}
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 24 24"
    >
      {props.left && (
        <path d="M16.67 0l2.83 2.829-9.339 9.175 9.339 9.167-2.83 2.829-12.17-11.996z" />
      )}
      {!props.left && (
        <path d="M5 3l3.057-3 11.943 12-11.943 12-3.057-3 9-9z" />
      )}
    </svg>
  )
}

const SliderCard = ({ data, openInfoQuizzes }) => {
  const [loaded, setLoaded] = useState(false)
  const [currentSlide, setCurrentSlide] = useState(0)
  const [sliderRef, instanceRef] = useKeenSlider({
    initial: 0,
    slideChanged: slider => setCurrentSlide(slider.track.details.rel),
    created: () => setLoaded(true),
    slides: {
      perView: 5,
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
        <>
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
          {/* {
            loaded && instanceRef.current && (
              <>
                <Arrow
                  left
                  onClick={(e) =>
                    e.stopPropagation() || instanceRef.current?.prev()
                  }
                  disabled={currentSlide === 0}
                />

                <Arrow
                  onClick={(e) =>
                    e.stopPropagation() || instanceRef.current?.next()
                  }
                  disabled={
                    currentSlide ===
                    instanceRef.current.track.details.slides.length - 1
                  }
                />
              </>
            )
          } */}
        </>
      ))}
    </div>
  )
}

export default SliderCard;

