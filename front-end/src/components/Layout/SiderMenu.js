import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Layout, Menu, Avatar, Typography, Divider } from 'antd';
import { Gauge, ChatCenteredText, Folder, Gear, SignOut, UserFocus } from 'phosphor-react'
import logoQuizzei from '../../image/logo-quizzei.png';
import { setAuthority } from '../../utils/auth';

import styles from './styles.less'

const { Sider } = Layout;
const { Title, Text } = Typography;

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
      icon: <Gauge size={20} />,
      onClick: () => navigate('/dashboard')
    },
    {
      label: 'Quizzes',
      key: 'quiz',
      icon: <ChatCenteredText size={20} />,
      onClick: () => navigate('/quiz')
    },
    {
      label: 'Conteúdo',
      key: 'content',
      icon: <Folder size={20} />,
      onClick: () => navigate('/content')
    },
    {
      label: 'Configurações',
      key: 'configuration',
      icon: <Gear size={20} />,
      onClick: () => navigate('/user')
    },
    {
      label: 'Sair',
      key: 'logout',
      icon: <SignOut size={20} />,
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
        padding: 10,
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        textAlign: 'center',
        backgroundColor: '#47a7f0',
      }}
      trigger={null}>
      <div className={styles.logo}>
        <img
          style={{ height: 63 }}
          src={logoQuizzei}
        />
      </div>
      <Divider style={{ backgroundColor: '#fff' }} />
      <div style={{ marginTop: 20 }}>
        <Avatar
          style={{
            backgroundColor: '#f56a00',
            verticalAlign: 'middle',
            border: '1px solid #fff'
          }}
          size={64}
          gap={4}
        >L</Avatar>

        <Title style={{ color: 'white', marginTop: 20 }} level={3}>Luiz Eduardo</Title>

        {/* <div>
          <div style={{ display: 'flex', alignItems: 'center', color: '#fff', grid: 20 }}>
            <UserFocus size={20} /> <Text style={{ color: '#fff' }}>Aluno</Text>
          </div>
        </div> */}
      </div>
      <Divider style={{ backgroundColor: '#fff' }} />
      <Menu style={{ backgroundColor: '#47a7f0', color: '#fff', marginTop: 25, marginLeft: 13 }} mode="inline" defaultSelectedKeys={['4']} items={items} />

    </Sider>
  )
}

export default SiderMenu;