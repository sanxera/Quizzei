import React, { useState } from 'react';
import { Tabs, Button, Form, Modal } from 'antd';
import { useDispatch } from 'react-redux';
import StepForm from './Items/StepForm';
import StepQuestion from './Items/StepQuestions';
import StepContent from './Items/StepContent';
import {
  InfoCircleOutlined,
  QuestionCircleOutlined,
  FileSearchOutlined
} from '@ant-design/icons';

const { TabPane } = Tabs;

const ModalQuiz = ({ data, onClose, visible }) => {
  const dispatch = useDispatch();
  const [form] = Form.useForm();
  const [activeKey, setActiveKey] = useState('1');

  const textButton = data ? 'Atualizar' : 'Criar';
  const titleModal = data ? 'Editar quiz' : 'Criar novo quiz';

  function onCloseModal() {
    form.resetFields();
    onClose();
  }

  function onSubmit() {
    console.log(form.getFieldsValue())
    dispatch({ type: 'quiz/create' })
  }

  return (
    <Modal
      title={titleModal}
      visible={visible}
      width={1000}
      closable={false}
      footer={[
        <Button type="primary" shape='round' danger onClick={() => onCloseModal()}>Cancelar</Button>,
        <Button type="primary" shape='round' onClick={onSubmit}>{textButton}</Button>
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
          <StepQuestion form={form} />
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