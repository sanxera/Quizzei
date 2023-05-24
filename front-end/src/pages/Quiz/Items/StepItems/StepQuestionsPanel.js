/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect, useState } from 'react';
import { Button, Input, Row, Col, Checkbox, Divider, Form, Upload } from 'antd';
import { Trash } from 'phosphor-react'

import '../index.less';
import { LoadingOutlined, PlusOutlined } from '@ant-design/icons';

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env;

const ACTIONS = {
  CREATE: 0,
  UPDATE: 1,
  REMOVE: 2,
}


const StepQuestionsPanel = ({ index, question, data, form }) => {
  const [loading, setLoading] = useState(false);
  const [images, setImages] = useState([]);

  useEffect(() => {
    async function loadListImages() {
      if (!data[question.key]?.imagesUrl || data[question.key]?.imagesUrl.length === 0) return;
      const images = data[question.key]?.imagesUrl.map((image, index) => ({ uid: index, status: 'done', name: image.imageName, url: image.imageUrl }))
      setImages(images);
    }

    loadListImages();
  }, [])

  async function onChangeUpload(info, questionInfo) {
    const { status, response } = info.file;
    const { fieldKey: questionKey } = questionInfo;
    const { questions } = form.getFieldsValue();

    if (status === 'removed') {
      questions[questionKey].imagesUrl = []
      form.setFieldsValue({
        questions: [...questions]
      })

      setImages([]);
      return;
    }
    if (status === 'uploading') {
      setLoading(true);
      return;
    }

    if (status === 'done') {
      questions[questionKey].imagesUrl = [];
      questions[questionKey].imagesUrl.push({
        questionImageUuid: response.imageCreateUuid,
        imageName: response.fileName,
        imageUrl: response.imageUrl
      })

      form.setFieldsValue({
        questions: [...questions]
      })

      images.push({
        uid: response.imageCreateUuid,
        status: 'done',
        name: response.fileName,
        url: response.imageUrl
      })
      setLoading(false);
      setImages(images);
    }
  }

  const uploadButton = (
    <div style={{ width: '100%' }}>
      {loading ? <LoadingOutlined /> : <PlusOutlined />}
      <div
        style={{
          marginTop: 8,
        }}
      >
        Upload
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
            initialValue={data[index]?.imagesUrl || []}
            name={[question.name, "imagesUrl"]}
            fieldKey={[question.fieldKey, 'description']}
            hidden
          >
            <Input />
          </Form.Item>
          <Upload
            style={{ width: 200, margin: 0 }}
            action={`${REACT_APP_QUIZZEI_BACKEND_URL}api/files/upload-image`}
            listType="picture-card"
            fileList={images}
            onChange={file => onChangeUpload(file, question)}
          >
            {images.length > 0 ? null : (
              uploadButton
            )}
          </Upload>
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