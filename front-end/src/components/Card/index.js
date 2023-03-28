import React from 'react';
import { Card as CardAntd, Row, Col, Typography, Tag } from 'antd'
import { UserOutlined, FileTextOutlined } from '@ant-design/icons'
// import styles from './index.less';

import './index.less';
import { PERMISSION_TYPE_TAGS } from '../../utils/constant';

const { Meta } = CardAntd;
const { Title, Text } = Typography;

const Card = ({ logo, title, ownerNickName, numberOfQuestions, description = '', permissionType, cardName, onClick, isQuiz = false, children, ...rest }) => {
  const tagType = PERMISSION_TYPE_TAGS[permissionType || 1];
  return (
    <CardAntd
      className="card"
      size='small'
      onClick={() => onClick()}
      hoverable
      cover={logo ? <img style={{ width: '100%', height: 150, borderRadius: '20px 20px 0px 0px', padding: 5 }} alt="example" src={logo} /> : null}
      {...rest}
    >
      {children ?
        children
        : (
          <Meta
            style={{ display: 'flex', justifyContent: 'center' }}
            title={
              <Title
                className="text"
                style={{ marginTop: 10 }} level={5}>{title}</Title>
            }
            description={
              <div style={{ width: 200 }}>
                <Text ellipsis={{ rows: 1 }}
                  className="text"
                >{description}</Text>
                {isQuiz && (
                  <Row style={{ marginTop: 20, marginBottom: 20, padding: 0, textAlign: 'center' }} gutter={5} justify='center'>
                    <Col>
                      <Tag color={tagType.color}>{tagType.title}</Tag>
                    </Col>
                    <Col>
                      <UserOutlined /> {(ownerNickName || '').split(' ')[0]}
                    </Col>
                    <Col>
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