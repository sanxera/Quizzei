import React from 'react';
import { Layout } from 'antd';
import SiderMenu from './SiderMenu';

const { Content, Footer } = Layout;

const LayoutWrapper = ({ hasHeader = true, hasFooter = true, navigate, children, header, ...rest }) => {
  const headerElement = header ? header : <SiderMenu navigate={navigate} />;

  return (
    <Layout style={{ minHeight: '100vh', width: '100vw' }}>
      {hasHeader && headerElement}

      <Layout
        style={{ marginLeft: 200 }}
        {...rest}>
        <Content
          style={{
            // height: '100vh',
            backgroundColor: '#f5f9fc',
            padding: '20px 50px',
          }}
        >
          {children}
        </Content>
        {
          hasFooter && (
            <Footer style={{ textAlign: 'center' }}>
              Quizzei © 2022 Created by Quizzei Devs
            </Footer>
          )
        }
      </Layout>
    </Layout >
  );
}

export default LayoutWrapper;