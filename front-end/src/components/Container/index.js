import React from 'react';

const Container = ({ children, ...restProps }) => {
  return (
    <div id="container" {...restProps}>
      {children}
    </div>
  )
}

export default Container;