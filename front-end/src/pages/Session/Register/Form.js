import React from 'react';
import { Link } from 'react-router-dom';
import { Form, Input, Row, Col } from 'antd';
import { UserOutlined } from '@ant-design/icons'
import { Button } from '../../../components/Button';
import { register } from '../../../services/session';

import './index.css';
import { notification } from '../../../utils/notification';

const INPUT_STYLE = {
  borderBottom: '1px solid',
}


const FormComponent = ({ navigate }) => {
 
  async function onFinish(data) {
    const { createdUserUuid } = await register(data);
    const status = createdUserUuid ? 'success' : 'error';
    const message = createdUserUuid ? 'Cadastro feito com sucesso!' : 'Ops, ocorreu um erro ao realizar o cadastro, tente novamente.';
    await notification({ status, message });

    setTimeout(async () => {
      if (createdUserUuid) await navigate('/');
    }, 1000)
  };

  // function validationPassword(confirmPassword) {
  //   if (confirmPassword === password) {
  //     setDisable(false);
  //     return;
  //   }
  //   setDisable(true);
  // }

  return (
    <Form
      layout="vertical"
      name="basic"
      onFinish={onFinish}
      labelCol={{ span: 10 }}
      wrapperCol={{ span: 24 }}
    >
      <Row gutter={36}>

        <Form.Item name="roleId" initialValue='0bd3463c-95dd-4dce-ae51-7c2c62609860'>
          <Input hidden />
        </Form.Item>
        {/* <Col span={24}>
          <Form.Item
            name="roleId"
            rules={
              [{
                required: true,
                type: 'string',
                message: 'Escolha o tipo de perfil.'
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
        </Col> */}

        <Col span={24}>
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
        </Col>

        <Col span={24}>
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
        </Col>

        <Col span={24}>
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
        </Col>

        <Col span={24}>
          <Form.Item
            className='formItem'
            name="password"
            rules={
              [{
                required: true,
                type: 'string',
                message: 'Por favor, digite uma senha.'
              }]}
            // validateStatus={disable ? 'error' : undefined}
            // hasFeedback
          >
            <Input.Password
              bordered={false}
              style={{ ...INPUT_STYLE }}
              placeholder="Senha"
            // onChange={item => setPassword(item.target.value)} 
            />
          </Form.Item>
        </Col>

        {/* <Form.Item
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
      </Form.Item> */}
        <Col span={24}>
          <Form.Item style={{ marginBottom: 10 }} wrapperCol={{ span: 24, offset: 3 }}>
            <Button
              title="CADASTRAR-SE"
              style={{ width: '90%', marginTop: 25 }}
              // disabled={disable}
              type="primary"
              htmlType="submit"
            />
          </Form.Item>
          <div style={{ display: 'flex', justifyContent: 'center' }}>
            <Link className='btn-text' to="/" style={{ margin: 0, padding: 0 }} >LOGIN</Link>
          </div>
        </Col>
      </Row>
    </Form>
  )
}

export default FormComponent;