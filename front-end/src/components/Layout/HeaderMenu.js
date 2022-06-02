import React from 'react';
import { Layout, Menu, Avatar } from 'antd';
import {
  QuestionOutlined
} from '@ant-design/icons';

const { Header } = Layout;

const HeaderMenu = ({ navigate }) => {
  return (
    <Header style={{ position: 'fixed', zIndex: 1, width: '100%', display: 'flex', justifyContent: 'space-between', alignItems: 'center', color: 'white', backgroundColor: '#40a9ff' }} trigger={null}>
      <span>Quizzei</span>
      <div>
        <span style={{ textDecoration: 'underline' }}>Quizzes</span> / Conteúdos
      </div>
      <Avatar
        style={{
          backgroundColor: '#f56a00',
          verticalAlign: 'middle',
        }}
        size="large"
        gap={4}
      >L</Avatar>
    </Header>
  )
}

export default HeaderMenu;