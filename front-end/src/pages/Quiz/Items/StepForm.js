import React, { useState, useEffect } from 'react';
import { Form, Input, Row, Col, Select, Divider, Space } from 'antd';
import { Button } from '../../../components/Button';
import { InputWrapper } from '../../../components/InputWrapper';
import { TagOutlined } from '@ant-design/icons';

const { Option } = Select;

const StepForm = ({ data, form, showModalCategory, categories }) => {
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
            onChange={item => onSelect(item)}
            placeholder="Categoria"
            dropdownRender={menu => (
              <>
                {menu}
                <Divider style={{ margin: '8px 0' }} />
                <Space style={{ padding: '0 8px 4px' }}>
                  <Button icon={<TagOutlined />} title="Nova categoria" onClick={() => showModalCategory()} />
                </Space>
              </>
            )}
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