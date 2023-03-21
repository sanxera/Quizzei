import React, { useState, useEffect } from 'react';
import { Col, Modal, Row, Typography, Button as ButtonAntd } from 'antd';
import { Button } from '../../components/Button';
import { getDefaultLogo } from '../../services/quiz';

const { Text } = Typography;

export function ModalQuizLogo({ initialValue, onClose, onAdd, visible }) {
  const [data, setData] = useState([]);
  const [image, setImage] = useState({ imageName: initialValue || '' });

  async function getDefaultLogoQuizzes() {
    const images = await getDefaultLogo();
    await setData(images);
  }

  useEffect(() => {
    getDefaultLogoQuizzes();
  }, [])

  if (!visible) return <div />;

  return (
    <Modal
      title={
        <Text style={{ display: 'flex', alignItems: 'center' }} strong>
          Selecionar logo do quiz
        </Text>
      }
      style={{ marginTop: 100, width: '100%' }}
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
          title="Selecionar"
          type="primary"
          onClick={() => onAdd(image)}
        />
      ]}
      destroyOnClose
    >
      <Row gutter={16}>
        {data.map(logo => {
          const borderColor = logo.imageName === image.imageName ? '#00FF00' : '#d3d3d3'
          return (
            <Col style={{ marginTop: 10 }}>
              <ButtonAntd style={{ height: 130, width: '100%', border: `1px solid ${borderColor}` }} onClick={() => setImage({ imageName: logo.imageName, imageUrl: logo.imageUrl })}>
                <img style={{ width: '100%', height: 100, borderRadius: '20px 20px 0px 0px', padding: 5 }} src={logo.imageUrl} alt={logo.imageName} />
              </ButtonAntd>
            </Col>
          )
        })}
      </Row>
    </Modal>
  )
}