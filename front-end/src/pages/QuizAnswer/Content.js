import React from 'react';
import { Row, Col, Typography, Button } from 'antd';

import styles from './index.less';

const { Title } = Typography;

const ContentQuestions = ({ data, onClick }) => {
  const { description, options, selectedOption = null } = data;
  return (
    <Row justify='center'>
      <Col style={{ textAlign: 'center', marginTop: 50 }} span={24}>
        <Title level={4}>{description}</Title>
      </Col>
      <Col style={{ display: 'flex', flexDirection: 'column', marginTop: 50 }}>
        {options.map((item, index) => (
          <Button
            key={`btn-option-${index}`}
            className={selectedOption && selectedOption === index + 1 ? styles.btnOptionsLinked : styles.btnOptions}
            onClick={() => onClick(index + 1, { questionUuid: data?.questionUuid, optionUuid: item?.optionUuid })}
          >
            {index + 1}. {item.description}
          </Button>
        ))}
      </Col>
    </Row>
  )
}


export default ContentQuestions;