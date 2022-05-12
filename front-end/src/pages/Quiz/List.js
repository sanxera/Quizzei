import React, { useState } from 'react';
import { Divider, Row, Col, Button, Input, Affix, PageHeader } from 'antd';
import ModalQuiz from './Modal';
import {
  SearchOutlined
} from '@ant-design/icons';
import CardWrapper from '../../components/CardWrapper';
import StartQuiz from './StartQuiz';

const List = ({ navigate }) => {
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
      image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/800px-Unofficial_JavaScript_logo_2.svg.png'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/800px-Unofficial_JavaScript_logo_2.svg.png'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/800px-Unofficial_JavaScript_logo_2.svg.png'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/800px-Unofficial_JavaScript_logo_2.svg.png'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/800px-Unofficial_JavaScript_logo_2.svg.png'
    },
    {
      title: 'Programação em javascript',
      description: 'Este quiz esta denominado para programadores com experiencia em javascript',
      image: 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/800px-Unofficial_JavaScript_logo_2.svg.png'
    },
  ]

  return (
    <Row gutter={10}>
      <Col span={16}>
        <Input />
      </Col>

      <Col span={3}>
        <Button shape='round' type='primary' icon={<SearchOutlined />} />
      </Col>
      <Col span={5} style={{ marginBottom: 30, display: 'flex', justifyContent: 'end' }}>
        <Button shape='round' type="primary" onClick={() => handleModal()} >Criar Quiz</Button>
      </Col>

      <Divider style={{ color: 'black' }} orientation="left">Meus Quizzes</Divider>
      <Col span={24} style={{ display: 'flex' }}>
        {arrQuizzes.map(item => (
          <CardWrapper logo={item.image} title={item.title} description={item.description} onClickCard={() => handleModal(item)} style={{ marginRight: 10, padding: 0 }} />
        ))}
      </Col>

      <Divider style={{ color: 'black' }} orientation="left">Quizzes</Divider>
      <Col>
        <Row justify='space-between'>
          <Col span={15} style={{ display: 'flex' }}>
            {arrQuizzes.map(item => (
              <CardWrapper logo={item.image} title={item.title} description={item.description} onClickCard={() => openInfoQuizzes(item)} style={{ marginRight: 10, padding: 0 }} />
            ))}
          </Col>
        </Row>
      </Col>

      <Col>
        <StartQuiz data={rowData} visible={infoVisible} onClose={() => setInfoVisible(false)} />
      </Col>

      <ModalQuiz data={rowData} onClose={handleModal} visible={visible} />
    </Row>
  )
}

export default List;