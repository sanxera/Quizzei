import React from 'react';
import { Layout } from 'antd';
import HeaderMenu from './HeaderMenu';

const { Content, Footer } = Layout;

const LayoutWrapper = ({ navigate, children }) => {
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <HeaderMenu navigate={navigate} />

      <Content style={{ backgroundColor: '#FFFF', padding: 50, marginTop: 64 }}>
        {children}
      </Content>
      <Footer style={{ textAlign: 'center' }}>
        Quizzei ©2022 Created by Quizzei Devs
      </Footer>


    </Layout>
  );
}

export default LayoutWrapper;