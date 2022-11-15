import React from 'react';
import { Card, Button as ButtonAntd, Row, Col, Typography } from 'antd';
import { FilePdf } from 'phosphor-react';

import './index.css';

const { Text } = Typography;

const Content = () => {
  return (
    <Row gutter={30} justify='center'>
      {Array(30).fill().map((_, index) => (
        <Col>
          <Card
            className='card-content'
            style={{ width: 250, marginTop: 16 }}
            actions={[
              <ButtonAntd type="link">Baixar</ButtonAntd>,
            ]}
          >
            <div style={{ display: 'flex', justifyContent: 'center', flexDirection: 'column', alignItems: 'center' }}>
              <FilePdf size={50} />
              <Text>Logica de programação</Text>
            </div>
          </Card>
        </Col>
      ))}
    </Row>
  )
}

export default Content;