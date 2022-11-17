import React, { useEffect, useState } from 'react';
import { Card, Button as ButtonAntd, Row, Col, Typography, PageHeader } from 'antd';
import { FilePdf } from 'phosphor-react';
import { getAllFiles } from '../../services/contents';

import './index.css';

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env

const { Text } = Typography;

const Content = () => {
  const [allFiles, setAllFiles] = useState([]);

  useEffect(() => {
    init();
  }, [])

  async function init() {
    const response = await getAllFiles();
    setAllFiles(response.filesResponse);
  }

  return (
    <>
      <PageHeader
        className="site-page-header"
        title="Pagina de conteúdos"
        subTitle="Lista de todos os conteudos postados nos quizzes da plataforma."
      />
      <div style={{ padding: 20 }}>
        <Row gutter={30}>

          {allFiles.length > 0 ? allFiles.map(file => (
            <Col>
              <Card
                className='card-content'
                style={{ width: 250, marginTop: 16 }}
                actions={[
                  <ButtonAntd type="link" href={`${REACT_APP_QUIZZEI_BACKEND_URL}api/files/download-file/${file.fileCreatedUuid}`} target="_blank">Baixar</ButtonAntd>,
                ]}
              >
                <div style={{ display: 'flex', justifyContent: 'center', flexDirection: 'column', alignItems: 'center' }}>
                  <FilePdf size={50} />
                  <Text>{file.fileName}</Text>
                </div>
              </Card>
            </Col>
          )) : (
            <Col>
              <ButtonAntd style={{ width: '80vw', minHeight: 100 }} type='dashed'>Não há conteudos</ButtonAntd>
            </Col>
          )}
        </Row>
      </div>
    </>
  )
}

export default Content;