import React from 'react';
import './index.css'

const Container = ({ children, ...restProps }) => {
  return (
    <div id="container" {...restProps}>
      {children}
    </div>
  )
}

export default Container;