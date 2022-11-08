import React from 'react';
import { Layout } from 'antd';
import SiderMenu from './SiderMenu';

const { Content, Footer } = Layout;

const LayoutWrapper = ({ hasHeader = true, hasFooter = true, navigate, children, header, ...rest }) => {
  const headerElement = header ? header : <SiderMenu navigate={navigate} />;

  return (
    <Layout>
      {hasHeader && headerElement}

      <Layout style={{ minHeight: '100vh', marginLeft: 200 }} {...rest}>
        <Content
          style={{
            // backgroundColor: '#f0f2f5',
            backgroundColor: '#FFFFFF',
            padding: 50,
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