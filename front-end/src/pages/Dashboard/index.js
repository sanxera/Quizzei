import { useEffect, useState } from 'react';
import { Timeline, Row, Col, Calendar, Typography, PageHeader, Progress, Tooltip, Button as ButtonAntd } from 'antd';
import { ChatCenteredText, User, LineSegment } from 'phosphor-react'
import { historyQuiz } from '../../services/quiz';
import { getUser } from '../../services/session';

const { Title, Text } = Typography;

const Dashboard = () => {
  const [history, setHistory] = useState({});
  const [currentUser, setCurrentUser] = useState({});

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const data = await historyQuiz();
    const user = await getUser();
    setHistory(data);
    setCurrentUser(user);
  }

  async function onPanelChange(value, mode) {
    console.log(value.format('YYYY-MM-DD'), mode);
  };

  return (
    <div>
      <PageHeader
        className="site-page-header"
        title="Bem Vindo!"
        subTitle={currentUser.nickName || ''}
      />

      <Row style={{ marginTop: 5, marginLeft: 10 }} gutter={2}>
        <Col span={15} style={{ backgroundColor: '#FFFF', paddingBottom: 50, borderRadius: 15, padding: 20, boxShadow: '0 3px 10px rgb(0 0 0 / 0.2)' }}>
          <Title level={2}>Quizzes recente</Title>
          {history.quizzesHistoryInformation && history.quizzesHistoryInformation.length > 0 ? (
            <Timeline style={{ marginLeft: 20 }}>
              {history.quizzesHistoryInformation && history.quizzesHistoryInformation.length > 0 && history?.quizzesHistoryInformation.map((item, index) => (
                <Timeline.Item key={`history-recent-quizzes-${index}`}>
                  <div style={{ display: 'flex', justifyContent: 'space-between', width: '100%', padding: 30, borderRadius: 10, border: '1px solid', paddingBottom: 10 }}>
                    <div>
                      <div style={{ display: 'flex', flexDirection: 'column' }}>
                        <Text style={{ fontSize: 15 }} strong>
                          {item.title}
                        </Text>
                        <Text>
                          {item.description}
                        </Text>
                      </div>

                      <div style={{ display: 'flex', marginTop: 20, marginBottom: 0, padding: 0 }}>

                        <div style={{ display: 'flex', alignItems: 'center' }}>
                          <LineSegment size={17} style={{ marginRight: 3 }} /> <Text>{item.categoryDescription}</Text>
                        </div>

                        <div style={{ display: 'flex', alignItems: 'center', marginLeft: 25 }}>
                          <ChatCenteredText size={17} style={{ marginRight: 3 }} /> <Text>{item.numberOfQuestions}</Text>
                        </div>

                        <div style={{ display: 'flex', alignItems: 'center', marginLeft: 25 }}>
                          <User size={17} style={{ marginRight: 3 }} /> <Text>{item.ownerNickName}</Text>
                        </div>
                      </div>
                    </div>

                    <div style={{ marginRight: 25 }}>
                      <Tooltip title={`Questões acertadas: ${item.correctAnswers}`}>
                        <Progress
                          width={80}
                          type='circle'
                          percent={(item.correctAnswers * 100) / item.numberOfQuestions}
                        />
                      </Tooltip>
                    </div>
                  </div>
                </Timeline.Item>
              ))
              }
            </Timeline>
          ) : (
            <ButtonAntd style={{ width: '100%', minHeight: 100 }} type='dashed'>Não há atividades</ButtonAntd>
          )}
        </Col>

        <Col span={7} style={{ marginLeft: 50, backgroundColor: '#FFFF', paddingBottom: 50, borderRadius: 15, padding: 20, boxShadow: '0 3px 10px rgb(0 0 0 / 0.2)' }}>
          <Title level={2}>Calendário de atividades</Title>
          <Calendar style={{ borderBottom: '1px solid' }} fullscreen={false} onPanelChange={onPanelChange} headerRender={null} />
        </Col>
      </Row >
    </div >

  )
}

export default Dashboard;