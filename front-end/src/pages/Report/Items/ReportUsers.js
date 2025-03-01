/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from 'react';
import moment from 'moment';
import { Row, Col, Card, Typography, Badge, Select, Divider } from "antd";
import { getUsersByQuiz, getReportPerQuizProcess } from '../../../services/report';

import './index.less'

const { Title, Text } = Typography;

const BADGE_TYPE = {
  1: { color: 'orange', title: 'Iniciado' },
  2: { color: 'lime', title: 'Finalizado' },
  3: { color: 'red', title: 'Cancelado' }
}

const ReportUsers = ({ quizUuid }) => {
  const [data, setData] = useState({});
  const [answersUser, setAnswersUser] = useState({});
  const [indexUser, setIndexUser] = useState(null);
  const [quizProcessUuid, setQuizProcessUuid] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function loadData() {
      const data = await getUsersByQuiz(quizUuid);
      setData(data);
    }

    loadData();
  }, []);

  useEffect(() => {
    async function loadQuizProcess() {
      if (!quizProcessUuid) return;
      const answersUser = await getReportPerQuizProcess(quizProcessUuid);
      setLoading(true);
      setAnswersUser(answersUser);
      setLoading(false);
    }

    loadQuizProcess();
  }, [quizProcessUuid]);

  function onChange(value) {
    setLoading(true);
    setAnswersUser({});
    setQuizProcessUuid(null);
    setIndexUser(value);
    setLoading(false);
  };

  function onChangeQuizProcess(value) {
    setLoading(true);
    setQuizProcessUuid(value);
    setLoading(false);
  };

  if (!data || !data.users || loading) return <div />;

  const optionsUser = data.users.map((user, index) => ({ value: index, label: user.name }));
  const optionsProcess = indexUser !== null && indexUser >= 0 ?
    data.users[indexUser].quizzesProcess.map(quizzesProcess =>
    ({
      value: quizzesProcess.quizProcessUuid,
      label: (
        <Text>
          <Badge color={BADGE_TYPE[quizzesProcess.status].color} text={`${BADGE_TYPE[quizzesProcess.status].title}:  `} />
          {moment(quizzesProcess.startedDate).format('DD/MM/YYYY')}
        </Text>
      )
    }))
    : [];

  return (
    <Col span={24}>
      <Card style={{ marginBottom: 10, display: 'flex', flexDirection: 'column' }}>
        <Row>
          <Col span={5}>
            <Text>Usuario: </Text>
            <Select
              style={{ width: '100%' }}
              showSearch
              placeholder="Selecione um usuario"
              optionFilterProp="children"
              value={indexUser}
              onChange={onChange}
              filterOption={(input, option) =>
                (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
              }
              options={optionsUser}
            />
          </Col>

          <Col>
            <Divider style={{ height: '100%' }} type="vertical" />
          </Col>

          <Col span={5} style={{ display: 'flex', flexDirection: 'column' }}>
            <Text>Quiz feito: </Text>
            <Select
              style={{ width: 230 }}
              optionFilterProp="children"
              value={quizProcessUuid}
              onChange={onChangeQuizProcess}
              filterOption={(input, option) =>
                (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
              }
              options={optionsProcess}
            />
          </Col>
        </Row>
      </Card>

      {answersUser && answersUser.questions && answersUser.questions.map((question, index) => {
        const totalSeconds = question?.timer || 0;

        const hours = Math.floor(totalSeconds / 3600);
        const minutes = Math.floor((totalSeconds / 3600) / 60);
        const seconds = totalSeconds % 60;

        return (
          <Badge.Ribbon
            key={`filter-by-user-${index + 1}`}
            text={question.userAnswerIsCorrect === true ? 'Acertou' : 'Errou'}
            color={question.userAnswerIsCorrect === true ? 'lime' : 'red'}
            placement='start'
          >
            <Card style={{ width: '100%' }}>
              <Row style={{ marginTop: 10 }}>
                <Col span={24}>
                  <Title level={5}>{index + 1}. {question.description}</Title>
                  <Text style={{ marginLeft: 20 }} type='secondary' strong>Resolvido em: {hours.toString().padStart(2, '0')}:{minutes.toString().padStart(2, '0')}:{seconds.toString().padStart(2, '0')}</Text>
                  <div style={{ display: 'flex', flexDirection: 'column', marginLeft: 20 }}>
                    {question.options.map((option, index) => {
                      const code = 'a'.charCodeAt(0);
                      const letterOption = String.fromCharCode(code + index);
                      const typeCheck = option.isCorrect === true ? 'success' : 'danger';
                      return (
                        <div className={option.userCheck === true ? `question-option-check-${typeCheck}` : null}>
                          <Text
                            type={typeCheck}
                          >
                            {letterOption.toUpperCase()}. {option.description}
                          </Text>
                        </div>
                      )
                    })}
                  </div>
                </Col>
              </Row>
            </Card>
          </Badge.Ribbon>
        )
      })}
    </Col>
  )
}

export default ReportUsers;