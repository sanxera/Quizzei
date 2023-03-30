import React, { useState, useEffect } from 'react';
import { Col, Row, Button as ButtonAntd, Form, Input } from "antd";
import { getDefaultLogo } from '../../../services/quiz';


const StepTheme = ({ form, data }) => {
  const [themes, setThemes] = useState([]);
  const [imageName, setImageName] = useState(data?.imageName || 'Default');
  // const [imageUrl, setImageUrl] = useState(data?.imageUrl || 'https://img.freepik.com/free-vector/curiosity-search-concept-illustration_114360-11031.jpg?w=1060&t=st=1680183682~exp=1680184282~hmac=c21946e90aad64c87feb2c6a0b994306df305c0af660e1771b5083bc4124a79f');

  useEffect(() => {
    async function getDefaultLogoQuizzes() {
      const images = await getDefaultLogo();
      await setThemes(images);
    }

    getDefaultLogoQuizzes();
  }, []);


  async function onSelectTheme(theme) {
    setImageName(theme.imageName);
    // setImageUrl(theme.imageUrl);
    form.setFieldsValue({ imageName: theme.imageName });
  }

  return (
    <Row>
      <Form
        form={form}
        layout="vertical"
        name="basic"
        hidden
        // style={{ padding: 40, width: '100%' }}
      >
        <Form.Item name="imageName" initialValue={imageName} rules={[{ required: true }]}>
          <Input hidden />
        </Form.Item>
      </Form>

      {/* <Col style={{ display: 'flex', justifyContent: 'center' }} span={24}>
        <img style={{ width: '25%', height: 200, borderRadius: '20px 20px 0px 0px', padding: 5 }} src={imageUrl} />
      </Col>

      <Divider /> */}

      {themes.map(theme => {
        const borderColor = theme.imageName === imageName ? '#00FF00' : '#d3d3d3'
        return (
          <Col style={{ marginTop: 10, marginLeft: 5 }}>
            <ButtonAntd style={{ height: 130, width: '100%', border: `1px solid ${borderColor}` }} onClick={() => onSelectTheme(theme)}>
              <img style={{ width: '100%', height: 100, borderRadius: '20px 20px 0px 0px', padding: 5 }} src={theme.imageUrl} alt={theme.imageName} />
            </ButtonAntd>
          </Col>
        )
      })}
    </Row>
  )
}

export default StepTheme;