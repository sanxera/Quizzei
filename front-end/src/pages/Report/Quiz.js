import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { PageHeader, Row, Col, Card, Radio, Typography, Badge, Divider } from "antd";
import { PieChart } from 'react-minimal-pie-chart';
import { getReport } from '../../services/report';
import { Check } from 'phosphor-react';

const { Title, Text } = Typography;

const ReportQuiz = ({ data: { quizUuid } }) => {
  const [data, setData] = useState({});

  useEffect(() => {
    async function loadData() {
      const data = await getReport(quizUuid);
      setData(data);
    }

    loadData();
  }, [])

  if (!data.quizUuid) return <div />;

  return (
    <PageHeader
      onBack={() => null}
      title={data.quizDescription}
    >
      <Row type="flex">
        <Col span={24}>
          <Card style={{ width: '100%', textAlign: 'center' }}>
            <Row type="flex" justify='center'>
              <Col span={5}>
                <strong>{data.totalQuestions}</strong> <br /> <strong>Questões</strong>
              </Col>

              <Divider type="vertical" />

              <Col span={5}>
                <strong>{data.totalCompletedQuiz}</strong> <br /> <strong>Finalizados</strong>
              </Col>

              <Divider type="vertical" />
              <Col span={5}>
                <strong>{data.totalNotCompletedQuiz}</strong> <br /> <strong>Não finalizados</strong>
              </Col>
            </Row>
          </Card>
        </Col>

        <Radio.Group style={{ margin: '20px 0px 20px 0px' }} onChange={() => console.log('x')} defaultValue="1">
          <Radio.Button value="1">Por questões</Radio.Button>
          <Radio.Button value="2">Por alunos</Radio.Button>
        </Radio.Group>
      </Row>



      <Col span={24}>
        {data.questions && data.questions.length > 0 && data.questions.map((question, index) => {
          let graphData = {};
          graphData = question.options.map(item => {
            const color = `#${Math.floor(Math.random() * 16777215).toString(16)}`;
            return { title: `Total de respostas da questão ${index + 1}: ${item.totalOptionAnswers}`, value: item.totalOptionAnswers, color }
          })

          return (
            <Card style={{ width: '100%' }}>
              <Row>
                <>
                  <Col span={15}>
                    <Title level={5}>{index + 1}. {question.description}</Title>
                    <Text style={{ margin: '70px 0px 0px 20px' }} type="secondary">{question.totalHitPercentage}% das pessoas que responderam o questão acertaram</Text>

                    <div style={{ marginLeft: 20, display: 'flex', flexDirection: 'column' }}>
                      {question.options && question.options.map((item, indexOptions) => (
                        <div style={{ alignItems: 'inherit' }}>
                          <Badge color={graphData[indexOptions].color} text={`${item.description} (${item.hitPercentage}%) `} />
                          {item.isCorrect ? <Check color='green' /> : <div />}
                        </div>
                      ))}
                    </div>
                  </Col>

                  <Col style={{ textAlign: 'center' }} span={9}>
                    <Text>Total de respostas por opções:</Text>
                    <PieChart
                      lineWidth={50}
                      style={{ height: 125, marginTop: 15 }}
                      data={graphData}
                    />
                  </Col>
                </>
              </Row>
            </Card>
          )
        })}
      </Col>
    </PageHeader>
  )
}

export default connect(state => ({ data: state.data }))(ReportQuiz);