import React from 'react';
import { Row, Col, Card, Typography, Badge } from "antd";
import { PieChart } from 'react-minimal-pie-chart';
import { Pie } from '@ant-design/plots';
import { Check } from 'phosphor-react';

const { Title, Text } = Typography;


const ReportQuestions = ({ data }) => {
  return (
    <Col span={24}>
      {data.questions && data.questions.length > 0 && data.questions.map((question, index) => {
        const graphData = [];
        question.options.map((item, index) => {
          if (item.totalOptionAnswers <= 0) return;
          graphData.push({ type: `Opção ${index + 1}`, value: item.totalOptionAnswers });
        });

        const config = {
          appendPadding: 8,
          data: graphData,
          angleField: 'value',
          colorField: 'type',
          radius: 0.8,
          legend: {
            layout: 'horizontal',
            position: 'bottom'
          },
          label: {
            type: 'inner',
          },
          interactions: [
            {
              type: 'element-active',
            },
          ],
        };

        return (
          <Card style={{ width: '100%' }}>
            <Row>
              <Col span={15}>
                <Title level={5}>{index + 1}. {question.description}</Title>
                <Text style={{ margin: '70px 0px 0px 20px' }} type="secondary">{question.totalHitPercentage}% das pessoas que responderam o questão acertaram</Text>

                <div style={{ marginLeft: 20, display: 'flex', flexDirection: 'column' }}>
                  {question.options && question.options.map((item, indexOptions) => (
                    <div style={{ alignItems: 'inherit' }}>
                      <Text>{indexOptions + 1}. {item.description} ({item.totalOptionAnswersPercentage}%)</Text>
                      {item.isCorrect ? <Check color='green' /> : <div />}
                    </div>
                  ))}
                </div>
              </Col>

              <Col style={{ textAlign: 'center' }} span={9}>
                <Text>Total de respostas: {question.totalAnswers}</Text>
                <Pie style={{ height: 200 }} {...config} />
              </Col>
            </Row>
          </Card>
        )
      })}
    </Col>
  )
}

export default ReportQuestions;