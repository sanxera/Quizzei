import React from 'react';
import { Card as CardAntd, Row, Col, Typography, Tag } from 'antd'
import { UserOutlined, FileTextOutlined } from '@ant-design/icons'
// import styles from './index.less';
import { PERMISSION_TYPE_TAGS } from '../../utils/constant';

import './index.less';

const { Meta } = CardAntd;
const { Title, Text, Paragraph } = Typography;

const Card = ({ className, logo, title, ownerNickName, numberOfQuestions, description = '', permissionType, cardName, onClick, isMyQuiz = false, children, ...rest }) => {
  const tagType = PERMISSION_TYPE_TAGS[permissionType || 1];
  return (
    <CardAntd
      className={className || "card"}
      size='small'
      onClick={() => onClick()}
      hoverable
      cover={logo ? (
        <div style={{ width: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
          <img style={{ width: '80%', height: 150, borderRadius: '20px 20px 0px 0px'}} alt="example" src={logo} />
        </div>
      ) : null}
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
                ellipsis={{ rows: 2 }}
                style={{ marginTop: 10, padding: 0, marginBottom: 0 }} level={5}>{title}</Title>
            }
            description={
              <div style={{ width: 200, margin: 0, padding: 0 }}>
                <Paragraph style={{ height: 44 }} ellipsis={{ rows: 2 }}
                  className="Paragraph"
                >{description}</Paragraph>
                {!isMyQuiz && (
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