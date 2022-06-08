import React from 'react';
import { Button, Input, Row, Col, Tooltip, Checkbox, Divider, Form } from 'antd';
import {
  DeleteOutlined
} from '@ant-design/icons';

const StepQuestion = ({ data: fakeData, form }) => {
  return (
    <Form form={form} initialValues={{ questions: fakeData }} style={{ width: '100%' }}>
      <Form.List name="questions">
        {(questions, { add, remove }) => {
          return (
            <>
              <Divider>Questões</Divider>
              {questions.map((item, indexQuestions) => (
                <Row key={`questions-${indexQuestions}`} style={{ marginBottom: 20, borderBottom: '1px solid', padding: 10 }} justify='center'>
                  <Col span={24} style={{ display: 'flex', justifyContent: 'end' }}>
                    <Tooltip title="Deletar questão">
                      <Button
                        type='link'
                        icon={<DeleteOutlined />}
                        onClick={() => remove(item.question)}
                        style={{ color: 'red' }} />
                    </Tooltip>
                  </Col>

                  <Col span={24}>
                    <Form.Item
                      name={[indexQuestions, "description"]}
                    >
                      <Input.TextArea placeholder='Digite a questão aqui!' />
                    </Form.Item>
                  </Col>
                  <Col span={22}>
                    <Form.List name={[item.answers, 'options']}>
                      {(options, { add: addOptions, remove: removeOptions }) => {
                        return (
                          <>
                            <Divider>Respostas</Divider>
                            {options.map((item) => (
                              <Row key={item.key} style={{ marginBottom: 20 }}>
                                <Col span={22}>
                                  <Form.Item fieldKey={[item.fieldKey, 'answer']} name={[item.description, "description"]}>
                                    <Input placeholder='Digite a opção aqui!' />
                                  </Form.Item>
                                </Col>
                                <Col span={1}>
                                  <Form.Item name={[item.isCorrect, 'isCorrect']}>
                                    <div style={{ display: 'flex', justifyContent: 'center', backgroundColor: '#32CD80', height: '100%', alignItems: 'center' }}>
                                      <Checkbox defaultChecked={item.isCorrect} />
                                    </div>
                                  </Form.Item>
                                </Col>
                                <Col span={1}>
                                  <Button
                                    type='primary'
                                    danger
                                    icon={<DeleteOutlined />}
                                    onClick={() => removeOptions()}
                                  />
                                </Col>
                              </Row>
                            ))}
                            <Button style={{ width: '100%', marginTop: 20 }} type="dashed"
                              onClick={() => addOptions()}
                            >Adicionar resposta</Button>
                          </>
                        )
                      }}
                    </Form.List>
                  </Col>
                </Row >
              ))
              }

              <Button style={{ width: '100%', marginTop: 20 }} type="dashed" onClick={() => add()}>Adicionar pergunta</Button>
            </>
          )
        }
        }
      </Form.List>
    </Form>
  )
}

export default StepQuestion;