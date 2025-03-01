/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Tabs, Form, Modal, Typography, Row, Col, Button as ButtonAntd, Upload, message, Divider } from 'antd';
import {
  InfoCircleOutlined,
  QuestionCircleOutlined,
  FileSearchOutlined,
  FileImageOutlined
} from '@ant-design/icons';
import { ListBullets, FilePdf } from 'phosphor-react';
import StepForm from './Items/StepForm';
import StepQuestion from './Items/StepQuestions';
import StepContent from './Items/StepContent';
import StepTheme from './Items/StepTheme';
import { Button } from '../../components/Button'
import { create, createQuestions, listQuestions, update } from '../../services/quiz';
import { list as listCategories } from '../../services/categories';
import { notification } from '../../utils/notification';

const { TabPane } = Tabs;
const { Text } = Typography;
const { Dragger } = Upload;

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env;

const ModalQuiz = ({ rowData = {}, onClose, onCallback, visible, dispatch, navigate }) => {
  const [form] = Form.useForm();
  const [activeKey, setActiveKey] = useState('1');
  const [categories, setCategories] = useState([]);
  const [questions, setQuestions] = useState([]);
  const [showQuestions, setShowQuestions] = useState(false);

  const textButton = rowData && rowData.quizInfoUuid ? 'Atualizar' : 'Criar';
  const titleModal = rowData && rowData.quizInfoUuid ? 'Editar quiz' : 'Criar novo quiz';

  useEffect(() => {
    loadQuestions();
    loadCategories();
  }, []);


  async function loadCategories() {
    const data = await listCategories();
    await setCategories(data.categories);
  }

  async function loadQuestions() {
    const { quizInfoUuid } = rowData;
    if (!quizInfoUuid) return;

    const response = await listQuestions(quizInfoUuid);
    setQuestions(response.questions);
  }

  function onCloseModal() {
    form.resetFields();
    onClose();
  }

  async function onSubmit() {
    let quizInfoUuid = rowData.quizInfoUuid;
    try {
      const { questions, ...restData } = await form.validateFields();
      const isExistUuid = rowData.quizInfoUuid ? true : false;
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

      notification({ status: 'success', message: !rowData.quizInfoUuid ? 'Quiz criado com sucesso!' : 'Quiz atualizado com sucesso!' });
      await onCallback();
      await onCloseModal();
    } catch (error) {
      console.log('error submit => ', error)
      if (error) notification({ status: 'error', message: 'Preencha as informações do quiz!' });
    }
  }

  async function onClickReportQuiz() {
    await dispatch({
      type: 'REPORT_QUIZ',
      data: {
        quizUuid: rowData.quizInfoUuid,
      },
    });

    await onCloseModal();
    await navigate('/report/quiz');
  }

  const props = {
    name: 'file',
    multiple: true,
    headers: {
      enctype: 'multipart/form-data',
    },
    action: `${REACT_APP_QUIZZEI_BACKEND_URL}api/files/read-pdf`,
    onChange: async info => {
      const { status, response } = info.file;
      if (status !== 'uploading') {
        console.log(info.file, info.fileList);
      }
      if (status === 'done') {
        const data = [];
        message.success(`${info.file.name} upload feito com sucesso`);
        await response.questions.forEach(async question => {
          await data.push({
            // questionUuid: question.questionUuid,
            description: question.questionDescription,
            options: question.options.map(option => {
              return {
                // optionUuid: option.optionUuid,
                description: option.optionDescription
              }
            })
          })
        })
        await setQuestions(data);

        setShowQuestions(true);
      } else if (status === 'error') {
        message.error(`${info.file.name} falha no upload.`);
      }
    },
  };

  const extraButton = rowData && rowData.quizInfoUuid ? <Button
    title="Ver relatório do quiz"
    onClick={onClickReportQuiz} n
  /> : <div />;

  return (
    <Modal
      title={<Text strong>{titleModal}</Text>}
      visible={visible}
      width={1000}
      bodyStyle={{ minHeight: 500 }}
      closable={false}
      footer={[
        extraButton,
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
          <StepForm
            form={form}
            data={rowData}
            categories={categories}
          />
        </TabPane>

        <TabPane
          tab={
            <>
              <FileImageOutlined />
              Temas
            </>
          }
          key="2">
          <StepTheme
            form={form}
            data={rowData}
          />
        </TabPane>

        <TabPane
          tab={
            <>
              <QuestionCircleOutlined />
              Perguntas e Respostas
            </>
          }
          key="3" >
          <>
            {!showQuestions && questions.length === 0 ? (
              <Row justify='center' style={{ marginTop: 50 }}>
                <Col>
                  <ButtonAntd
                    style={{ width: '50rem', minHeight: 100 }}
                    type='dashed'
                    onClick={async () => {
                      await loadQuestions();
                      setShowQuestions(true);
                    }}
                  >
                    <div>
                      <ListBullets size={35} />
                    </div>
                    <div>
                      Cadastrar manualmente
                    </div>
                  </ButtonAntd>
                </Col>
                <Divider style={{ width: '10rem' }}>Ou</Divider>
                <Col>
                  <div style={{ padding: 35, width: '55rem' }}>
                    <Dragger
                      listType='picture'
                      style={{ backgroundColor: '#FFFF' }}
                      maxCount={1}
                      {...props}
                    >
                      <p>
                        <FilePdf size={35} />
                      </p>
                      <p className="ant-upload-text">Fazer upload de arquivo .pdf</p>
                    </Dragger>
                  </div>
                </Col>
              </Row>
            ) : (
              <StepQuestion data={questions || []} form={form} />
            )}
          </>
        </TabPane>

        {rowData && rowData.quizInfoUuid && (
          <TabPane
            tab={
              <>
                <FileSearchOutlined />
                Conteúdo
              </>
            }
            key="4" >
            <StepContent data={rowData} />
          </TabPane>
        )}
      </Tabs>

      {/* {modalCategoryVisible && <ModalCategory visible={modalCategoryVisible} onAdd={onAddCategory} onClose={() => setModalCategoryVisible(false)} />} */}

    </Modal>
  )
}


export default connect(state => ({ ...state }))(ModalQuiz);