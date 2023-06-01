/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect, useRef, useState } from 'react';
import { Button, Input, Row, Col, Checkbox, Divider, Form, Upload, Spin, Select, Space, Tooltip } from 'antd';
import { PlusOutlined, QuestionCircleOutlined } from '@ant-design/icons';
import { Trash } from 'phosphor-react'
import { notification } from '../../../../utils/notification';

import '../index.less';
import { createQuestionCategory, getQuestionCategories } from '../../../../services/quiz';

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env;

const ACTIONS = {
  CREATE: 0,
  UPDATE: 1,
  REMOVE: 2,
}


const StepQuestionsPanel = ({ index, question, data, form }) => {
  const [loading, setLoading] = useState(false);
  const [images, setImages] = useState([]);
  const [categories, setCategories] = useState([]);
  const [categoryName, setCategoryName] = useState('');

  const inputTagRef = useRef(null);

  useEffect(() => {
    async function loadListImages() {
      if (!data[question.key]?.images || data[question.key]?.images.length === 0) return;
      const images = await data[question.key]?.images.map((image, index) => ({ uid: index, status: 'done', name: image.imageName, url: image.imageUrl }))
      setLoading(true);
      setImages(images);
      setLoading(false);
    }

    loadQuestionCategories();
    loadListImages();
  }, [])

  async function loadQuestionCategories() {
    const categories = await getQuestionCategories();
    setCategories(categories.questionCategories)
  }

  function onChangeUpload(info, questionInfo) {
    const { status, response } = info.file;
    const { fieldKey: questionKey } = questionInfo;
    const { questions } = form.getFieldsValue();

    if (status === 'removed') {
      questions[questionKey].images = []
      form.setFieldsValue({
        questions: [...questions]
      })

      setImages([]);
      // return;
    }

    if (status === 'done') {
      questions[questionKey].images = [];
      questions[questionKey].images.push({
        questionImageUuid: response.questionImageUuid,
        imageName: response.imageName,
        imageUrl: response.imageUrl
      })

      form.setFieldsValue({
        questions: [...questions]
      })

      images.push({
        uid: response.questionImageUuid,
        status: 'done',
        name: response.imageName,
        url: response.imageUrl
      })
      setLoading(true);
      setImages(images);
      setLoading(false);
    }
  }

  async function onCreateCategory(e, question) {
    const { fieldKey: questionKey } = question;
    const { questions } = form.getFieldsValue();

    e.preventDefault();
    if (!categoryName) {
      notification({ status: 'error', message: 'O nome da TAG deve ser informado antes de adicionar' });
      return;
    }

    const response = await createQuestionCategory(categoryName);
    setCategoryName('');

    questions[questionKey].questionCategoryId = response.createdId;
    await form.setFieldsValue({
      questions: [...questions]
    })

    loadQuestionCategories();
    setTimeout(() => {
      inputTagRef.current?.focus();
    }, 0);
  }

  function onChangeTag(e) {
    setCategoryName(e.target.value)
  }

  const uploadButton = (
    <div style={{ width: '100%' }}>
      <PlusOutlined />
      <div
        style={{
          marginTop: 8,
        }}
      >
        Adicionar imagem
      </div>
    </div>
  );

  return (
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

        <Form.Item
          {...question}
          initialValue={data[index]?.questionCategoryId || null}
          name={[question.name, "questionCategoryId"]}
          fieldKey={[question.fieldKey, 'description']}
        >
          <Input hidden />
        </Form.Item>

        <Col style={{ marginBlock: 15 }} span={24}>
          <Select
            style={{
              width: 300,
            }}
            placeholder="Categoria da questão"
            dropdownRender={(menu) => (
              <>
                {menu}
                <Divider
                  style={{
                    margin: '8px 0',
                  }}
                />
                <Space
                  style={{
                    padding: '0 8px 4px',
                  }}
                >
                  <Input
                    placeholder="Informe a categoria"
                    value={categoryName}
                    ref={inputTagRef}
                    onChange={onChangeTag}
                  />
                  <Button type="text" icon={<PlusOutlined />} onClick={e => onCreateCategory(e, question)}>
                    Adicionar
                  </Button>
                </Space>
              </>
            )}
            options={categories.map((item) => ({
              label: item.name,
              value: item.id,
            }))}
          />

          <Tooltip title="Você pode agrupar as questões informando a TAG há qual cada uma pertence">
            <QuestionCircleOutlined style={{ marginLeft: 10 }} />
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

          <Form.Item
            {...question}
            initialValue={data[index]?.images || []}
            name={[question.name, "images"]}
            fieldKey={[question.fieldKey, 'description']}
            hidden
          >
            <Input />
          </Form.Item>

          {loading ? (
            <Spin style={{ marginLeft: 20 }} />
          ) : (
            <Upload
              name="file"
              listType="picture-card"
              headers={{ enctype: 'multipart/form-data' }}
              action={`${REACT_APP_QUIZZEI_BACKEND_URL}api/files/upload-image`}
              onChange={file => onChangeUpload(file, question)}
              defaultFileList={images}
              style={{ width: 200, margin: 0 }}
            >
              {images.length > 0 ? null : (
                uploadButton
              )}
            </Upload>
          )}
        </Col>

        <Col span={22}>
          <Form.List
            name={[question.fieldKey, 'options']}>
            {(options, { add: addOptions, remove: removeOptions }) => (
              <>
                <Divider>Opções</Divider>
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
                        fieldKey={[item.fieldKey, 'options']}
                        key={`item.name-${index}`}
                        valuePropName="checked"
                        // eslint-disable-next-line no-mixed-operators
                        initialValue={form.getFieldsValue().questions && form.getFieldsValue().questions[question.fieldKey]?.options[index] && form.getFieldsValue().questions[question.fieldKey]?.options[index].isCorrect === true || false}
                      >
                        <Checkbox style={{ display: 'flex', justifyContent: 'center', backgroundColor: '#32CD80', height: '100%', alignItems: 'center', textAlign: 'center' }} />
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
                >Adicionar opções</Button>
              </>
            )}
          </Form.List>
        </Col>
      </Row>
    </div >
  )
}

export default StepQuestionsPanel;