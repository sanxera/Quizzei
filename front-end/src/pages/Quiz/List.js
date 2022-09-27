import React, { useState, useEffect } from 'react';
import { Row, Col, Typography, Select } from 'antd';
import { useNavigate } from 'react-router-dom';
import { RightOutlined, PlusCircleOutlined } from '@ant-design/icons';
import { connect } from 'react-redux';

import { useKeenSlider } from "keen-slider/react"
import "keen-slider/keen-slider.min.css"

import Card from '../../components/Card';
import { Button } from '../../components/Button';
import ModalQuiz from './Modal';
import StartQuiz from './StartQuiz';
import { listMyQuizzes, listPublicQuizzes } from '../../services/quiz';

import styles from './styles.less'

const { Option, OptGroup } = Select;
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

  const [visible, setVisible] = useState(false);
  const [infoVisible, setInfoVisible] = useState(false);
  const [rowData, setRowData] = useState({});

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const userQuizzes = await listMyQuizzes();
    const publicQuizzes = await listPublicQuizzes();
    await setUserQuizzes(userQuizzes);
    await setPublicQuizzes(publicQuizzes);
  }

  async function handleModal(data) {
    if (data) await setRowData(data);
    await setVisible(!visible);
  }

  async function onCloseModal() {
    await setRowData({});
    await setVisible(!visible);
  }

  async function openInfoQuizzes(data) {
    await setRowData(data);
    await setInfoVisible(!infoVisible);
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
      {/* TODO component filter */}
      <Row>
        <Col span={24} style={{ textAlign: 'center' }}>
          <Title level={3}>Que tipo de quiz você está buscando?</Title>
        </Col>
        <Col span={24}>
          <Select
            onSelect={() => {
              navigate('/perfil')
            }}
            size="large"
            style={{ backgroundColor: '#FFFF', borderRadius: 20, width: '100%' }}
            suffixIcon={<RightOutlined />}
          >
            <OptGroup label="Quizzes">
              <Option value="jack">Quiz numero 1</Option>
              <Option value="lucy">Quiz numero 2</Option>
            </OptGroup>
            <OptGroup label="Instituições">
              <Option value="Senai"> Senai Londrina </Option>
            </OptGroup>
          </Select>
        </Col>
        <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}>
          {arrFilter.map(item => (
            <Row key={`arr-filter-${item.description}`}>
              <Col span={24}>
                <Button
                  // icon={<img style={{ width: '100%', height: 50, borderRadius: '20px 20px 20px 20px' }} alt="example" src={item.logo} />}
                  type="link"
                  shape='circle'
                  style={{ backgroundColor: '#FFFF', borderColor: '#FFFF' }}
                />
              </Col>
              <Col span={24} style={{ marginTop: 30, textAlign: 'center' }}>
                <Text strong>{item.description}</Text>
              </Col>
            </Row>
          ))}
        </Col>
      </Row>

      <div className={styles.quizContainer}>
        <Row>
          <Col className={styles.quizCategory} span={24}>
            < Title level={3} > Meus Quizzes</Title>
            <Button title="Criar quiz" onClick={handleModal} icon={<PlusCircleOutlined />} />
          </Col>

          <Col ref={sliderRef} className={styles.listQuizzes}>
            {(!userQuizzes.quizzesInfoDto || userQuizzes.quizzesInfoDto.length === 0) && (
              <Button style={{ width: '115rem', minHeight: 100 }} type='dashed'>Não há quizzes</Button>
            )}
            {userQuizzes.quizzesInfoDto && userQuizzes.quizzesInfoDto.map((item, index) => (
              <Card
                logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                title={item.title}
                description={item.description}
                onClick={() => handleModal(item)}
                style={{ marginRight: 30, padding: 0 }}
              />
            ))}
          </Col>

          <Col className={styles.quizCategory} span={24}>
            <Title level={3} >Quizzes</Title>
          </Col>
          <Col className={styles.listQuizzes}>
            {(!publicQuizzes.quizzesInfoDto || publicQuizzes.quizzesInfoDto.length === 0) && (
              <Button style={{ width: '115rem', minHeight: 100 }} type='dashed'>Não há quizzes</Button>
            )}
            {publicQuizzes.quizzesInfoDto && publicQuizzes.quizzesInfoDto.map((item, index) => (
              <Card
                key={`quizzes-${index}`}
                isQuiz
                logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                title={item.title}
                description={item.description}
                onClick={() => openInfoQuizzes(item)}
                style={{ marginRight: 30, minHeight: '20rem', padding: 0 }} />
            ))}
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
            data={rowData}
            visible={infoVisible}
            onClose={() => setInfoVisible(false)}
          />
        )}

      </div >
    </>
  )
}

export default connect(state => ({ status: state.status }))(List);