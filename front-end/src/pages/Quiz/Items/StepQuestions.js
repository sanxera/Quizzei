import React from 'react';
import { Button, Tooltip, Divider, Form, Collapse } from 'antd';
import { Trash } from 'phosphor-react'

import './index.less';
import StepQuestionsPanel from './StepItems/StepQuestionsPanel';

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
                    <StepQuestionsPanel index={index} question={question} data={data} form={form} />
                  </Panel>
                )
                )}
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