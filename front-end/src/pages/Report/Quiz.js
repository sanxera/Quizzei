/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { PageHeader, Row, Col, Card, Radio, Divider, Typography } from "antd";
import { Pie } from '@ant-design/plots';
import { getByQuestionsCategory, getReport } from '../../services/report';
import ReportQuestions from './Items/ReportQuestions';
import ReportUsers from './Items/ReportUsers';
import ReportQuestionsCategory from './Items/ReportQuestionsCategory';

const { Text } = Typography;

const ReportQuiz = ({ data: { quizUuid } }) => {
  const [data, setData] = useState({});
  const [questionsCategories, setQuestionsCategories] = useState({});
  const [graphConfig, setGraphConfig] = useState({});
  const [reportType, setReportType] = useState('REPORT_QUESTIONS');

  useEffect(() => {
    async function loadData() {
      const data = await getReport(quizUuid);
      setData(data);

      const questionsCategories = await getByQuestionsCategory(quizUuid);
      setQuestionsCategories(questionsCategories);
    }

    async function loadGraphQuestionCategory() {
      const graphData = [];

      questionsCategories?.questionsCategories.map(item => {
        // if (item.totalHitPercentage <= 0) return;
        graphData.push({ type: item.questionCategoryDescription, value: item.totalHitPercentage })
      });

      const config = {
        appendPadding: 8,
        data: graphData,
        angleField: 'value',
        colorField: 'type',
        radius: 0.8,
        legend: {
          layout: 'horizontal',
          position: 'bottom'
        },
        label: {
          type: 'inner',
        },
        interactions: [
          {
            type: 'element-active',
          },
        ],
      };

      setGraphConfig(config);
    }



    loadData();
    loadGraphQuestionCategory();
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

        <Col span={24} style={{ marginTop: 10, display: 'flex', justifyContent: 'center' }}>
          <Card style={{ width: '70%', textAlign: 'center' }}>
            <Text strong>Grafico por categoria</Text>
            <Row>
              {Object.keys(graphConfig).length > 0 && (
                <Col span={24}>
                  <Pie style={{ height: 200 }} {...graphConfig} />
                </Col>
              )}
            </Row>
          </Card>
        </Col>

        <Radio.Group value={reportType} style={{ margin: '20px 0px 20px 0px' }} onChange={onChangeReport}>
          <Radio.Button value="REPORT_QUESTIONS">Por questões</Radio.Button>
          <Radio.Button value="REPORT_QUESTIONS_CATEGORY">Por Categoria de questões</Radio.Button>
          <Radio.Button value="REPORT_USER">Por alunos</Radio.Button>
        </Radio.Group>
      </Row>

      {reportType === 'REPORT_QUESTIONS' && <ReportQuestions data={data} />}
      {reportType === 'REPORT_QUESTIONS_CATEGORY' && <ReportQuestionsCategory data={questionsCategories} />}
      {reportType === 'REPORT_USER' && <ReportUsers quizUuid={quizUuid} />}
    </PageHeader>
  )
}

export default connect(state => ({ data: state.data }))(ReportQuiz);