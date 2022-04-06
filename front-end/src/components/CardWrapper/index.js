import React from 'react';
import { Button, Card } from 'antd'
const { Meta } = Card;

const CardWrapper = ({ logo, title, description = '', onClickCard }) => {
  return (
    <Card
      onClick={() => onClickCard()}
      hoverable
      style={{ width: 240, borderRadius: 25, padding: 10}}
      cover={<img alt="example" src={logo} />}
    >
      <Meta style={{ display: 'flex', justifyContent: 'center'}} title={title} description={description} />
    </Card>
  )
}

export default CardWrapper;