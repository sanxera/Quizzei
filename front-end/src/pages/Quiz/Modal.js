import React, { useEffect, useState } from 'react';
import { Tabs, Form, Modal, Typography } from 'antd';
import StepForm from './Items/StepForm';
import StepQuestion from './Items/StepQuestions';
import StepContent from './Items/StepContent';
import {
  InfoCircleOutlined,
  QuestionCircleOutlined,
  FileSearchOutlined
} from '@ant-design/icons';
import { Button } from '../../components/Button'
import { create, createQuestions, listQuestions, update } from '../../services/quiz';
import { create as createCategory, list as listCategories } from '../../services/categories';
import { notification } from '../../utils/notification';
import { ModalCategory } from './ModalCategory';

const { TabPane } = Tabs;
const { Text } = Typography;


const ModalQuiz = ({ data = {}, onClose, onCallback, visible }) => {
  const [form] = Form.useForm();
  const [activeKey, setActiveKey] = useState('1');
  const [categories, setCategories] = useState([]);
  const [questions, setQuestions] = useState([]);
  const [modalCategoryVisible, setModalCategoryVisible] = useState(false);

  const textButton = data && data.quizInfoUuid ? 'Atualizar' : 'Criar';
  const titleModal = data && data.quizInfoUuid ? 'Editar quiz' : 'Criar novo quiz';

  useEffect(() => {
    handleQuestions();
    loadCategories();
  }, []);


  async function loadCategories() {
    const data = await listCategories();
    await setCategories(data.categories);
  }

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
    let quizInfoUuid = data.quizInfoUuid;
    try {
      const { questions, ...restData } = await form.validateFields();
      const isExistUuid = data.quizInfoUuid ? true : false;
      if (!restData) return;
      switch (isExistUuid) {
        default:
          const { status } = await update({ quizInfoUuid, ...restData });
          if (status !== 'OK') return notification({ status: 'error', message: 'Erro ao atualizar o quiz.' })
          break;
        case false:
          const { createdQuizUuid } = await create(restData);
          quizInfoUuid = createdQuizUuid;
          if (!createdQuizUuid) return notification({ status: 'error', message: 'Falha ao criar o quiz.' });
          break;

      }
      if (questions && questions.length > 0) {
        await createQuestions(quizInfoUuid, { questions });
      }

      notification({ status: 'success', message: !data.quizInfoUuid ? 'Quiz criado com sucesso!' : 'Quiz atualizado com sucesso!' });
      await onCallback();
      await onCloseModal();
    } catch (error) {
      console.log('error submit => ', error)
      if (error) notification({ status: 'error', message: 'Preencha as informações do quiz!' });
    }
  }

  function showModalCategory() {
    setModalCategoryVisible(true);
  }

  async function onAddCategory(categoryName) {
    if (!categoryName || (categoryName || "").length === 0) return;
    const response = await createCategory(categoryName);
    if (!response.createdId) return;

    await loadCategories();
    setModalCategoryVisible(false);
  }

  return (
    <Modal
      title={<Text strong>{titleModal}</Text>}
      visible={visible}
      width={1000}
      bodyStyle={{ minHeight: 500 }}
      closable={false}
      footer={[
        <Button
          title="Cancelar"
          danger
          onClick={async () => {
            await form.resetFields();
            await onCloseModal();
          }}
        />,
        <Button
          title={textButton}
          type="primary"
          onClick={onSubmit}
        />
      ]}
      destroyOnClose
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
          <StepForm form={form} data={data} showModalCategory={showModalCategory} categories={categories} />
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

      {modalCategoryVisible && <ModalCategory visible={modalCategoryVisible} onAdd={onAddCategory} onClose={() => setModalCategoryVisible(false)} />}

    </Modal>
  )
}


export default ModalQuiz;