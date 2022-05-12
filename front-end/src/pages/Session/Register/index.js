import React, { useState, useEffect } from 'react';
import { Typography, Button } from 'antd';
import RegisterProfile from './RegisterProfile';
import RegisterForm from './RegisterForm';
import Container from '../../../components/Container';

const { Title } = Typography;


const Register = () => {
  const [profileID, setProfileID] = useState(0);
  const [registerType, setRegisterType] = useState('profile');

  useEffect(() => {
    if (profileID === 0) return;
    setRegisterType('registerForm');

  }, [profileID])

  function onSelectProfileID(id) {
    console.log('id ', id)
    if (!id) return;
    setProfileID(id);
  }

  return (
    <Container>
      <div style={{ backgroundColor: '#6DA7EC', padding: '10px 10px 0px 10px' }}>
        <div className='header'>
          <Title level={2}>Quizzei</Title>
          <Button size='large' shape='circle' ghost>LOGIN</Button>
        </div>
        {registerType === 'profile' && (<RegisterProfile onSelect={onSelectProfileID} />)}
        {registerType === 'registerForm' && (<RegisterForm profileID={profileID} />)}
      </div>
    </Container>
  )
}

export default Register;