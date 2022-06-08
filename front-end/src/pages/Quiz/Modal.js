import React, { useState } from 'react';
import { Tabs, Button, Form, Modal } from 'antd';
import StepForm from './Items/StepForm';
import StepQuestion from './Items/StepQuestions';
import StepContent from './Items/StepContent';
import {
  InfoCircleOutlined,
  QuestionCircleOutlined,
  FileSearchOutlined
} from '@ant-design/icons';
import { create, createQuestions } from '../../services/quiz';
import { notification } from '../../utils/notification';

const { TabPane } = Tabs;

const fakeData = [
  {
    description: 'Questão 1',
    answers: [
      {
        description: 'Resposta 1',
        isCorrect: false
      },
      {
        description: 'Resposta 2',
        isCorrect: false
      },
      {
        description: 'Resposta 3',
        isCorrect: false
      },
      {
        description: 'Resposta 4',
        isCorrect: false
      },
      {
        description: 'Resposta 5',
        isCorrect: true
      },
    ]
  },
  {
    description: 'Questão 2',
    answers: [
      {
        description: 'Resposta 1',
        isCorrect: false
      },
      {
        description: 'Resposta 2',
        isCorrect: false
      },
      {
        description: 'Resposta 3',
        isCorrect: false
      },
      {
        description: 'Resposta 4',
        isCorrect: false
      },
      {
        description: 'Resposta 5',
        isCorrect: true
      },
    ]
  },
]

const ModalQuiz = ({ data, onClose, onCallback, visible }) => {
  const [form] = Form.useForm();
  const [activeKey, setActiveKey] = useState('1');

  const textButton = data ? 'Atualizar' : 'Criar';
  const titleModal = data ? 'Editar quiz' : 'Criar novo quiz';

  function onCloseModal() {
    form.resetFields();
    onClose();
  }

  async function onSubmit() {
    try {
      const { questions, ...data } = await form.validateFields();
      if (!data) return;
      const { createdQuizUuid } = await create(data);
      if (!createdQuizUuid) return notification({ status: 'error', message: 'Falha ao criar o quiz.' });

      if (questions && questions.length > 0) {
        await createQuestions(createdQuizUuid, { questions });
      }

      setTimeout(async () => {
        notification({ status: 'success', message: 'Quiz criado com sucesso!' });
        await onCallback();
        await onCloseModal();
      }, 2000)
    } catch (error) {
      if (error) notification({ status: 'error', message: 'Preencha as informações do quiz!' });
    }
  }

  return (
    <Modal
      title={titleModal}
      visible={visible}
      width={1000}
      closable={false}
      footer={[
        <Button type="primary" shape='round' danger onClick={() => onCloseModal()}>Cancelar</Button>,
        <Button className='btn-main' type="primary" shape='round' onClick={onSubmit}>{textButton}</Button>
      ]}
      destroyOnClose={true}
      style={{ borderRadius: 20 }}
    >
      <Tabs
        activeKey={activeKey}
        onTabClick={key => setActiveKey(key)}
      >
        <TabPane
          tab={
            <>
              <InfoCircleOutlined />
              Informações
            </>
          }
          key="1">
          <StepForm form={form} data={data} />
        </TabPane>

        <TabPane
          tab={
            <>
              <QuestionCircleOutlined />
              Perguntas e Respostas
            </>
          }
          key="2" >
          <StepQuestion data={fakeData} form={form} />
        </TabPane>

        <TabPane
          tab={
            <>
              <FileSearchOutlined />
              Conteúdo
            </>
          }
          key="3" >
          <StepContent form={form} />
        </TabPane>
      </Tabs>
    </Modal>
  )
}


export default ModalQuiz;