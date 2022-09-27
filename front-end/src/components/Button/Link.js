import React from "react";
import { Link as LinkComponent } from "react-router-dom";

export function Link({ path = "", children }) {
  return (
    <LinkComponent to={path}>
      {children}
    </LinkComponent>
  )
}