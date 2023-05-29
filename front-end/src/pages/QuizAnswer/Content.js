import React from 'react';
import { Row, Col, Typography, Button } from 'antd';

import styles from './index.less';

const { Title } = Typography;

const ContentQuestions = ({ data, onClick }) => {
  const { images, description, options, selectedOption = null } = data;

  return (
    <Row justify='center'>
      <Col style={{ textAlign: 'center', marginTop: 50 }} span={24}>
        <Title level={4}>{description}</Title>
      </Col>
      {images && images.length > 0 && images.map(image => (
        <Col span={20} style={{ height: 350 }}>
          <Button type="link" href={image.imageUrl} target='blank' style={{ width: '100%', height: '100%' }}>
            <img src={image.imageUrl} alt={image.imageName} style={{ width: '100%', height: '100%' }} />
          </Button>
        </Col>
      )
      )}
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