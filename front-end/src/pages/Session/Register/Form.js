import React from 'react';
import { Form, Button, Input, Typography } from 'antd';
import { UserOutlined } from '@ant-design/icons'
import { Link } from 'react-router-dom'
import { register } from '../../../services/session';

const { Text } = Typography;

const INPUT_STYLE = {
  borderBottom: '1px solid',
}


const FormComponent = ({ profileID }) => {
  async function onFinish(values) {
    const response = await register(values);
  };

  return (
    <Form
      layout="vertical"
      name="basic"
      onFinish={onFinish}
    >
      <Form.Item name="profileId" initialValue={profileID} />

      <Form.Item name="name">
        <Input bordered={false} style={{ ...INPUT_STYLE }} placeholder="Nome" />
      </Form.Item>

      <Form.Item name="email">
        <Input bordered={false} style={{ ...INPUT_STYLE }} placeholder="Email" suffix={<UserOutlined />} />
      </Form.Item>

      <Form.Item name="password">
        <Input.Password bordered={false} style={{ ...INPUT_STYLE }} placeholder="Senha" />
      </Form.Item>

      <Form.Item name="confirmPassword">
        <Input.Password bordered={false} style={{ ...INPUT_STYLE }} placeholder="Confirmar senha" />
      </Form.Item>

      <Form.Item wrapperCol={{ span: 24, offset: 3 }}>
        <Button style={{ width: '90%' }} shape="round" type="primary" htmlType="submit">
          CADASTRAR-SE
        </Button>
      </Form.Item>
    </Form>
  )
}

export default FormComponent;