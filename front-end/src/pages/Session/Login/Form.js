import React from 'react';
import { Form, Input, Typography } from 'antd';
import { UserOutlined } from '@ant-design/icons'

import './styles.css'
import { Button } from '../../../components/Button';
import { Link } from '../../../components/Button/Link';

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
        className='input-email'
        name="email"
        rules={
          [{
            required: true,
            type: 'email',
            message: 'Email informado inválido.'
          }]
        }>
        <Input className='inputWrapper' bordered={false} style={{ ...INPUT_STYLE }} placeholder="Email" suffix={<UserOutlined />} />
      </Form.Item>

      <Form.Item rules={[{ required: true, message: 'Senha inválida' }]} name="password" style={{ marginTop: 30 }}>
        <Input.Password className='inputWrapper' bordered={false} style={{ ...INPUT_STYLE }} placeholder="Senha" />
      </Form.Item>

      <div style={{ width: '100%', textAlign: 'right', marginBottom: 50 }}>
        <Link className='btn-text' to="/recovery-password">Esqueceu a senha?</Link>
      </div>

      <Form.Item wrapperCol={{ span: 24, offset: 3 }}>
        <Button title="ENTRAR" style={{ width: '90%' }} type="primary" size='middle' htmlType="submit" />
      </Form.Item>

      <div style={{ display: 'flex', justifyContent: 'center' }}>
        <Text>Não possui conta? <Link className='btn-text' to="/register" style={{ margin: 0, padding: 0 }} >Cadastre-se</Link></Text>
      </div>
    </Form>
  )
}

export default FormComponent;