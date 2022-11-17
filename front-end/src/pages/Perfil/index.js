import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Row, Col, Avatar, Typography, Rate, Card, Divider } from 'antd';
import styles from './styles.less';
import { getPerfil } from '../../services/perfil';
import { listQuizzesFromUser } from '../../services/quiz';
import StartQuiz from '../Quiz/StartQuiz';

const { Title, Text } = Typography;

const Perfil = ({ data, dispatch }) => {
  const [arrQuizzes, setArrQuizzes] = useState([]);
  const [perfil, setPerfil] = useState(null);
  const [infoVisible, setInfoVisible] = useState(false);
  const [rowData, setRowData] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const perfilData = await getPerfil(data.userUuid);
    const quizzes = await listQuizzesFromUser(data.userUuid);

    setPerfil(perfilData);
    setArrQuizzes(quizzes);
  }

  async function openInfoQuizzes(data) {
    await setRowData(data);
    await setInfoVisible(!infoVisible);
  }

  if (!perfil) return <div />;

  return (
    <>
      <Row justify='center'>
        <Col style={{ display: 'flex', marginTop: 3, justifyContent: 'center', alignItems: 'center' }} span={24}>
          <Row style={{ display: 'flex', marginRight: 120 }} justify='center'>
            <Col>
              <Avatar
                style={{
                  backgroundColor: '#51d1f3',
                  border: '1px solid #000',
                  verticalAlign: 'middle',
                }}
                size={100}
                gap={4}
              >{(perfil.nickName[0] || '').toUpperCase()}</Avatar>
            </Col>

            <Col style={{ display: 'flex', flexDirection: 'column', marginLeft: 10, marginTop: 10 }}>
              <div style={{ display: 'flex', textAlign: 'center' }}>
                <Title style={{ padding: 0, margin: 0 }} level={2}>{perfil.nickName}</Title>
                <Text style={{ marginTop: 10, marginLeft: 10 }}>({perfil.roleName})</Text>
              </div>
              <Text>{perfil.email}</Text>
              <Rate style={{ margin: 0 }} disabled defaultValue={perfil.rating} />
            </Col>

          </Row>
        </Col >

        <Divider />

        <Col style={{ textAlign: 'center' }}>
          <h2>Quizzes</h2>
          {arrQuizzes.quizzesInfoDto && arrQuizzes.quizzesInfoDto.map((item, index) => (
            <Card
              key={`perfil-quizzes-${index}`}
              className={styles.card}
              hoverable
              style={{ width: '100%', marginTop: '3rem' }}
              bodyStyle={{ margin: 0, padding: 0 }}
              onClick={() => openInfoQuizzes(item)}
            >
              <Row style={{ padding: 15 }}>
                <Col style={{ display: 'flex', justifyContent: 'space-between' }} span={24}>
                  <Title className={styles.text} level={4}>{item.title}e</Title>
                  <div>{item.categoryDescription}</div>
                </Col>
                <Col style={{ display: 'flex', justifyContent: 'space-between' }} span={24}>
                  <div>{item.description}</div>
                  <div>10 perguntas</div>
                </Col>
                <Col style={{ marginTop: 20, marginBottom: 0, textAlign: 'initial' }} span={24}>
                  <Rate disabled defaultValue={item.points} />
                </Col>
              </Row>
            </Card>
          ))}
        </Col>
      </Row>

      {infoVisible && (
          <StartQuiz
            navigate={navigate}
            rowData={rowData}
            visible={infoVisible}
            onClose={() => setInfoVisible(false)}
          />
        )}
    </>
  )
}

export default connect(state => ({ data: state.data }))(Perfil);