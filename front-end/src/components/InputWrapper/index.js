import React from 'react';
import { Input } from 'antd';
import './index.css';

export const InputWrapper = ({ ...restProps }) => {
  return (
    <Input className='inputWrapper' {...restProps} />
  )
}