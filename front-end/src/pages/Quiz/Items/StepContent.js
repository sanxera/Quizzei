import React from 'react';
import { Upload, message } from 'antd';
import { FileArrowUp } from 'phosphor-react';
const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env

const { Dragger } = Upload;

const props = {
  name: 'file',
  multiple: true,
  headers: {
    enctype: 'multipart/form-data',
  },
  action: `${REACT_APP_QUIZZEI_BACKEND_URL}/api/files/upload-pdf`,
  onChange(info) {
    const { status } = info.file;
    if (status !== 'uploading') {
      console.log(info.file, info.fileList);
    }
    if (status === 'done') {
      message.success(`${info.file.name} upload feito com sucesso`);
    } else if (status === 'error') {
      message.error(`${info.file.name} file upload failed.`);
    }
  },
  onDrop(e) {
    console.log('Dropped files', e.dataTransfer.files);
  },
};

const StepContent = ({ data }) => {
  return (
    <div style={{ padding: 10 }}>
      <Dragger listType='picture' {...props}>
        <p className="ant-upload-drag-icon">
          <FileArrowUp size={50} />
        </p>
        <p className="ant-upload-text">Click or drag file to this area to upload</p>
        <p className="ant-upload-hint">
          Support for a single or bulk upload. Strictly prohibit from uploading company data or other
          band files
        </p>
      </Dragger>
    </div>
  )
}

export default StepContent;