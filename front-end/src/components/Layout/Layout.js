import React from 'react';
import { Layout } from 'antd';
import HeaderMenu from './HeaderMenu';

const { Content, Footer } = Layout;

const LayoutWrapper = ({ children }) => {
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <HeaderMenu />

      <Content
        style={{ backgroundColor: '##F0F8FF', padding: 20, marginTop: 64 }}
      >
        <div
          style={{ backgroundColor: '#FFFF', borderRadius: 5, padding: 15, minHeight: '100vh' }}
        >
          {children}
        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>
        Quizzei ©2022 Created by Quizzei Devs
      </Footer>


    </Layout>
  );
}

export default LayoutWrapper;