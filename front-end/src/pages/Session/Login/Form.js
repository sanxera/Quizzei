import React from 'react';
import { Form, Button, Input, Typography } from 'antd';
import { UserOutlined } from '@ant-design/icons'
import { Link } from 'react-router-dom'

const { Text } = Typography;

const INPUT_STYLE = {
  borderBottom: '1px solid',
}

const FormComponent = ({ onSubmit }) => {
  return (
    <Form
      layout="vertical"
      name="basic"
      onFinish={onSubmit}
    >
      <Form.Item
        name="email"
        rules={
          [{
            type: 'email',
            message: 'Email informado inválido'
          }]
        }>
        <Input bordered={false} style={{ ...INPUT_STYLE }} placeholder="Email" suffix={<UserOutlined />} />
      </Form.Item>

      <Form.Item name="password">
        <Input.Password bordered={false} style={{ ...INPUT_STYLE }} placeholder="Senha" />
      </Form.Item>

      <div style={{ width: '100%', textAlign: 'right', marginBottom: 50 }}>
        <Link to="/recovery-password">Esqueceu a senha?</Link>
      </div>

      <Form.Item wrapperCol={{ span: 24, offset: 3 }}>
        <Button style={{ width: '90%' }} type="primary" htmlType="submit">
          ENTRAR
        </Button>
      </Form.Item>

      <div style={{ display: 'flex', justifyContent: 'center' }}>
        <Text>Não possui conta? <Link to="/register" style={{ margin: 0, padding: 0 }} >Cadastre-se</Link></Text>
      </div>
    </Form>
  )
}

export default FormComponent;