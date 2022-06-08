import React, { useState, useEffect } from 'react';
import { Row, Col, Typography, Input, Button } from 'antd';
import { RightOutlined, PlusCircleOutlined } from '@ant-design/icons'
import ModalQuiz from './Modal';

import CardWrapper from '../../components/CardWrapper';
import StartQuiz from './StartQuiz';
import { listMyQuizzes, listPublicQuizzes } from '../../services/quiz';

const { Title, Text } = Typography;

const List = () => {
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
  ]

  return (
    <>
      {/* Criar componente de filtro */}
      <Row>
        <Col span={24} style={{ display: 'flex', justifyContent: 'center' }}>
          <Title level={3}>Que tipo de quiz você está buscando?</Title>
        </Col>
        <Col span={24}>
          <Input style={{ backgroundColor: '#FFFF', borderRadius: 20, height: 50 }} suffix={<RightOutlined />} />
        </Col>
        <Col span={24} style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}>
          {arrFilter.map(item => (
            <Row>
              <Col span={24} style={{ display: 'flex', justifyContent: 'center' }}>
                <Button type="link" shape='circle' style={{ backgroundColor: '#FFFF', borderColor: '#FFFF' }}>
                  <img style={{ width: '100%', height: 50, borderRadius: '20px 20px 20px 20px' }} alt="example" src={item.logo} />
                </Button>
              </Col>
              <Col span={24} style={{ marginTop: 30, display: 'flex', justifyContent: 'center' }}>
                <Text style={{ fontWeight: 'bold' }}>{item.description}</Text>
              </Col>
            </Row>
          ))}
        </Col>
      </Row>

      <div style={{ display: 'flex', marginTop: 100 }}>
        <Row>
          <Col span={20} style={{ marginBottom: 20, paddingLeft: 75 }}>
            <Title level={3} >Meus Quizzes</Title>
          </Col>
          <Col span={4} style={{ marginBottom: 20, paddingLeft: 75 }}>
            <Button
              className='btn-main'
              shape='round'
              onClick={handleModal}>
              <PlusCircleOutlined /> Criar quiz
            </Button>
          </Col>
          <Col style={{ display: 'flex', marginLeft: 100 }}>
            {userQuizzes.quizzesInfoDto && userQuizzes.quizzesInfoDto.map((item, index) => (
              <CardWrapper
                key={`my-quizzes-${index}`}
                logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                title={item.title}
                description={item.description}
                onClick={() => handleModal(item)} style={{ marginRight: 30, padding: 0 }}
              />
            ))}
          </Col>

          <Col span={24} style={{ marginTop: 50, marginBottom: 20, paddingLeft: 75 }}>
            <Title level={3} >Quizzes</Title>
          </Col>
          <Col style={{ display: 'flex', marginLeft: 100 }}>
            {publicQuizzes.quizzesInfoDto && publicQuizzes.quizzesInfoDto.map((item, index) => (
              <CardWrapper
                key={`quizzes-${index}`}
                isQuiz
                logo='https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
                title={item.title}
                description={item.description}
                onClick={() => openInfoQuizzes(item)}
                style={{ marginRight: 30, padding: 0 }} />
            ))}
          </Col>
        </Row>

        <ModalQuiz data={rowData} onClose={handleModal} onCallback={init} visible={visible} />
        <StartQuiz data={rowData} visible={infoVisible} onClose={() => setInfoVisible(false)} />
      </div>
    </>
  )
}

export default List;