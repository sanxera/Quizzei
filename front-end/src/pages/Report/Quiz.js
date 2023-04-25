import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { PageHeader, Row, Col, Card, Radio, Divider } from "antd";
import { getReport } from '../../services/report';
import ReportQuestions from './Items/ReportQuestions';
import ReportUsers from './Items/ReportUsers';

const ReportQuiz = ({ data: { quizUuid } }) => {
  const [data, setData] = useState({});
  const [reportType, setReportType] = useState('REPORT_QUESTIONS')

  useEffect(() => {
    async function loadData() {
      const data = await getReport(quizUuid);
      setData(data);
    }

    loadData();
  }, [])

  async function onChangeReport({ target: { value } }) {
    setReportType(value);
  }

  if (!data.quizUuid) return <div />;

  return (
    <PageHeader
      onBack={() => null}
      title={data.quizDescription}
    >
      <Row type="flex">
        <Col span={24}>
          <Card style={{ width: '100%', textAlign: 'center' }}>
            <Row type="flex" justify='center'>
              <Col span={5}>
                <strong>{data.totalQuestions}</strong> <br /> <strong>Questões</strong>
              </Col>

              <Col>
                <Divider style={{ height: '100%' }} type="vertical" />
              </Col>

              <Col span={5}>
                <strong>{data.totalCompletedQuiz}</strong> <br /> <strong>Finalizados</strong>
              </Col>

              <Col>
                <Divider style={{ height: '100%' }} type="vertical" />
              </Col>

              <Col span={5}>
                <strong>{data.totalNotCompletedQuiz}</strong> <br /> <strong>Não finalizados</strong>
              </Col>
            </Row>
          </Card>
        </Col>

        <Radio.Group value={reportType} style={{ margin: '20px 0px 20px 0px' }} onChange={onChangeReport}>
          <Radio.Button value="REPORT_QUESTIONS">Por questões</Radio.Button>
          <Radio.Button value="REPORT_USER">Por alunos</Radio.Button>
        </Radio.Group>
      </Row>

      {reportType === 'REPORT_QUESTIONS' ? <ReportQuestions data={data} /> : <ReportUsers quizUuid={quizUuid} />}
    </PageHeader>
  )
}

export default connect(state => ({ data: state.data }))(ReportQuiz);