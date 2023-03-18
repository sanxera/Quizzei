import React from 'react';
import { Form, Input, Row, Col, Select } from 'antd';
import { InputWrapper } from '../../../components/InputWrapper';

const { Option } = Select;

const StepForm = ({ data, form, categories }) => {
  async function onSelect(value) {
    if (!value) return;
    await form.setFieldsValue({ categoryId: value })
  }

  const options = categories && categories.map(item => <Option key={item.idCategory} value={item.idCategory}>{item.name}</Option>)
  const category = categories ? categories.filter(item => item.name === data.categoryDescription) : [{ idCategory: 1 }];

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
      </Row>
    </Form>
  )
}

export default StepForm;