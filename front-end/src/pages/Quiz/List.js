import React, { useState, useEffect } from 'react';
import { Row, Col, Typography } from 'antd';
import { useNavigate } from 'react-router-dom';
import { PlusCircleOutlined } from '@ant-design/icons';
import { connect } from 'react-redux';
import { Button } from '../../components/Button';
import ModalQuiz from './Modal';
import StartQuiz from './StartQuiz';
import { listMyQuizzes, listPublicQuizzesByCategory, listPublicQuizzes } from '../../services/quiz';

import styles from './styles.less'
import Filter from '../../components/Filter';
import SliderCard from '../../components/Card/SliderCard';
import { getUser } from '../../services/session';

const { Title } = Typography;

const List = () => {
  const navigate = useNavigate();
  const [currentUser, setCurrentUser] = useState({});
  const [userQuizzes, setUserQuizzes] = useState({});
  const [publicQuizzes, setPublicQuizzes] = useState({});
  const [allQuizzes, setAllQuizzes] = useState({});
  const [visible, setVisible] = useState(false);
  const [infoVisible, setInfoVisible] = useState(false);
  const [rowData, setRowData] = useState({});
  const [data, setData] = useState({});

  useEffect(() => {
    init();
  }, [])

  async function init() {
    // TODO adicionar o currentUser ao store para nao precisar chamar a função em todas as paginas
    const currentUser = await getUser();
    const userQuizzes = await listMyQuizzes();
    const publicQuizzes = await listPublicQuizzesByCategory();
    const allQuizzes = await listPublicQuizzes();
    await setCurrentUser(currentUser);
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
    <div style={{ backgroundColor: '#FFFF', paddingBottom: 50, borderRadius: 15, padding: 20, boxShadow: '0 3px 10px rgb(0 0 0 / 0.2)' }}>
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
          <Col
            className={styles.quizCategory}
            span={24}
          >
            <Title level={3} > Meus Quizzes</Title>
            {currentUser.admin === true ? (<Button title="Criar quiz" onClick={handleModal} icon={<PlusCircleOutlined />} />) : null}
          </Col>

          <Col span={24} className={styles.listQuizzes}>
            <SliderCard data={userQuizzes?.quizzesInfoDto || []} openInfoQuizzes={handleModal} isMyQuiz />
          </Col>

          <Col className={styles.quizCategory} span={24}>
            <Title level={3} >Quizzes Publicados</Title>
          </Col>

          <Col className={styles.listQuizzes}>
            <Row >
              {publicQuizzes.quizzesByCategories && publicQuizzes.quizzesByCategories.map((data, index) => (
                <Col key={`public-quizzes-${index}`} style={{ left: 30, marginBottom: 30 }} span={24}>
                  <Title level={4} >{data.categoryName}</Title>
                  <SliderCard data={data.quizzesInfoResponses} openInfoQuizzes={openInfoQuizzes} />
                </Col>
              ))}
            </Row>

          </Col>
        </Row>

        {visible && (
          <ModalQuiz
            rowData={rowData}
            onClose={onCloseModal}
            onCallback={init}
            visible={visible}
            navigate={navigate}
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
    </div>
  )
}

export default connect(state => ({ status: state.status }))(List);