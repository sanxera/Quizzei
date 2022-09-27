import React, { useEffect, useState } from 'react';
import { Row, Col, Avatar, Typography, Rate, Card } from 'antd';
// import Card from '../../components/Card';
import styles from './styles.less';
import { getPerfil, listQuizzesByPerfil } from '../../services/perfil';

const { Title, Text } = Typography;

export function Perfil() {
  const [arrQuizzes, setArrQuizzes] = useState([]);
  const [perfil, setPerfil] = useState({});

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const perfilData = await getPerfil();
    const quizzes = await listQuizzesByPerfil();

    setPerfil(perfilData);
    setArrQuizzes(quizzes);
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
              <Title className={styles.text} level={4}>{perfil.name}</Title>
              <Text className={styles.text}>{perfil.description}</Text>
            </Col>

            <Col style={{ marginTop: '5rem' }}>
              <Rate disabled defaultValue={perfil.rating} />
            </Col>
          </Row>
        </Card>
      </Col>

      <Col span={12} style={{ textAlign: 'center' }}>
        <h2>Quizzes / Conteudo</h2>
        {arrQuizzes.map(item => (
          <Card className={styles.card} onClick={() => console.log('xxx')} hoverable style={{ width: '100%', marginTop: '3rem' }} bodyStyle={{ margin: 0, padding: 0 }} height="50rem">
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