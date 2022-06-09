import React from 'react';
import { Form, Input, Row, Col } from 'antd';
import { InputWrapper } from '../../../components/InputWrapper';

const StepForm = ({ data, form }) => {
  return (
    <Form
      form={form}
      layout="vertical"
      name="basic"
      style={{ padding: 40, width: '100%' }}
    >
      <Row gutter={20}>
        <Col span={16}>
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
            <InputWrapper placeHolder="Titulo" />
          </Form.Item>
        </Col>
        <Col span={8}>
          <Form.Item
            name="points"
            rules={
              [{
                required: true,
                message: 'Por favor, insira a pontuação.'
              }]
            }
            initialValue={data?.points}
          >
            <InputWrapper type={'number'} placeHolder="Pontos" />
          </Form.Item>
        </Col>

        <Col span={24}>
          <Form.Item
            name="categoryId"
            rules={
              [{
                required: true,
                message: 'Por favor, insira uma categoria.'
              }]
            }
            initialValue={data?.category}
          >
            <InputWrapper type={'number'} placeHolder="Categoria" />
          </Form.Item>
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