import React, { useState } from 'react';
import { Layout, Menu, Avatar, Row, Col, Button } from 'antd';
import {
  LogoutOutlined,
  SettingOutlined,
  MailOutlined,
  AppstoreOutlined
} from '@ant-design/icons';
import { setAuthority } from '../../utils/auth';

const { Header } = Layout;

const HeaderMenu = ({ navigate }) => {
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
      label: 'Quizzes',
      key: 'quiz',
      icon: <MailOutlined />,
    },
    {
      label: 'Conteúdo',
      key: 'content',
      icon: <AppstoreOutlined />,
    },
  ];


  return (
    <Header
      style={{
        position: 'fixed',
        zIndex: 1,
        width: '100%',
        // display: 'flex',
        // justifyContent: 'space-between',
        alignItems: 'center',
        color: 'white',
        backgroundColor: '#06a7c3',
        padding: 0,
        margin: 0
      }}
      trigger={null}>
      <Row justify='space-between' style={{ margin: 0, padding: 0 }}>
        <Col style={{ padding: '0px 10px 0px 10px', display: 'flex', justifyContent: 'start' }} span={5}>
          <Button type='link' size="large" style={{ backgroundColor: '#258a9c', color: '#FFF', height: '100%', width: 150 }}>Quizzei</Button>
        </Col>
        <Col style={{ display: 'flex', justifyContent: 'center' }} span={11}>
          <Menu onClick={onClick}
            selectedKeys={[current]}
            mode="horizontal"
            items={items}
            style={{ display: 'flex', width: '100%', marginRight: 250, border: 'none', justifyContent: 'end', backgroundColor: '#06a7c3', color: '#FFF' }}
          />
        </Col>

        <Col style={{ display: 'flex', justifyContent: 'end' }} span={8}>
          <Menu mode="horizontal" defaultSelectedKeys={['mail']} style={{ display: 'flex', width: '30%', border: 'none', justifyContent: 'end', backgroundColor: '#06a7c3', color: '#FFF' }}>
            <Menu.SubMenu key="SubMenu" title="Luiz Eduardo"
              icon={
                <Avatar
                  style={{
                    backgroundColor: '#f56a00',
                    verticalAlign: 'middle',
                  }}
                  size="large"
                  gap={4}
                >L</Avatar>
              }
            >
              <Menu.Item key="two" icon={<SettingOutlined />} onClick={() => navigate('/user')}>
                Configurações
              </Menu.Item>
              <Menu.Item
                key="three"
                icon={<LogoutOutlined />}
                onClick={logout}
              >
                Sair
              </Menu.Item>
            </Menu.SubMenu>
          </Menu>
        </Col>
      </Row>
    </Header >
  )
}

export default HeaderMenu;