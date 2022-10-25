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

const { Title, Text } = Typography;

const List = () => {
  const navigate = useNavigate();
  const [sliderRef] = useKeenSlider({
    slides: {
      perView: 2,
      spacing: 15,
    },
  })
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

    console.log(quiz, '<<<<< quiz')

    switch (quizType) {
      case 'userQuizzes':
        handleModal(quiz);
        break;

      default:
        openInfoQuizzes(quiz);
        break;
    }
  }

  const arrFilter = [
    {
      description: 'Programação',
      logo: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtL8rQ0JI7gAvQ0apgQlbTc1_8iNbZp-VroD_wSmk8yOviTzEnvznx7W9TdFomegR_un8&usqp=CAU',
    },
    {
      description: 'Matematica',
      logo: 'https://img.freepik.com/free-vector/calculator-concept-illustration_114360-1259.jpg?w=2000',
    },
    {
      description: 'Geografia',
      logo: 'https://img.freepik.com/free-vector/geography-teacher-explaining-lesson-pupil-woman-with-pointer-girl-planet-model-flat-illustration_74855-10671.jpg?w=2000',
    },
    {
      description: 'Portugues',
      logo: 'https://c8.alamy.com/comp/2C50YRR/open-book-education-and-reading-concept-book-festival-back-to-school-modern-vector-illustration-in-flat-style-2C50YRR.jpg',
    },
    {
      description: 'Ciencia',
      logo: 'https://st4.depositphotos.com/4006379/39000/v/950/depositphotos_390004064-stock-illustration-science-chemistry-icon-logo-vector.jpg?forcejpeg=true',
    },
    {
      description: 'Fisíca',
      logo: 'https://previews.123rf.com/images/stockgiu/stockgiu1709/stockgiu170905590/86637891-f%C3%ADsica-%C3%B3rbita-qu%C3%ADmica-ciencia-educaci%C3%B3n-vector-ilustraci%C3%B3n.jpg',
    },
  ];

  return (
    <>
      <Row>
        <Col span={24} style={{ textAlign: 'center' }}>
          <Title level={3}>Que tipo de quiz você está buscando?</Title>
        </Col>
        <Col span={24}>
          <Filter onSelect={onSelect} navigate={navigate} />
        </Col>
        <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}>
          {arrFilter.map(item => (
            <Row key={`arr-filter-${item.description}`}>
              <Col style={{ display: 'flex', justifyContent: 'center' }} span={24}>
                <ButtonAntd
                  // size='large'
                  icon={<img style={{ width: '100%', height: 50, borderRadius: '20px 20px 20px 20px' }} alt="example" src={item.logo} />}
                  type="link"
                  shape='circle'
                  style={{ backgroundColor: '#FFFF', borderColor: '#FFFF', }}
                />
              </Col>
              <Col span={24} style={{ marginTop: 30, display: 'flex', justifyContent: 'center' }}>
                <Text strong>{item.description}</Text>
              </Col>
            </Row>
          ))}
        </Col>
      </Row>

      <div className={styles.quizContainer}>
        <Row style={{ maxWidth: '90vw' }}>
          <Col className={styles.quizCategory} span={24}>
            <Title level={3} > Meus Quizzes</Title>
            <Button title="Criar quiz" onClick={handleModal} icon={<PlusCircleOutlined />} />
          </Col>

          <Col ref={sliderRef} className={`keen-slide ${styles.listQuizzes}`}>
            {userQuizzes.quizzesInfoDto && userQuizzes.quizzesInfoDto.length > 0 ? userQuizzes.quizzesInfoDto.map((item, index) => (
              <Card
                cardName={`keen-slider__slide${index}`}
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
          {/* <Col className={styles.listQuizzes}>
            {publicQuizzes.quizzesInfoDto && publicQuizzes.quizzesInfoDto.length > 0 ? publicQuizzes.quizzesInfoDto.map((item, index) => (
              <Card
                key={`quizzes-${index}`}
                isQuiz
                logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                title={item.title}
                description={item.description}
                onClick={() => openInfoQuizzes(item)}
                style={{ marginRight: 30, minHeight: '20rem', padding: 0 }} />
            )) : (
              <ButtonAntd style={{ width: '80vw', minHeight: 100 }} type='dashed'>Não há quizzes</ButtonAntd>
            )}
          </Col> */}
          <Col className={styles.listQuizzes}>
            <Row >
              {publicQuizzes.quizzesByCategories && publicQuizzes.quizzesByCategories.map(data => (
                <Col style={{ left: 30, marginBottom: 30 }} span={24}>
                  <Title level={4} >{data.categoryName}</Title>
                  {/* </Col>
                <Col span={24}> */}
                  <div style={{ display: 'flex', marginTop: 20 }}>
                    {
                      data.quizzesInfoResponses && data.quizzesInfoResponses.length > 0 ? data.quizzesInfoResponses.map((item, index) => (
                        <Card
                          key={`quizzes-${index}`}
                          isQuiz
                          logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                          title={item.title}
                          description={item.description}
                          ownerNickName={item.ownerNickName}
                          numberOfQuestions={item.numberOfQuestions}
                          onClick={() => openInfoQuizzes(item)}
                          style={{ marginRight: 30, minHeight: '20rem', padding: 0 }} />
                      )) : (
                        <ButtonAntd style={{ width: '80vw', minHeight: 100 }} type='dashed'>Não há quizzes</ButtonAntd>
                      )
                    }
                  </div>
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
            data={data}
            visible={infoVisible}
            onClose={() => setInfoVisible(false)}
          />
        )}

      </div >
    </>
  )
}

export default connect(state => ({ status: state.status }))(List);