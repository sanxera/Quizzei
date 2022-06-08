import React from 'react';
import { Form, Button, Input, Typography, Select } from 'antd';
import { UserOutlined } from '@ant-design/icons'
import { register } from '../../../services/session';

import './index.css';
import { notification } from '../../../utils/notification';

const { Option } = Select;
const { Text } = Typography;

const INPUT_STYLE = {
  borderBottom: '1px solid',
}


const FormComponent = ({ navigate, profileID }) => {
  async function onFinish(data) {
    const { created } = await register(data);
    const status = created ? 'success' : 'error';
    const message = created ? 'Cadastro feito com sucesso!' : 'Ops, ocorreu um erro ao realizar o cadastro, tente novamente.';
    await notification({ status, message });

    setTimeout(async () => {
      if (created) await navigate('/');
    }, 1000)
  };

  return (
    <Form
      layout="vertical"
      name="basic"
      onFinish={onFinish}
    >
      <Form.Item
        name="profileId"
        rules={
          [{
            required: true,
            type: 'number',
          }]}
      >
        <Select defaultValue={null} placeholder='Escolha o perfil' style={{ width: '100%' }}
        // onChange={handleChange}
        >
          <Option value={1}>Perfil Pessoal</Option>
          <Option value={2}>Perfil Governamental</Option>
          <Option value={3}>Instituição de Ensino</Option>
        </Select>
      </Form.Item>


      <Form.Item
        className='formItem'
        name="name"
        rules={
          [{
            required: true,
            type: 'string',
            message: 'Por favor, informe um nome.'
          }]}
      >
        <Input bordered={false} style={{ ...INPUT_STYLE }} placeholder="Nome" />
      </Form.Item>

      <Form.Item
        className='formItem'
        name="email"
        rules={
          [{
            required: true,
            type: 'email',
            message: 'Por favor, informe um e-mail válido.'
          }]}
      >
        <Input bordered={false} style={{ ...INPUT_STYLE }} placeholder="Email" suffix={<UserOutlined />} />
      </Form.Item>

      <Form.Item
        className='formItem'
        name="password"
        rules={
          [{
            required: true,
            type: 'string',
            message: 'Por favor, digite uma senha.'
          }]}
      >
        <Input.Password bordered={false} style={{ ...INPUT_STYLE }} placeholder="Senha" />
      </Form.Item>

      <Form.Item
        className='formItem'
        name="confirmPassword"
      >
        <Input.Password bordered={false} style={{ ...INPUT_STYLE }} placeholder="Confirmar senha" />
      </Form.Item>

      <Form.Item wrapperCol={{ span: 24, offset: 3 }}>
        <Button className='btn-main' style={{ width: '90%' }} shape="round" type="primary" htmlType="submit">
          CADASTRAR-SE
        </Button>
      </Form.Item>
    </Form >
  )
}

export default FormComponent;