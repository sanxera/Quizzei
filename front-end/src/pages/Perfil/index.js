import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Row, Col, Avatar, Typography, Rate, Card } from 'antd';
import styles from './styles.less';
import { getPerfil } from '../../services/perfil';
import { listMyQuizzes } from '../../services/quiz';

const { Title, Text } = Typography;

const Perfil = ({ data, dispatch }) => {
  const [arrQuizzes, setArrQuizzes] = useState([]);
  const [perfil, setPerfil] = useState({});

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const perfilData = await getPerfil(data.userUuid);
    const quizzes = await listMyQuizzes(data.userUuid);

    setPerfil(perfilData);
    setArrQuizzes(quizzes);
  }

  async function onClick() {

  }

  return (
    <Row justify='center'>
      <Col style={{ display: 'flex', marginTop: 50 }} span={10}>
        <Card className={styles.card} style={{ width: '30rem', height: '25rem', }}>
          <Row style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }} justify='center'>
            <Col>
              <Avatar
                style={{
                  backgroundColor: '#f56a00',
                  verticalAlign: 'middle',
                }}
                size={80}
                gap={4}
              >S</Avatar>
            </Col>

            <Col style={{ textAlign: 'center', marginTop: 20 }}>
              <Title className={styles.text} level={4}>{perfil.nickName}</Title>
              <Text className={styles.text}>{perfil.roleName}</Text>
            </Col>

            <Col style={{ marginTop: '5rem' }}>
              <Rate disabled defaultValue={perfil.rating} />
            </Col>
          </Row>
        </Card>
      </Col>

      <Col span={12} style={{ textAlign: 'center' }}>
        <h2>Quizzes / Conteudo</h2>
        {arrQuizzes.quizzesInfoDto && arrQuizzes.quizzesInfoDto.map(item => (
          <Card
            className={styles.card}
            hoverable
            style={{ width: '100%', marginTop: '3rem' }}
            bodyStyle={{ margin: 0, padding: 0 }}
            onClick={() => console.log('xxx')}
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
  )
}

export default connect(state => ({ data: state.data }))(Perfil);