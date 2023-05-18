import React, { useState } from 'react';
import { Button, Input, Row, Col, Checkbox, Divider, Form, Upload } from 'antd';
import { Trash } from 'phosphor-react'

import '../index.less';
import { EditOutlined, LoadingOutlined, PlusOutlined, UploadOutlined } from '@ant-design/icons';

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env;

const ACTIONS = {
  CREATE: 0,
  UPDATE: 1,
  REMOVE: 2,
}

const getBase64 = (img, callback) => {
  const reader = new FileReader();
  reader.addEventListener('load', () => callback(reader.result));
  reader.readAsDataURL(img);
};

const StepQuestionsPanel = ({ index, question, data, form }) => {
  const [typeQuestion, setTypeQuestion] = useState('question');
  const [loading, setLoading] = useState(false);
  const [images, setImages] = useState(question[data.key]?.images || []);

  async function onChangeUpload(info, questionInfo) {
    const { status, response } = info.file;
    if (status === 'uploading') {
      setLoading(true);
      return;
    }

    if (status === 'done') {
      const { fieldKey: questionKey } = questionInfo;
      const { questions } = form.getFieldsValue();
      const changeQuestion = questions[questionKey];
      changeQuestion.imagesUrl.push({
        questionImageUuid: response.imageCreateUuid,
        imageName: response.fileName,
        imageUrl: response.imageUrl
      })

      form.setFieldsValue({
        questions: [...questions, changeQuestion]
      })

      getBase64(info.file.originFileObj, (url) => {
        setLoading(false);

        images.push({
          questionImageUuid: response.imageCreateUuid,
          imageName: response.fileName,
          imageUrl: response.imageUrl
        })
        setImages(images);
      });
    }
  }

  async function onRemoveImage(info, questionInfo) {
    const { name } = info;
    console.log("🚀  ~ file: StepQuestionsPanel.js:66 ~ onRemoveImage ~ name:", name)
    const { questions } = form.getFieldsValue();
    const { fieldKey: questionKey } = questionInfo;
    const changeQuestion = questions[questionKey];
    changeQuestion.imagesUrl = []

    form.setFieldsValue({
      questions: [...questions, changeQuestion]
    })

    setImages([]);
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

        <Col>
          <Button onClick={() => setTypeQuestion('question')}>
            <EditOutlined />  Questão
          </Button>
          <Button onClick={() => setTypeQuestion('upload')}>
            <UploadOutlined /> Imagem
          </Button>
        </Col>

        <Col span={24}>
          {typeQuestion === 'question' ? (
            <Form.Item
              {...question}
              name={[question.name, "description"]}
              fieldKey={[question.fieldKey, 'description']}
            >
              <Input.TextArea placeholder='Digite a questão aqui!' />
            </Form.Item>
          ) : (
            <>
              <Form.Item
                {...question}
                name={[question.name, "imagesUrl"]}
                fieldKey={[question.fieldKey, 'description']}
              >
                <Input hidden />
              </Form.Item>
              <Upload
                style={{ width: 200 }}
                action={`${REACT_APP_QUIZZEI_BACKEND_URL}api/files/upload-image`}
                listType="picture-card"
                maxCount={1}
                onChange={file => onChangeUpload(file, question)}
                onRemove={file => onRemoveImage(file, question)}
                disabled={images.length > 0}
              >
                {images.length > 0 ?
                  images.map(image => (
                    <img
                      src={image.imageUrl}
                      alt="avatar"
                      style={{
                        width: '100%',
                      }}
                    />
                  )) : (
                    uploadButton
                  )}
              </Upload>
            </>
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