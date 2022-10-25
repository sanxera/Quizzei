import React from 'react';
import { Button, Input, Row, Col, Tooltip, Checkbox, Divider, Form, Collapse } from 'antd';
import {
  DeleteOutlined
} from '@ant-design/icons';

const { Panel } = Collapse;

const StepQuestion = ({ data, form }) => {
  return (
    <Form form={form} initialValues={{ questions: data }} style={{ width: '100%' }}>
      <Form.List name="questions">
        {(questions, { add, remove }) => {
          return (
            <>
              <Divider>Questões</Divider>
              <Collapse defaultActiveKey={['1']}>
                {questions.map((question, index) => (
                  <Panel header={`Questão ${index + 1}`} key={index + 1}>
                    <div style={{ display: 'flex', flexDirection: 'column', width: '100%' }}>
                      <Row key={question.key} style={{ marginBottom: 20, borderBottom: '1px solid', padding: 10 }} justify='center'>
                        <Col span={24} style={{ display: 'flex', justifyContent: 'end' }}>
                          <Tooltip title="Deletar questão">
                            <Button
                              type='link'
                              icon={<DeleteOutlined />}
                              onClick={() => remove(question.name)}
                              style={{ color: 'red' }} />
                          </Tooltip>
                        </Col>

                        <Col span={24}>
                          <Form.Item
                            {...question}
                            name={[question.name, "description"]}
                            fieldKey={[question.fieldKey, 'description']}
                          >
                            <Input.TextArea placeholder='Digite a questão aqui!' />
                          </Form.Item>
                        </Col>
                        <Col span={22}>
                          <Form.List
                            // initialValues={{ options: item.questions.options || [] }}
                            name={[question.fieldKey, 'options']}>
                            {(options, { add: addOptions, remove: removeOptions }) => {
                              return (
                                <>
                                  <Divider>Respostas</Divider>
                                  {options.map((item, index) => (
                                    <Row key={item.key} style={{ marginBottom: 20 }}>
                                      <Col span={22}>
                                        <Form.Item
                                          {...item}
                                          name={[item.name, "description"]}
                                          fieldKey={[item.fieldKey, 'options']}
                                          key={index}
                                        >
                                          <Input placeholder='Digite a opção aqui!' />
                                        </Form.Item>
                                      </Col>
                                      <Col style={{ height: 50 }} span={1}>
                                        <Form.Item
                                          {...item}
                                          name={[item.name, 'isCorrect']}
                                          fieldKey={[item.fieldKey, 'isCorrect']}
                                          key={index}
                                          valuePropName="checked"
                                          initialValue={item?.isCorrect || false}
                                        >
                                          <div style={{ display: 'flex', justifyContent: 'center', backgroundColor: '#32CD80', height: '100%', alignItems: 'center' }}>
                                            <Checkbox />
                                          </div>
                                        </Form.Item>
                                      </Col>
                                      <Col span={1}>
                                        <Button
                                          type='primary'
                                          danger
                                          icon={<DeleteOutlined />}
                                          onClick={() => removeOptions(item.name)}
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
                    </div>
                  </Panel>
                ))}
              </Collapse >
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