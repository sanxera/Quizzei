import React from 'react';
import { Button, Input, Row, Col, Tooltip, Checkbox, Divider, Form, Collapse } from 'antd';
import { Trash } from 'phosphor-react'

const { Panel } = Collapse;

const ACTIONS = {
  CREATE: 0,
  UPDATE: 1,
  REMOVE: 2,
}

const genExtra = (index, form) => (
  <Tooltip title="Deletar questão">
    <Button
      type='link'
      icon={<Trash size={20} />}
      onClick={async () => {
        const { questions } = await form.getFieldsValue();
        const action = questions[index].action === 2 ? ACTIONS['UPDATE'] : ACTIONS['REMOVE'];
        questions[index].action = action;
        await form.setFieldsValue({ questions })
      }}
      style={{ color: 'red' }} />
  </Tooltip>
);

const StepQuestion = ({ data, form }) => {

  return (
    <Form form={form} initialValues={{ questions: data }} style={{ width: '100%' }}>
      <Form.List name="questions">
        {(questions, { add }) => {
          return (
            <>
              <Divider>Questões</Divider>
              <Collapse defaultActiveKey={['1']}>
                {questions.map((question, index) => (
                  <Panel forceRender header={`Questão ${index + 1}`} key={index + 1} extra={genExtra(index, form)}>
                    <div style={{ display: 'flex', flexDirection: 'column', width: '100%' }}>
                      <Row key={question.key} style={{ marginBottom: 20, borderBottom: '1px solid', padding: 10 }} justify='center'>
                        <Form.Item
                          {...question}
                          initialValue={data[index] && data[index].questionUuid ? ACTIONS['UPDATE'] : ACTIONS['CREATE']}
                          name={[question.name, "action"]}
                          fieldKey={[question.fieldKey, 'action']}
                        >
                          <Input hidden />
                        </Form.Item>

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
                            name={[question.fieldKey, 'options']}>
                            {(options, { add: addOptions, remove: removeOptions }) => (
                              <>
                                <Divider>Respostas</Divider>
                                {options.map((item, index) => (
                                  <Row key={item.key} style={{ marginBottom: 20 }}>
                                    <Form.Item
                                      {...item}
                                      initialValue={data[question.fieldKey] && data[question.fieldKey]?.options[index] && data[question.fieldKey]?.options[index].optionUuid ? ACTIONS['UPDATE'] : ACTIONS['CREATE']}
                                      name={[item.name, "action"]}
                                      fieldKey={[item.fieldKey, 'action']}
                                    >
                                      <Input hidden />
                                    </Form.Item>
                                    <Col span={22}>
                                      <Form.Item
                                        {...item}
                                        name={[item.name, "description"]}
                                        fieldKey={[item.fieldKey, 'options']}
                                        key={index}
                                      >
                                        <Input disabled={form.getFieldsValue().questions && form.getFieldsValue().questions[question.fieldKey]?.options[index] && form.getFieldsValue().questions[question.fieldKey]?.options[index].action === 2} placeholder='Digite a opção aqui!' />
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
                                        icon={<Trash size={23} />}
                                        onClick={async () => {
                                          const { questions } = await form.getFieldsValue();
                                          const action = questions[question.fieldKey].options[index].action === 2 ? ACTIONS['UPDATE'] : ACTIONS['REMOVE'];
                                          questions[question.fieldKey].options[index].action = action;
                                          await form.setFieldsValue({ questions })
                                        }}
                                      />
                                    </Col>
                                  </Row>
                                ))}
                                <Button style={{ width: '100%', marginTop: 20 }} type="dashed"
                                  onClick={() => addOptions()}
                                >Adicionar resposta</Button>
                              </>
                            )}
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