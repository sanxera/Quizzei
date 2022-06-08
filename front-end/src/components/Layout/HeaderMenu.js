import React from 'react';
import { Layout, Menu, Avatar } from 'antd';
import {
  LogoutOutlined,
  SettingOutlined
} from '@ant-design/icons';
import { setAuthority } from '../../utils/auth';

const { Header } = Layout;

const HeaderMenu = ({ navigate }) => {

  async function logout() {
    await setAuthority({ token: null });
    await navigate('/');
  }

  return (
    <Header style={{ position: 'fixed', zIndex: 1, width: '100%', display: 'flex', justifyContent: 'space-between', alignItems: 'center', color: 'white', backgroundColor: '#06a7c3' }} trigger={null}>
      <span>Quizzei</span>
      <div>
        <span style={{ textDecoration: 'underline' }}>Quizzes</span> / Conteúdos
      </div>

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
          <Menu.Item key="two" icon={<SettingOutlined />}>
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

    </Header >
  )
}

export default HeaderMenu;