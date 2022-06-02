import React, { useState } from 'react';
import { Button, Input, Row, Col, Tooltip, Checkbox, Divider } from 'antd';
import {
  DeleteOutlined
} from '@ant-design/icons';

const StepQuestion = ({ data }) => {
  const [arrQuestions, setArrQuestion] = useState([{}]);
  const [arrAnswers, setArrAnswers] = useState([]);

  return (
    <>
      <Divider>Questões</Divider>
      {arrQuestions.map((item, index) => (
        <Row key={`questions-${index}`} style={{ marginBottom: 20, borderBottom: '1px solid', padding: 10 }} justify='center'>
          <Col span={24} style={{ display: 'flex', justifyContent: 'end' }}>
            <Tooltip title="Deletar questão">
              <Button
                type='link'
                icon={<DeleteOutlined />}
                onClick={() => {
                  console.log('slice ', index, arrQuestions);
                  arrQuestions.splice(index, 1);
                  console.log(arrQuestions);
                  setArrQuestion([...arrQuestions]);
                }}
                style={{ color: 'red' }} />
            </Tooltip>
          </Col>

          <Col span={24}>
            <Input.TextArea onChange={text => {
              console.log(text, item, index)
            }} placeholder='Digite a questão aqui!' />
          </Col>
          <Col span={22}>
            <Divider>Respostas</Divider>

            {/* {item.answers && item.answers.map((item, index) => ( */}
            {arrAnswers.map((item, index) => (
              <Row style={{ marginBottom: 20 }}>
                <Col span={22}>
                  <Input placeholder='Digite a opção aqui!' />
                </Col>
                <Col span={1}>
                  <div style={{ display: 'flex', justifyContent: 'center', backgroundColor: '#32CD80', height: '100%', alignItems: 'center' }}>
                    <Checkbox />
                  </div>
                </Col>
                <Col span={1}>
                  <Button
                    type='primary'
                    danger
                    icon={<DeleteOutlined />}
                    onClick={() => {
                      console.log('slice ', index, arrAnswers);
                      arrAnswers.splice(index, 1);
                      console.log(arrAnswers);
                      setArrAnswers([...arrAnswers]);
                    }}
                  />
                </Col>
              </Row>
            ))}
            <Button style={{ width: '100%', marginTop: 20 }} type="dashed" onClick={() => setArrAnswers([...arrAnswers, { description: '', answers: [] }])}>Adicionar resposta</Button>
          </Col>
        </Row >
      ))}

      <Button style={{ width: '100%', marginTop: 20 }} type="dashed" onClick={() => setArrQuestion([...arrQuestions, { description: '', answers: [] }])}>Adicionar pergunta</Button>
    </>
  )
}

export default StepQuestion;