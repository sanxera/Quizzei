import React, { useState } from 'react';
import { Layout, Menu, Avatar, Typography, Divider } from 'antd';
import { useNavigate } from 'react-router-dom';
import {
  LogoutOutlined,
  SettingOutlined,
  MailOutlined,
  AppstoreOutlined
} from '@ant-design/icons';
import logoQuizzei from '../../image/logo-quizzei.png';
import { setAuthority } from '../../utils/auth';

import styles from './styles.less'

const { Sider } = Layout;
const { Title } = Typography;

const SiderMenu = () => {
  const navigate = useNavigate();
  const [current, setCurrent] = useState('quiz');

  async function logout() {
    await setAuthority({ token: null });
    await navigate('/');
  }


  const onClick = (e) => {
    setCurrent(e.key);
  };

  const items = [
    {
      label: 'Dashboard',
      key: 'dashboard',
      icon: <MailOutlined />,
      onClick: () => navigate('/dashboard')
    },
    {
      label: 'Quizzes',
      key: 'quiz',
      icon: <MailOutlined />,
      onClick: () => navigate('/quiz')
    },
    {
      label: 'Conteúdo',
      key: 'content',
      icon: <AppstoreOutlined />,
      onClick: () => navigate('/content')
    },
    {
      label: 'Configurações',
      key: 'configuration',
      icon: <SettingOutlined />,
      onClick: () => navigate('/user')
    },
    {
      label: 'Sair',
      key: 'logout',
      icon: <LogoutOutlined />,
      onClick: () => logout()
    },
  ];


  return (
    <Sider
      // className={styles.header}
      style={{
        overflow: 'auto',
        height: '100vh',
        position: 'fixed',
        left: 0,
        top: 0,
        bottom: 0,
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        textAlign: 'center',
        backgroundColor: '#47a7f0'
      }}
      trigger={null}>
      <div className="logo">
        <img
          style={{ height: 63 }}
          src={logoQuizzei}
        />
      </div>

      <div style={{ marginTop: 20 }}>
        <Avatar
          style={{
            backgroundColor: '#f56a00',
            verticalAlign: 'middle',
          }}
          size={64}
          gap={4}
        >L</Avatar>

        <Title style={{ color: 'white', marginTop: 20 }} level={3}>Luiz Eduardo</Title>

      </div>
      <Divider style={{ backgroundColor: '#fff' }} />
      <Menu style={{ backgroundColor: '#47a7f0', color: '#fff', marginTop: 25, marginLeft: 25 }} mode="inline" defaultSelectedKeys={['4']} items={items} />

    </Sider>
  )
}

export default SiderMenu;