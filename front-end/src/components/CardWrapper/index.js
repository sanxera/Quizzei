import React from 'react';
import { Button, Card } from 'antd'
import './index.css';

const { Meta } = Card;

const CardWrapper = ({ logo, title, description = '', onClickCard, ...rest }) => {
  return (
    <Card
      className='card'
      onClick={() => onClickCard()}
      hoverable
      cover={<img style={{ width: '100%', height: 150, borderRadius: '20px 20px 0px 0px' }} alt="example" src={logo} />}
      {...rest}
    >
      <Meta style={{ display: 'flex', justifyContent: 'center' }} title={title} description={description} />
    </Card>
  )
}

export default CardWrapper;