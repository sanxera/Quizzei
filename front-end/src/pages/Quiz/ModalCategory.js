import React, { useState } from 'react';
import { Modal, Typography } from 'antd';
import { Button } from '../../components/Button';
import { InputWrapper } from '../../components/InputWrapper';
import { TagOutlined } from '@ant-design/icons';

const { Text } = Typography;

export function ModalCategory({ onClose, onAdd, visible }) {
  const [name, setName] = useState("");


  return (
    <Modal
      title={
        <Text style={{ display: 'flex', alignItems: 'center' }} strong>
          <TagOutlined />  Adicionar categoria
        </Text>
      }
      style={{ marginTop: 100 }}
      visible={visible}
      width={500}
      closable={false}
      footer={[
        <Button
          title="Cancelar"
          danger
          onClick={() => onClose()}
        />,
        <Button
          title="Criar categoria"
          type="primary"
          onClick={() => onAdd(name)}
        />
      ]}
      destroyOnClose
    >
      <InputWrapper placeholder="Nome da categoria" value={name} onChange={e => setName(e.target.value)} />
    </Modal>
  )
}