import React, { useEffect, useState } from 'react';
import { Typography, Modal, Button as ButtonAntd } from 'antd';
import { FilePdfOutlined } from '@ant-design/icons';
import { getFilesFromQuiz } from '../../services/contents';
import { Button } from '../../components/Button';

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env
const { Text } = Typography;

const ContentModal = ({ visible, data, onClose }) => {
  const [files, setFiles] = useState([]);

  useEffect(() => {
    init();
  }, []);

  async function init() {
    const response = await getFilesFromQuiz(data.quizInfoUuid);
    setFiles(response.filesResponse);
  }

  return (
    <Modal
      title={<Text strong>Conteúdos</Text>}
      visible={visible}
      width={500}
      bodyStyle={{ minHeight: 100 }}
      closable={false}
      footer={<Button title="Fechar" onClick={() => onClose()} style={{ width: 30 }} />}
      destroyOnClose
    >
      <div style={{ display: 'flex', flexDirection: 'column' }}>
        {files.length > 0 && files.map(file => (
          <ButtonAntd
            type="link"
            href={`${REACT_APP_QUIZZEI_BACKEND_URL}api/files/download-file/${file.fileCreatedUuid}`}
            target="_blank"
            style={{ fontSize: 20, marginBottom: 10 }}
            icon={<FilePdfOutlined />}
          >
            {file.fileName}
          </ButtonAntd>
        ))}


      </div>
    </Modal>
  )
}

export default ContentModal;