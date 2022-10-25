import React, { useState } from 'react';
import { Layout, Menu, Avatar, Row, Col } from 'antd';
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

const { Header, Sider } = Layout;

const HeaderMenu = () => {
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
  ];


  return (
    <Sider
      className={styles.header}
      trigger={null}>
      <Row justify='space-between' style={{ margin: 0, padding: 0 }}>
        <Col span={24} style={{ padding: '20px 30px 0px 30px' }}>
          <img
            style={{ height: 63 }}
            src={logoQuizzei}
          />
        </Col>
        <Col>
          <Menu
            mode="inline"
            defaultSelectedKeys={['1']}
            defaultOpenKeys={['sub1']}
            style={{
              height: '100%',
              borderRight: 0,
            }}
            items={items}
          />
        </Col>

        <Col style={{ display: 'flex', justifyContent: 'end' }} span={8}>
          {/* <Menu
            // className={styles.user_menu}
            mode="horizontal"
            defaultSelectedKeys={['mail']}
          >
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
              <Menu.Item
                key="two" icon={<SettingOutlined />}
                onClick={() => navigate('/user')}
              >
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
          </Menu> */}
        </Col>
      </Row>
    </Sider>
  )
}

export default HeaderMenu;