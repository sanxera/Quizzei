import React from 'react';
import { Card, Divider, Row, Col, Typography } from 'antd'
import { UserOutlined, FileTextOutlined } from '@ant-design/icons'
import './index.css';

const { Meta } = Card;
const { Title, Text } = Typography;

const CardWrapper = ({ logo, title, description = '', onClick, isQuiz = false, ...rest }) => {
  return (
    <Card
      className='card'
      size='small'
      onClick={() => onClick()}
      hoverable
      cover={<img style={{ width: '100%', height: 150, borderRadius: '20px 20px 0px 0px' }} alt="example" src={logo} />}
      {...rest}
    >
      <Meta
        style={{ display: 'flex', justifyContent: 'center' }}
        title={
          <Title style={{ marginTop: 10 }} level={5}>{title}</Title>
        }
        description={
          <>
            <Text>{description}</Text>
            {isQuiz && (
              <Row style={{ marginTop: 20, marginBottom: 20 }} justify='center'>
                <Col style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }} span={15}>
                  <UserOutlined /> Luiz Eduardo
                </Col>
                <Col style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }} span={9}>
                  <FileTextOutlined /> 10
                </Col>
              </Row>
            )}
          </>
        }
      />
    </Card>
  )
}

export default CardWrapper;