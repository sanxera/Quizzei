import React from 'react';
import { Layout } from 'antd';
import HeaderMenu from './HeaderMenu';

const { Content, Footer } = Layout;

const LayoutWrapper = ({ hasHeader = true, hasFooter = true, navigate, children, header, ...rest }) => {
  const headerElement = header ? header : <HeaderMenu navigate={navigate} />;

  return (
    <Layout style={{ minHeight: '100vh' }} {...rest}>
      {hasHeader && headerElement}

      <Content style={{
        // backgroundColor: '#f0f2f5',
        backgroundColor: '#FFFFFF',
        padding: 50
      }}>
        {children}
      </Content>
      {
        hasFooter && (
          <Footer style={{ textAlign: 'center' }}>
            Quizzei ©2022 Created by Quizzei Devs
          </Footer>
        )
      }
    </Layout >
  );
}

export default LayoutWrapper;