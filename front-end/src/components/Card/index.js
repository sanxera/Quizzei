import React from 'react';
import { Card as CardAntd, Row, Col, Typography } from 'antd'
import { UserOutlined, FileTextOutlined } from '@ant-design/icons'
import styles from './index.less';

const { Meta } = CardAntd;
const { Title, Text } = Typography;

const Card = ({ logo, title, description = '', onClick, isQuiz = false, children, ...rest }) => {
  return (
    <CardAntd
      className={styles.card}
      size='small'
      onClick={() => onClick()}
      hoverable
      cover={logo ? <img style={{ width: '100%', height: 150, borderRadius: '20px 20px 0px 0px' }} alt="example" src={logo} /> : null}
      {...rest}
    >
      {children ?
        children
        : (
          <Meta
            style={{ display: 'flex', justifyContent: 'center' }}
            title={
              <Title style={{ marginTop: 10 }} level={5}>{title}</Title>
            }
            description={
              <div style={{ width: 200 }}>
                <Text>{description}</Text>
                {isQuiz && (
                  <Row style={{ marginTop: 20, marginBottom: 20 }} justify='center'>
                    <Col span={15}>
                      <UserOutlined /> Luiz Eduardo
                    </Col>
                    <Col span={9}>
                      <FileTextOutlined /> 10
                    </Col>
                  </Row>
                )}
              </div>
            }
          />
        )}

    </CardAntd >
  )
}

export default Card;