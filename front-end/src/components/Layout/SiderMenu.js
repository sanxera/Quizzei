import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Layout, Menu, Avatar, Typography, Divider } from 'antd';
import { Gauge, ChatCenteredText, Folder, Gear, SignOut } from 'phosphor-react'
import logoQuizzei from '../../image/logo-quizzei.png';
import { setAuthority } from '../../utils/auth';

import styles from './styles.less'
import { getUser } from '../../services/session';

const { Sider } = Layout;
const { Title, Text } = Typography;

const SiderMenu = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState({});

  useEffect(() => {
    init();
  }, []);

  if (!user || !user.nickName) return <div />;

  async function init() {
    const user = await getUser();
    setUser(user);
  }

  async function logout() {
    await setAuthority({ token: null });
    await navigate('/');
  }

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
    // {
    //   label: 'Configurações',
    //   key: 'configuration',
    //   icon: <Gear size={20} />,
    //   onClick: () => navigate('/user')
    // },
    {
      label: 'Sair',
      key: 'logout',
      icon: <SignOut size={20} />,
      onClick: () => logout(),
      danger: true,
    },
  ];


  return (
    <Sider
      // className={styles.header}
      style={{
        overflow: 'hidden',
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
        boxShadow: '0 3px 10px rgb(0 0 0 / 0.2)'
      }}
      collapsedWidth="0"
      breakpoint='lg'
      theme='light'
      trigger={null}
    >
      <div className={styles.logo}>
        <img
          style={{ height: 63 }}
          src={logoQuizzei}
        />
      </div>
      <Divider style={{ backgroundColor: '#0000' }} />
      <div style={{ marginTop: 20 }}>
        <Avatar
          style={{
            backgroundColor: '#51d1f3',
            verticalAlign: 'middle',
          }}
          size={64}
          gap={4}
        >{user.nickName[0]}</Avatar>

        <Title strong style={{ marginTop: 10 }} level={3}>{user.nickName}</Title>
        <Text type='secondary' strong>{user.email}</Text>
      </div>
      <Divider style={{ backgroundColor: '#fff' }} />
      <div>
        <Menu
          style={{ marginTop: 25, overflow: 'hidden', border: 'none', fontWeight: 'bold' }}
          mode="inline"
          defaultSelectedKeys={['1']}
          items={items}
        />
      </div>

    </Sider>
  )
}

export default SiderMenu;