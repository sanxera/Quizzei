import { useEffect, useState } from 'react';
import { Timeline, Row, Col, Calendar, Typography, PageHeader, Progress, Tooltip } from 'antd';
import { ChatCenteredText, CircleWavyCheck, User, LineSegment } from 'phosphor-react'
import { historyQuiz } from '../../services/quiz';

const { Title, Text } = Typography;

const Dashboard = () => {
  const [history, setHistory] = useState({});

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const data = await historyQuiz();
    setHistory(data);
  }

  async function onPanelChange(value, mode) {
    console.log(value.format('YYYY-MM-DD'), mode);
  };

  return (
    <div>
      <PageHeader
        className="site-page-header"
        title="Bem Vindo!"
        subTitle="dashboard"
      />

      <Row style={{ marginTop: 100, marginLeft: 50 }} gutter={20}>
        <Col span={16}>
          <Title level={2}>Quizzes recente</Title>
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
                      // status={percent < 50 ? 'exception' : 'success'} 
                      // success={{ percent: 50 }}
                      />
                    </Tooltip>
                  </div>
                </div>
              </Timeline.Item>
            ))
            }
          </Timeline>
        </Col>

        <Col span={6} style={{ marginLeft: 50 }}>
          <Calendar style={{ borderBottom: '1px solid' }} fullscreen={false} onPanelChange={onPanelChange} />
        </Col>
      </Row >
    </div >

  )
}

export default Dashboard;