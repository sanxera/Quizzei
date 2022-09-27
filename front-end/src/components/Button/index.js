import { Button as ButtonComponent } from 'antd';

import styles from './styles.less';

export function Button({ title, icon = null, danger = false, onClick, ...restProps }) {
  return (
    <ButtonComponent
      className={!danger ? styles.button : null}
      icon={icon ? icon : null}
      onClick={onClick}
      danger={danger}
      {...restProps}
    >
      {title}
    </ButtonComponent>
  )
}