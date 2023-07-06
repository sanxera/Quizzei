import React from 'react';
import { Row, Col, Card, Typography, Collapse, Divider } from "antd";

const { Panel } = Collapse;
const { Text } = Typography;


const ReportQuestionsCategory = ({ data }) => {
  console.log("🚀  ~ file: ReportQuestionsCategory.js:13 ~ ReportQuestionsCategory ~ data:", data)

  return (
    <Col span={24}>
      <Card style={{ width: '100%' }}>
        {data.questionsCategories && (
          <Collapse defaultActiveKey={['1']}>
            {data?.questionsCategories.map(category => {
              return (
                <Panel header={`${category?.questionCategoryDescription}`}>
                  <Row>
                    <Col span={24}>
                      <Card style={{ width: '100%', textAlign: 'center' }}>
                        <Row type="flex" justify='center'>
                          <Col span={5}>
                            <strong>{category.totalQuestions}</strong> <br /> <strong>Questões</strong>
                          </Col>

                          <Col>
                            <Divider style={{ height: '100%' }} type="vertical" />
                          </Col>

                          <Col span={5}>
                            <strong>{category.totalHitPercentage}%</strong> <br /> <strong>Acertos</strong>
                          </Col>

                          <Col>
                            <Divider style={{ height: '100%' }} type="vertical" />
                          </Col>


                        </Row>
                      </Card>
                    </Col>

                    <Col span={24}>
                      <Collapse defaultActiveKey={['1']} ghost>
                        {category?.questions.length > 0 && category.questions.map(question => {
                          const totalSeconds = question?.averageTimer || 0;

                          const hours = Math.floor(totalSeconds / 3600);
                          const minutes = Math.floor((totalSeconds / 3600) / 60);
                          const seconds = totalSeconds % 60;
                          return (
                            <Panel
                              header={
                                <Text ellipsis={{ rows: 1 }}>{question.description}</Text>
                              }
                            >
                              <Row type="flex" justify='start'>
                                <Col span={5}>
                                  <Card style={{ width: '100%', textAlign: 'center' }}>
                                    <strong>{question.totalAnswers}</strong> <br /> <strong>Total de respostas</strong>
                                  </Card>
                                </Col>

                                <Col span={5}>
                                  <Card style={{ width: '100%', textAlign: 'center' }}>
                                    <strong>{question.totalHitPercentage}%</strong> <br /> <strong>Acertos</strong>
                                  </Card>
                                </Col>
                                <Col span={5}>
                                  <Card style={{ width: '100%', textAlign: 'center' }}>
                                    <strong>{hours.toString().padStart(2, '0')}:{minutes.toString().padStart(2, '0')}:{seconds.toString().padStart(2, '0')}</strong> <br /> <strong>Tempo médio</strong>
                                  </Card>
                                </Col>
                              </Row>

                              <Row type="flex" justify='start' style={{ marginTop: 10 }}>
                                <Col span={24}>
                                  <Text strong>Opções</Text>
                                </Col>
                                <Col span={24}>
                                  <div style={{ display: 'flex', flexDirection: 'column', marginLeft: 20 }}>
                                    {question.options.map((option, index) => {
                                      const code = 'a'.charCodeAt(0);
                                      const letterOption = String.fromCharCode(code + index);
                                      const typeCheck = option.isCorrect === true ? 'success' : 'danger';
                                      return (
                                        <div className={option.userCheck === true ? `question-option-check-${typeCheck}` : null}>
                                          <Text
                                            type={typeCheck}
                                          >
                                            {letterOption.toUpperCase()}. {option.description} ({option.totalOptionAnswersPercentage}%)
                                          </Text>
                                        </div>
                                      )
                                    })}
                                  </div>
                                </Col>
                              </Row>

                              <Divider />
                            </Panel>
                          )
                        })}
                      </Collapse>
                    </Col>
                  </Row>

                </Panel>
              )
            })}
          </Collapse>
        )}
      </Card>
    </Col >
  )
}

export default ReportQuestionsCategory;