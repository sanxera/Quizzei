import React, { useEffect, useState } from 'react';
import { Tabs, Button, Form, Modal } from 'antd';
import StepForm from './Items/StepForm';
import StepQuestion from './Items/StepQuestions';
import StepContent from './Items/StepContent';
import {
  InfoCircleOutlined,
  QuestionCircleOutlined,
  FileSearchOutlined
} from '@ant-design/icons';
import { create, createQuestions, listQuestions } from '../../services/quiz';
import { notification } from '../../utils/notification';

const { TabPane } = Tabs;


const ModalQuiz = ({ data = {}, onClose, onCallback, visible }) => {
  const [form] = Form.useForm();
  const [activeKey, setActiveKey] = useState('1');
  const [questions, setQuestions] = useState([]);

  const textButton = data && data.quizInfoUuid ? 'Atualizar' : 'Criar';
  const titleModal = data && data.quizInfoUuid ? 'Editar quiz' : 'Criar novo quiz';

  useEffect(() => {
    handleQuestions();
  }, []);

  async function handleQuestions() {
    const { quizInfoUuid } = data;
    if (!quizInfoUuid) return;

    const response = await listQuestions(quizInfoUuid);
    setQuestions(response.questions);
  }

  function onCloseModal() {
    form.resetFields();
    onClose();
  }

  async function onSubmit() {
    try {
      const { questions, ...restData } = await form.validateFields();
      if (!restData) return;
      const { createdQuizUuid } = await create(restData);
      if (!createdQuizUuid) return notification({ status: 'error', message: 'Falha ao criar o quiz.' });

      if (!data.quizInfoUuid && questions && questions.length > 0) {
        await createQuestions(createdQuizUuid, { questions });
      }

      setTimeout(async () => {
        notification({ status: 'success', message: data.quizInfoUuid ? 'Quiz criado com sucesso!' : 'Quiz atualizado com sucesso!' });
        await onCallback();
        await onCloseModal();
      }, 1000)
    } catch (error) {
      console.log('error submit => ', error)
      if (error) notification({ status: 'error', message: 'Preencha as informações do quiz!' });
    }
  }

  return (
    <Modal
      title={titleModal}
      visible={visible}
      width={1000}
      closable
      footer={[
        <Button type="primary" danger onClick={async () => {
          await form.resetFields();
          setTimeout(async () => {
            await onCloseModal()
          }, 500)
        }}>Cancelar</Button>,
        <Button className='btn-main' type="primary" onClick={onSubmit}>{textButton}</Button>
      ]}
      destroyOnClose
      style={{ borderRadius: 20 }}
    >
      <Tabs
        defaultActiveKey={1}
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
          <StepQuestion data={questions || []} form={form} />
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