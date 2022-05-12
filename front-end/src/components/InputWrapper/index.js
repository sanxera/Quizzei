import React from 'react';
import { Input } from 'antd';
import styles from './index.css';

export const InputWrapper = ({ ...restProps }) => {
  return (
    <Input className='inputWrapper' {...restProps} />
  )
}