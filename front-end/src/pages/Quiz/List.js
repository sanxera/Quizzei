import React, { useState } from 'react';
import { Row, Col, Typography, Input, Button } from 'antd';
import { RightOutlined } from '@ant-design/icons'
import ModalQuiz from './Modal';

import CardWrapper from '../../components/CardWrapper';
import StartQuiz from './StartQuiz';

const { Title, Text } = Typography;

const List = () => {
  const [visible, setVisible] = useState(false);
  const [infoVisible, setInfoVisible] = useState(false);
  const [rowData, setRowData] = useState({});

  async function handleModal(data) {
    await setRowData(data);
    await setVisible(!visible);
  }

  async function openInfoQuizzes(data) {
    await setRowData(data);
    await setInfoVisible(!infoVisible);
  }

  const arrQuizzes = [
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://i.ytimg.com/vi/HEnqGVbi9Nc/maxresdefault.jpg'
    },
  ]


  const arrFilter = [
    {
      description: 'Programação',
      logo: 'https://i.pinimg.com/originals/0f/8b/28/0f8b2870896edcde8f6149fe2733faaf.jpg',
    },
    {
      description: 'Matematica',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Circle-icons-calculator.svg/1200px-Circle-icons-calculator.svg.png',
    },
    {
      description: 'Geografia',
      logo: 'https://thumbs.dreamstime.com/b/icon-regional-territorial-regional-175491126.jpg',
    },
    {
      description: 'Portugues',
      logo: 'https://static.thenounproject.com/png/2053718-200.png',
    },
    {
      description: 'Ciencia',
      logo: 'https://cdn-icons-png.flaticon.com/512/1046/1046269.png',
    },
    {
      description: 'Fisíca',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Circle-icons-calculator.svg/1200px-Circle-icons-calculator.svg.png',
    },
    {
      description: 'Matematica',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Circle-icons-calculator.svg/1200px-Circle-icons-calculator.svg.png',
    },
    {
      description: 'Matematica',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Circle-icons-calculator.svg/1200px-Circle-icons-calculator.svg.png',
    },
    {
      description: 'Matematica',
      logo: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Circle-icons-calculator.svg/1200px-Circle-icons-calculator.svg.png',
    },
  ]

  return (
    <div>
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
                <Button type="link" shape='circle'>
                  <img style={{ width: '100%', height: 50, borderRadius: '20px 20px 20px 20px' }} alt="example" src={item.logo} />
                </Button>
              </Col>
              <Col span={24} style={{ marginTop: 30, display: 'flex', justifyContent: 'center' }}>
                <Text>{item.description}</Text>
              </Col>
            </Row>
          ))}
        </Col>
      </Row>

      <div style={{ display: 'flex', marginTop: 100 }}>
        <Row justify='center'>
          <Col span={24} style={{ marginBottom: 20, paddingLeft: 75 }}>
            <Title level={3} >Meus Quizzes</Title>
          </Col>
          <Col style={{ display: 'flex' }}>
            {arrQuizzes.map((item, index) => (
              <CardWrapper key={`my-quizzes-${index}`} logo={item.image} title={item.title} description={item.description} onClick={() => handleModal(item)} style={{ marginRight: 30, padding: 0 }} />
            ))}
          </Col>

          <Col span={24} style={{ marginTop: 50, marginBottom: 20, paddingLeft: 75 }}>
            <Title level={3} >Quizzes</Title>
          </Col>
          <Col style={{ display: 'flex' }}>
            {arrQuizzes.map((item, index) => (
              <CardWrapper key={`quizzes-${index}`} isQuiz logo={item.image} title={item.title} description={item.description} onClick={() => openInfoQuizzes(item)} style={{ marginRight: 30, padding: 0 }} />
            ))}
          </Col>
        </Row>

        <ModalQuiz data={rowData} onClose={handleModal} visible={visible} />
        <StartQuiz data={rowData} visible={infoVisible} onClose={() => setInfoVisible(false)} />
      </div>
    </div>
  )
}

export default List;