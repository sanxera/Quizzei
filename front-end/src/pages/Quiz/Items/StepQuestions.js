import React from 'react';
import { Button, Tooltip, Divider, Form, Collapse, message } from 'antd';
import { Trash } from 'phosphor-react'

import './index.less';
import StepQuestionsPanel from './StepItems/StepQuestionsPanel';

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env;
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

const props = {
  name: 'file',
  multiple: true,
  headers: {
    enctype: 'multipart/form-data',
  },
  action: `${REACT_APP_QUIZZEI_BACKEND_URL}api/files/upload-image`,
  onChange(info) {
    console.log("🚀  ~ file: StepQuestions.js:40 ~ onChange ~ info:", info)
    const { status } = info.file;
    if (status !== 'uploading') {
      console.log(info.file, info.fileList);
    }
    if (status === 'done') {
      message.success(`${info.file.name} upload feito com sucesso`);
    } else if (status === 'error') {
      message.error(`${info.file.name} falha no upload.`);
    }
  },
};

const StepQuestion = ({ data, form }) => {

  async function onChangeUpload(file, questionInfo) {
    console.log("🚀  ~ file: StepQuestions.js:34 ~ onChangeUpload ~ file:", file)
    const { fieldKey: questionKey } = questionInfo;
    // console.log("🚀  ~ file: StepQuestions.js:34 ~ onChangeUpload ~ file:", file)
    const { questions } = form.getFieldsValue();
    const changeQuestion = questions[questionKey];
    changeQuestion.image = file.file.thumbUrl

    form.setFieldsValue({
      questions: [...questions, changeQuestion]
    })
  }

  return (
    <Form form={form} initialValues={{ questions: data }} style={{ width: '100%' }}>
      <Form.List name="questions">
        {(questions, { add }) => {
          return (
            <>
              <Divider>Questões</Divider>
              <Collapse defaultActiveKey={['1']}>
                {questions.map((question, index) => {
                  console.log("🚀  ~ file: StepQuestions.js:77 ~ {questions.map ~ index:", index)
                  return (
                    <Panel forceRender header={`Questão ${index + 1}`} key={index + 1} extra={genExtra(index, form)}>
                      <StepQuestionsPanel index={index} question={question} data={data} form={form} />
                    </Panel>
                  )
                })}
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