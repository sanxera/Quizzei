import React from 'react';
import { Form, Button, Input, Typography } from 'antd';
import { UserOutlined } from '@ant-design/icons'
import { Link } from 'react-router-dom'
import { getAuthority, setAuthority } from '../../utils/auth';
import { login } from '../../services/login';

const { Text } = Typography;

const INPUT_STYLE = {
  borderBottom: '1px solid',
}


class FormComponent extends React.Component {
  onFinish = async (values) => {
    const { navigate } = this.props;

    const response = await login(values);
    await setAuthority(response);
    const isAuth = await getAuthority();
    if (isAuth) await navigate('/dashboard');
  };

  render() {
    return (
      <Form
        layout="vertical"
        name="basic"
        onFinish={this.onFinish}
      >
        <Form.Item name="username">
          <Input bordered={false} style={{ ...INPUT_STYLE }} placeholder="Email" suffix={<UserOutlined />} />
        </Form.Item>

        <Form.Item name="password">
          <Input.Password bordered={false} style={{ ...INPUT_STYLE }} placeholder="Senha" />
        </Form.Item>

        <div style={{ width: '100%', textAlign: 'right', marginBottom: 50 }}>
          <Link to="/recovery-password">Esqueceu a senha?</Link>
        </div>

        <Form.Item wrapperCol={{ span: 24, offset: 3 }}>
          <Button style={{ width: '90%' }} shape="round" type="primary" htmlType="submit">
            ENTRAR
          </Button>
        </Form.Item>

        <div style={{ display: 'flex', justifyContent: 'center' }}>
          <Text>Não possui conta? <Link to="/register" style={{ margin: 0, padding: 0 }} >Cadastre-se</Link></Text>
        </div>

      </Form>
    )
  }
}

export default FormComponent;