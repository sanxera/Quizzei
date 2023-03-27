import React, { useState, useEffect } from 'react';
import moment from 'moment';
import { Form, Input, Row, Col, Select, Divider, Space, Checkbox, DatePicker, Button as ButtonAntd } from 'antd';
import { Button } from '../../../components/Button';
import { InputWrapper } from '../../../components/InputWrapper';
import { PlusOutlined, TagOutlined } from '@ant-design/icons';
import { ModalQuizLogo } from '../ModalQuizLogo';

const { Option } = Select;
const { RangePicker } = DatePicker;

const StepForm = ({ data, form, showModalCategory, categories }) => {
  const [showModalLogo, setShowModalLogo] = useState(false);
  const [imageName, setImageName] = useState(data?.imageName || '');
  const [imageUrl, setImageUrl] = useState(data?.imageUrl || '');
  async function onSelect(value) {
    if (!value) return;
    await form.setFieldsValue({ categoryId: value })
  }

  async function onAddLogo(image = {}) {
    await form.setFieldsValue({ imageName: image.imageName || '' })
    setImageUrl(image.imageUrl);
    setShowModalLogo(false);
  }
  const uploadButton = (
    <div>
      <PlusOutlined />
      <div
        style={{
          marginTop: 8,
        }}
      >
        Logo
      </div>
    </div>
  );

  const options = categories && categories.map(item => <Option key={item.idCategory} value={item.idCategory}>{item.name}</Option>)
  const category = categories ? categories.filter(item => item.name === data.categoryDescription) : [{ idCategory: 1 }];
  // const dateFormat = 'YYYY/MM/DD';

  return (
    <Form
      form={form}
      layout="vertical"
      name="basic"
      style={{ padding: 40, width: '100%' }}
    >
      <Row gutter={20}>
        <Col span={24}>
          <Form.Item
            name="title"
            rules={
              [{
                required: true,
                message: 'Por favor, insira o título.'
              }]
            }
            initialValue={data?.title}
          >
            <InputWrapper placeholder="Titulo" />
          </Form.Item>
        </Col>

        <Form.Item
          name="categoryId"
          initialValue={category[0]?.idCategory || 1}
          hidden
        />

        <Col span={24}>
          <Select
            bordered={false}
            style={{ width: '100%', marginBottom: 30, borderBottom: '1px solid' }}
            defaultValue={data.categoryDescription}
            showSearch
            filterOption={(input, option) => (option.children || "").toString().toLowerCase().includes((input || "").toLowerCase())}
            onChange={item => onSelect(item)}
            placeholder="Categoria"
          >
            {options}
          </Select>
        </Col>

        <Col span={24}>
          <Form.Item
            name="description"
            rules={
              [{
                required: true,
                message: 'Por favor, insira a descrição'
              }]
            }
            initialValue={data?.description}
          >
            <Input.TextArea rows={6} placeholder='Descrição' />
          </Form.Item>
        </Col>
        {/* // imageName */}



        <Col span={5}>
          <ButtonAntd style={{ height: 100, width: 130 }}
            onClick={() => {
              setImageName(data?.imageName)
              setShowModalLogo(true);
            }}>
            {imageUrl ? <img style={{ width: '100%', height: 70, borderRadius: '20px 20px 0px 0px', padding: 5 }} src={imageUrl} /> : uploadButton}
          </ButtonAntd>
          <Form.Item name="imageName" initialValue={imageName} rules={[{ required: true }]}>
            <Input hidden />
          </Form.Item>
        </Col>

        <ModalQuizLogo
          visible={showModalLogo}
          onClose={() => setShowModalLogo(false)}
          onAdd={onAddLogo}
          initialValue={imageName}
        />

        {/* <Col span={19} style={{ display: 'flex', flexDirection: 'column' }}>
          <Checkbox onChange={e => console.log(e)}>Este quiz é privado?</Checkbox>
          <span>Data que o quiz será realizado</span>
          <RangePicker
            defaultValue={[moment('2015/01/01', dateFormat), moment('2015/01/01', dateFormat)]}
            format={dateFormat}
          />
        </Col> */}
      </Row>
    </Form>
  )
}

export default StepForm;