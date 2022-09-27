import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Form, Input, Select, Typography } from 'antd';
import { UserOutlined } from '@ant-design/icons'
import { Button } from '../../../components/Button';
import { register } from '../../../services/session';

import './index.css';
import { notification } from '../../../utils/notification';

const { Option } = Select;
const { Text } = Typography;

const INPUT_STYLE = {
  borderBottom: '1px solid',
}


const FormComponent = ({ navigate }) => {
  const [password, setPassword] = useState(null);
  const [disable, setDisable] = useState(false);
  async function onFinish(data) {
    const { created } = await register(data);
    const status = created ? 'success' : 'error';
    const message = created ? 'Cadastro feito com sucesso!' : 'Ops, ocorreu um erro ao realizar o cadastro, tente novamente.';
    await notification({ status, message });

    setTimeout(async () => {
      if (created) await navigate('/');
    }, 1000)
  };

  function validationPassword(confirmPassword) {
    console.log(confirmPassword, password)
    if (confirmPassword === password) {
      setDisable(false);
      return;
    }
    setDisable(true);
  }

  return (
    <Form
      layout="vertical"
      name="basic"
      onFinish={onFinish}
    >
      <Form.Item
        name="roleId"
        rules={
          [{
            required: true,
            type: 'string',
          }]}
      >
        <Select defaultValue={null} placeholder='Escolha o perfil' style={{ width: '100%' }}>
          {[
            { roleId: '0bd3463c-95dd-4dce-ae51-7c2c62609860', name: 'Aluno' },
            { roleId: 'e8ef779f-015d-4b30-808d-5ba36c7aef2b', name: 'Professor' },
            { roleId: 'ba1424f4-633a-4206-9e73-cdd92a283282', name: 'Perfil Institucional' },
          ].map(item => (
            <Option key={item.roleId} value={item.roleId}>{item.name}</Option>
          ))}
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
        name="nickName"
        rules={
          [{
            required: true,
            type: 'string',
            message: 'Por favor, informe um nome de usuario.'
          }]}
      >
        <Input bordered={false} style={{ ...INPUT_STYLE }} placeholder="Usuario" />
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
        validateStatus={disable ? 'error' : undefined}
        hasFeedback
      >
        <Input.Password
          bordered={false}
          style={{ ...INPUT_STYLE }}
          placeholder="Senha"
        // onChange={item => setPassword(item.target.value)} 
        />
      </Form.Item>

      <Form.Item
        className='formItem'
        name="confirmPassword"
        validateStatus={disable ? 'error' : undefined}
        hasFeedback
      >
        <Input.Password
          bordered={false} style={{ ...INPUT_STYLE }}
          placeholder="Confirmar senha"
        // onChange={item => validationPassword(item.target.value)}
        />
      </Form.Item>

      <Form.Item style={{ marginBottom: 10 }} wrapperCol={{ span: 24, offset: 3 }}>
        <Button
          title="CADASTRAR-SE"
          style={{ width: '90%' }}
          disabled={disable}
          type="primary"
          htmlType="submit"
        />
      </Form.Item>
      <div style={{ display: 'flex', justifyContent: 'center' }}>
        <Link className='btn-text' to="/" style={{ margin: 0, padding: 0 }} >LOGIN</Link>
      </div>
    </Form >
  )
}

export default FormComponent;