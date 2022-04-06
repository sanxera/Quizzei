import React, { useState, useEffect } from 'react';
import { Form } from 'antd'
import RegisterProfile from './RegisterProfile';
import RegisterForm from './RegisterForm';
import Container from '../../../components/Container';


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
      {registerType === 'profile' && (<RegisterProfile onSelect={onSelectProfileID} />)}
      <div>
        {registerType === 'registerForm' && (<RegisterForm profileID={profileID} />)}
      </div>
    </Container>
  )
}

export default Register;