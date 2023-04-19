import React from 'react';
import { Row, Col, Card, Typography, Badge } from "antd";
import { PieChart } from 'react-minimal-pie-chart';
import { Check } from 'phosphor-react';

const { Title, Text } = Typography;


const ReportQuestions = ({ data }) => {
  return (
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
  )
}

export default ReportQuestions;