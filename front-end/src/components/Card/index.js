import React from 'react';
import { Card as CardAntd, Row, Col, Typography } from 'antd'
import { UserOutlined, FileTextOutlined } from '@ant-design/icons'
// import styles from './index.less';

import './index.css'

const { Meta } = CardAntd;
const { Title, Text } = Typography;

const Card = ({ logo, title, ownerNickName, numberOfQuestions, description = '', cardName, onClick, isQuiz = false, children, ...rest }) => {
  return (
    <CardAntd
      className="card"
      // className={cardName ? `card` : styles.card}
      // className={`${cardName} card`}
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
              <Title
                // className={styles.text}
                style={{ marginTop: 10 }} level={5}>{title}</Title>
            }
            description={
              <div style={{ width: 200 }}>
                <Text ellipsis={{ rows: 1 }}
                // className={styles.text}
                >{description}</Text>
                {isQuiz && (
                  <Row style={{ marginTop: 20, marginBottom: 20 }} justify='center'>
                    <Col
                      // className={styles.text}
                      span={15}>
                      <UserOutlined /> {ownerNickName}
                    </Col>
                    <Col
                      // className={styles.text}
                      span={9}>
                      <FileTextOutlined /> {numberOfQuestions}
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