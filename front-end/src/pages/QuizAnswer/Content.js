import React, { useState } from 'react';
import { Row, Col, Typography, Button } from 'antd';

const { Title } = Typography;

const ContentQuestions = ({ data }) => {
  const { question } = data;
  const [options, setOptions] = useState(data.options);


  return (
    <Row style={{ display: 'flex' }} justify="center">
      <Col style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }} span={24}>
        <Title>{question}</Title>
      </Col>
      <Col style={{ display: 'flex', flexDirection: 'column', marginTop: 50 }}>
        {options.map((item, index) => (
          <Button
            // onClick={() => changeColor(index)}
            style={{ backgroundColor: item?.backgroundColor || '#FFFF', color: item?.color || '#000', marginBottom: 50, paddingLeft: 50, width: '50rem', height: 50, display: 'flex', justifyContent: 'flex-start', alignItems: 'center' }} shape='round'>{index}. {item.description}</Button>
        ))}
      </Col>
    </Row>
  )
}


export default ContentQuestions;