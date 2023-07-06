/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { connect } from 'react-redux';
import { Steps, Skeleton, Button as ButtonAntd, Typography } from 'antd';
import { FolderOutlined } from '@ant-design/icons';
import ContentQuestions from './Content';
import { Button } from '../../components/Button'
import { notification } from '../../utils/notification';
import { answerQuestions } from '../../services/quiz';

import styles from './index.less';
import { FinishedModal } from './FinishedModal';
import ContentModal from './ContentModal';

const { Step } = Steps;
const { Text } = Typography;

const Quiz = ({ data: { quizProcessUuid, quizInfoUuid, questions: data } }) => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [current, setCurrent] = useState(0);
  const [steps, setSteps] = useState([]);
  const [finallyData, setFinallyData] = useState({});
  const [showFinallyModal, setFinallyModal] = useState(false);
  const [showContentModal, setContentModal] = useState(false);
  const [answerQuestionsData, setAnswerQuestions] = useState({ quizProcessUuid, answers: [] });
  const [intervalId, setIntervalId] = useState(null);
  let [hours, setHours] = useState(0);
  let [minutes, setMinutes] = useState(0);
  let [seconds, setSeconds] = useState(0);

  useEffect(async () => {
    const totalSeconds = answerQuestionsData.answers[current]?.timer || 0;
    const hours = Math.floor(totalSeconds / 3600);
    const minutes = Math.floor((totalSeconds / 3600) / 60);
    const seconds = totalSeconds % 60;

    await setHours(hours);
    await setMinutes(minutes);
    await setSeconds(seconds);

    const timerInterval = setInterval(() => {
      updateTimer();
    }, 1000);

    setIntervalId(timerInterval);
  }, [current])

  useEffect(() => {
    init();
  }, [])

  function init() {
    let arrSteps = [];
    data.map(item => arrSteps.push({ question: item.description, content: item }));
    setSteps(arrSteps);
    setCurrent(0);
  }

  async function onClickOption(indexOption, data) {
    await setLoading(true);
    await answerQuestionsData.answers.push(data);
    steps[current].content.selectedOption = indexOption;
    await setAnswerQuestions(answerQuestionsData);
    await setSteps(steps)
    setLoading(false);
  }

  async function onFinishQuiz() {
    console.log("🚀  ~ file: Quiz.js:61 ~ onFinishQuiz ~ answerQuestionsData:", answerQuestionsData)
    const response = await answerQuestions(answerQuestionsData);
    const { totalQuestions, correctAnswers } = response;
    if (!totalQuestions || !correctAnswers) {
      notification({ status: 'error', message: 'Ocorreu um erro ao finalizar o quiz' });
      return;
    }

    await setFinallyData({ totalQuestions, correctAnswers });
    await setFinallyModal(true);
  }

  async function onClickModal() {
    console.log("🚀  ~ file: Quiz.js:76 ~ onClickModal ~ timerInterval:", intervalId)
    await clearInterval(intervalId);
    navigate('/quiz');
  }

  function onChangeTimer(timer) {
    const { hours, minutes, seconds } = timer;
    const totalSeconds = (hours * 3600) + (minutes * 60) + seconds;

    if (answerQuestionsData.answers[current]) answerQuestionsData.answers[current].timer = totalSeconds;
    setAnswerQuestions(answerQuestionsData);
  }

  function updateTimer() {
    console.log("🚀  ~ file: Quiz.js:120 ~ updateTimer ~ seconds:", seconds)
    seconds++;

    if (seconds >= 60) {
      seconds = 0;
      minutes++;

      if (minutes >= 60) {
        minutes = 0;
        hours++;
      }
    }

    setHours(hours);
    setMinutes(minutes);
    setSeconds(seconds);

    onChangeTimer({ hours, minutes, seconds });
  }

  function resetTimer() {
    console.log("🚀  ~ file: Quiz.js:112 ~ resetTimer ~ timerInterval:", intervalId)
    clearInterval(intervalId);
    setHours(0);
    setMinutes(0);
    setSeconds(0);
  }

  if (steps.length === 0 || loading) return <Skeleton />;

  const next = () => {
    resetTimer();
    setCurrent(current + 1);
  };

  const prev = () => {
    resetTimer();
    setCurrent(current - 1);
  };

  return (
    <div className='testando' style={{ backgroundColor: '#FFFF', paddingBottom: 50, borderRadius: 15, padding: 20, boxShadow: '0 3px 10px rgb(0 0 0 / 0.2)' }}>
      <Steps progressDot current={current}>
        {steps.map((item) => (
          <Step key={item.question} />
        ))}
      </Steps>

      <>
        <div className="steps-content">
          {/* <Timer onChange={onChangeTimer} data={{ hours: 0, minutes: 0, seconds: 0 }} /> */}
          <Text>{`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`}</Text>
          <ContentQuestions data={steps[current].content} onClick={onClickOption} />
        </div>
        <div style={{ display: 'flex', justifyContent: 'center', marginTop: 10 }}>


          {current > 0 && (
            <Button
              className={styles.btnPrev}
              title="Voltar"
              style={{
                margin: '0 8px',
              }}
              onClick={() => prev()}
            />
          )}

          {current === steps.length - 1 && (
            <Button
              className={styles.btnNext}
              title="Finalizar Quiz"
              onClick={onFinishQuiz} />
          )}

          {current < steps.length - 1 && (
            <Button className={styles.btnNext} title="Avançar" onClick={() => next()} />
          )}

        </div>
        <div style={{ display: 'flex', justifyContent: 'center', marginTop: 40 }}>
          <ButtonAntd
            style={{ height: '3rem', display: 'flex', alignItems: 'center', borderRadius: 5 }}
            icon={<FolderOutlined />}
            onClick={() => setContentModal(true)}
          >
            Ver contéudo
          </ButtonAntd>
        </div>
      </>

      <ContentModal visible={showContentModal} data={{ quizInfoUuid }} onClose={() => setContentModal(false)} />
      <FinishedModal visible={showFinallyModal} data={finallyData} quizProcessUuid={quizProcessUuid} onClick={onClickModal} />
    </div>
  )
}

export default connect(state => ({ data: state.data }))(Quiz);