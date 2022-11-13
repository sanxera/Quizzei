import React, { useState, useEffect } from 'react';
import { Row, Col, Typography, Button as ButtonAntd } from 'antd';
import { useNavigate } from 'react-router-dom';
import { PlusCircleOutlined } from '@ant-design/icons';
import { connect } from 'react-redux';

import { useKeenSlider } from "keen-slider/react"

import Card from '../../components/Card';
import { Button } from '../../components/Button';
import ModalQuiz from './Modal';
import StartQuiz from './StartQuiz';
import { listMyQuizzes, listPublicQuizzesByCategory, listPublicQuizzes } from '../../services/quiz';

import styles from './styles.less'
import Filter from '../../components/Filter';
import SliderCard from '../../components/Card/SliderCard';

const { Title, Text } = Typography;

const List = () => {
  const navigate = useNavigate();
  // const [sliderRef] = useKeenSlider({
  //   slides: {
  //     perView: 5,
  //     spacing: 15,
  //   },
  // })
  const [userQuizzes, setUserQuizzes] = useState({});
  const [publicQuizzes, setPublicQuizzes] = useState({});
  const [allQuizzes, setAllQuizzes] = useState({});
  // const [allQuizzes, setAllQuizzes] = useState([])
  const [visible, setVisible] = useState(false);
  const [infoVisible, setInfoVisible] = useState(false);
  const [rowData, setRowData] = useState({});
  const [data, setData] = useState({});

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const userQuizzes = await listMyQuizzes();
    const publicQuizzes = await listPublicQuizzesByCategory();
    const allQuizzes = await listPublicQuizzes();
    await setUserQuizzes(userQuizzes);
    await setPublicQuizzes(publicQuizzes);
    await setAllQuizzes(allQuizzes);
  }

  async function handleModal(data) {
    if (data) await setRowData(data);
    await setVisible(!visible);
  }

  async function onCloseModal() {
    await setRowData({});
    await setData({});
    await setVisible(!visible);
  }

  async function openInfoQuizzes(data) {
    await setData(data);
    await setInfoVisible(!infoVisible);
  }

  async function onSelect(quizInfoUuid) {
    let quiz = {};
    let quizType = 'userQuizzes';
    quiz = userQuizzes.quizzesInfoDto.filter(data => data.quizInfoUuid === quizInfoUuid)[0];

    if (!quiz || !quiz.quizInfoUuid) {
      quizType = 'publicQuizzes';
      quiz = allQuizzes.quizzesInfoDto.filter(data => data.quizInfoUuid === quizInfoUuid)[0];
    }

    switch (quizType) {
      case 'userQuizzes':
        handleModal(quiz);
        break;

      default:
        openInfoQuizzes(quiz);
        break;
    }
  }

  return (
    <>
      <Row>
        <Col span={24} style={{ textAlign: 'center' }}>
          <Title level={3}>Que tipo de quiz você está buscando?</Title>
        </Col>

        <Col span={24}>
          <Filter onSelect={onSelect} navigate={navigate} />
        </Col>
      </Row>

      <div className={styles.quizContainer}>
        <Row style={{ maxWidth: '90vw' }}>
          <Col className={styles.quizCategory} span={24}>
            <Title level={3} > Meus Quizzes</Title>
            <Button title="Criar quiz" onClick={handleModal} icon={<PlusCircleOutlined />} />
          </Col>

          <Col className={`keen-slide ${styles.listQuizzes}`}>
            {userQuizzes.quizzesInfoDto && userQuizzes.quizzesInfoDto.length > 0 ? userQuizzes.quizzesInfoDto.map((item, index) => (
              <Card
                key={`my-quizzes-${index}`}
                // cardName={`keen-slider__slide${index}`}
                logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                title={item.title}
                description={item.description}
                onClick={() => handleModal(item)}
                style={{ marginRight: 30, padding: 0 }}
              />
            )) : (
              <ButtonAntd style={{ width: '80vw', minHeight: 100 }} type='dashed'>Não há quizzes</ButtonAntd>
            )}
          </Col>

          <Col className={styles.quizCategory} span={24}>
            <Title level={3} >Quizzes Publicados</Title>
          </Col>

          <Col className={styles.listQuizzes}>
            <Row >
              {publicQuizzes.quizzesByCategories && publicQuizzes.quizzesByCategories.map((data, index) => (
                <Col key={`public-quizzes-${index}`} style={{ left: 30, marginBottom: 30 }} span={24}>
                  <Title level={4} >{data.categoryName}</Title>

                  <SliderCard data={data} openInfoQuizzes={openInfoQuizzes} />

                  {/* <div ref={sliderRef} className="keen-slider" style={{ display: 'flex', marginTop: 20, width: '80vw' }}>
                    {
                      data.quizzesInfoResponses && data.quizzesInfoResponses.length > 0 ? data.quizzesInfoResponses.map((item, index) => (
                        <Card
                          className="keen-slider__slide"
                          key={`quizzes-${index}`}
                          isQuiz
                          logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                          title={item.title}
                          description={item.description}
                          ownerNickName={item.ownerNickName}
                          numberOfQuestions={item.numberOfQuestions}
                          onClick={() => openInfoQuizzes(item)}
                          style={{ marginRight: 30, minHeight: '20rem', padding: 0, width: 240 }} />
                      )) : (
                        <ButtonAntd style={{ width: '80vw', minHeight: 100 }} type='dashed'>Não há quizzes</ButtonAntd>
                      )
                    }
                  </div> */}
                </Col>
              ))}
            </Row>

          </Col>
        </Row>

        {visible && (
          <ModalQuiz
            data={rowData}
            onClose={onCloseModal}
            onCallback={init}
            visible={visible}
          />
        )}

        {infoVisible && (
          <StartQuiz
            navigate={navigate}
            rowData={data}
            visible={infoVisible}
            onClose={() => setInfoVisible(false)}
          />
        )}

      </div >
    </>
  )
}

export default connect(state => ({ status: state.status }))(List);