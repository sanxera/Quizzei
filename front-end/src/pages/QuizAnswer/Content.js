import React, { useState } from 'react';
import { Row, Col, Typography, Button } from 'antd';

import styles from './index.css';

const { Title } = Typography;

const ContentQuestions = ({ data, onClick }) => {
  const { description, options: dataOptions } = data;
  const [options] = useState(dataOptions);

  return (
    <Row style={{ display: 'flex' }} justify="center">
      <Col style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }} span={24}>
        <Title>{description}</Title>
      </Col>
      <Col style={{ display: 'flex', flexDirection: 'column', marginTop: 50 }}>
        {options.map((item, index) => (
          <Button
            type={item?.isLinked ? 'primary' : 'default'}
            key={`btn-option-${index}`}
            className={styles.btnOptions}
            style={{
              // backgroundColor: item?.backgroundColor || '#FFFF',
              // color: item?.color || '#000',
              marginBottom: 50,
              paddingLeft: 50,
              width: '50rem',
              height: 50,
              display: 'flex',
              justifyContent: 'flex-start',
              alignItems: 'center'
            }}
            onClick={() => onClick(index, { questionUuid: data?.questionUuid, optionUuid: item?.optionUuid })}
          >
            {index}. {item.description}
          </Button>
        ))}
      </Col>
    </Row>
  )
}


export default ContentQuestions;