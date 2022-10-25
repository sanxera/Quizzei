import React from 'react';
import { Row, Col, Typography, Button } from 'antd';

import styles from './index.less';

const { Title } = Typography;

const ContentQuestions = ({ data, onClick }) => {
  const { description, options, selectedOption = null } = data;
  console.log(data, 'ContentQuestions')
  return (
    <Row style={{ display: 'flex' }} justify="center">
      <Col style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }} span={24}>
        <Title>{description}</Title>
      </Col>
      <Col style={{ display: 'flex', flexDirection: 'column', marginTop: 50 }}>
        {options.map((item, index) => (
          <>{console.log('slected >> ', index, selectedOption, selectedOption === index ? 'sim' : 'nao')}
            <Button
              key={`btn-option-${index}`}
              className={selectedOption && selectedOption === index ? styles.btnOptionsLinked : styles.btnOptions}
              onClick={() => onClick(index, { questionUuid: data?.questionUuid, optionUuid: item?.optionUuid })}
            >
              {index + 1}. {item.description}
            </Button>
          </>
        ))}
      </Col>
    </Row>
  )
}


export default ContentQuestions;