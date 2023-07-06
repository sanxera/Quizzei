import React, { useState, useEffect } from 'react';
import { Button, Typography } from 'antd';

const { Text } = Typography;


const Timer = ({ data, onChange }) => {
  let [hours, setHours] = useState(data?.hours || 0);
  let [minutes, setMinutes] = useState(data?.minutes || 0);
  let [seconds, setSeconds] = useState(data?.seconds || 0);
  let timerInterval = null;

  useEffect(() => {
    timerInterval = setInterval(() => {
      updateTimer();
    }, 1000)
  }, [])

  function updateTimer() {
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

    onChange({ hours, minutes, seconds }, timerInterval);
  }

  function resetTimer() {
    clearInterval(timerInterval);
    setHours(0);
    setMinutes(0);
    setSeconds(0);
  }

  return (
    <div
    // style={{ display: 'none' }}
    >
      <Text>{`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`}</Text>
      {/* <Button onClick={resetTimer}>Resetar</Button> */}
    </div>
  )
}


export default Timer;