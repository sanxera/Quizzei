import React, { useEffect, useState } from 'react';
import { Upload, message } from 'antd';
import { FileArrowUp } from 'phosphor-react';
import { getFilesFromQuiz } from '../../../services/contents';
import { notification } from '../../../utils/notification';
const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env

const { Dragger } = Upload;

const StepContent = ({ data }) => {
  const [fileList, setFileList] = useState(null);

  const props = {
    name: 'file',
    multiple: true,
    headers: {
      enctype: 'multipart/form-data',
    },
    action: `${REACT_APP_QUIZZEI_BACKEND_URL}api/files/upload/${data.quizInfoUuid}`,
    onChange(info) {
      const { status } = info.file;
      if (status !== 'uploading') {
        console.log(info.file, info.fileList);
      }
      if (status === 'done') {
        message.success(`${info.file.name} upload feito com sucesso`);
        init();
      } else if (status === 'error') {
        message.error(`${info.file.name} falha no upload.`);
      }
    },
  };

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const response = await getFilesFromQuiz(data.quizInfoUuid);
    if (!response || !response.filesResponse) {
      notification({ status: 'error', message: 'Ocorreu um erro ao carregar os arquivos!' });
      return;
    }

    const files = await response.filesResponse.map(file => ({
      uid: file.fileCreatedUuid, name: file.fileName, status: 'done', thumbUrl: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2-BAzEgJ85b9Gb06Sj47vBFl7T_EHhLlYiw&usqp=CAU', url: `${REACT_APP_QUIZZEI_BACKEND_URL}api/files/download-file/${file.fileCreatedUuid}`
    }));
    setFileList(files);
  }

  if (!fileList) return <div />;

  return (
    <div style={{ padding: 10 }}>
      <Dragger
        listType='picture'
        {...props}
        defaultFileList={[...fileList]}
      >
        <p className="ant-upload-drag-icon">
          <FileArrowUp size={50} />
        </p>
        <p className="ant-upload-text">Clique ou arraste o arquivo para esta área para carregar</p>
        <p className="ant-upload-hint">
          Suporte para um upload único ou em massa.
        </p>
      </Dragger>
    </div>
  )
}

export default StepContent;