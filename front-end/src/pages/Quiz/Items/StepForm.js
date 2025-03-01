/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from 'react';
import moment from 'moment';
import { Form, Input, Row, Col, Select, DatePicker, Typography } from 'antd';
import { DEFAULT_DATE, GENERATE_PERIOD_DATE, PERMISSION_TYPE } from '../../../utils/constant';
import { InputWrapper } from '../../../components/InputWrapper';

const { Option } = Select;
const { RangePicker } = DatePicker;
const { Text } = Typography;

const StepForm = ({ data, form, categories }) => {
  const [permissionType, setPermissionType] = useState(PERMISSION_TYPE[data?.permissionType || 1]);
  const [period, setPeriod] = useState(DEFAULT_DATE);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function loadData() {
      const dates = await GENERATE_PERIOD_DATE(data?.quizAccess);
      setLoading(true);
      setPeriod(dates);
      setLoading(false);
    }

    loadData();
    
  }, [])

  // async function onAddLogo(image = {}) {
  //   await form.setFieldsValue({ imageName: image.imageName || '' })
  //   setImageUrl(image.imageUrl);
  //   setShowModalLogo(false);
  // };

  async function onSelect(value) {
    if (!value) return;
    await form.setFieldsValue({ categoryId: value })
  };

  async function onChangePermission(value) {
    if (!value) return;
    const { quizAccess = {} } = form.getFieldsValue();
    let quizAccessModel = null;
    switch (PERMISSION_TYPE[value]) {
      default:
        break;
      case 'PRIVATE':
        quizAccessModel = { ...quizAccess, initialDate: null, endDate: null, accessCode: '' };
        break;
      case 'TEMPORARY':
        quizAccessModel = { ...quizAccess, initialDate: period[0], endDate: period[1] };
        break;
    }

    await form.setFieldsValue({
      permissionType: value,
      quizAccess: quizAccessModel
    });
    setPermissionType(PERMISSION_TYPE[value])
  };

  async function onChangeQuizAccessDate(dates) {
    const [initialDate, endDate] = dates;
    const { quizAccess } = await form.getFieldsValue();

    setPeriod(dates);
    await form.setFieldsValue({
      quizAccess: {
        ...quizAccess,
        initialDate,
        endDate
      }
    });
  }

  const options = categories && categories.map(item => <Option key={item.idCategory} value={item.idCategory}>{item.name}</Option>);
  const category = categories ? categories.filter(item => item.name === data.categoryDescription) : [{ idCategory: 1 }];
  const dateFormat = 'DD/MM/YYYY';

  return (
    <Form
      form={form}
      layout="vertical"
      name="basic"
      style={{ padding: 40, width: '100%' }}
    >
      <Row gutter={20}>
        <Col span={24}>
          <Form.Item
            name="title"
            rules={
              [{
                required: true,
                message: 'Por favor, insira o título.'
              }]
            }
            initialValue={data?.title}
          >
            <InputWrapper placeholder="Titulo" />
          </Form.Item>
        </Col>

        <Form.Item
          name="categoryId"
          initialValue={category[0]?.idCategory || 1}
          hidden
        />

        <Col span={24}>
          <Select
            bordered={false}
            style={{ width: '100%', marginBottom: 30, borderBottom: '1px solid' }}
            defaultValue={data.categoryDescription}
            showSearch
            filterOption={(input, option) => (option.children || "").toString().toLowerCase().includes((input || "").toLowerCase())}
            onChange={item => onSelect(item)}
            placeholder="Categoria"
          >
            {options}
          </Select>
        </Col>

        <Col span={24}>
          <Form.Item
            name="description"
            rules={
              [{
                required: true,
                message: 'Por favor, insira a descrição'
              }]
            }
            initialValue={data?.description}
          >
            <Input.TextArea rows={6} placeholder='Descrição' />
          </Form.Item>
        </Col>

        {/* <Col span={5}>
          <ButtonAntd style={{ height: 100, width: 130 }}
            onClick={() => {
              setImageName(data?.imageName)
              setShowModalLogo(true);
            }}>
            {imageUrl ? <img style={{ width: '100%', height: 70, borderRadius: '20px 20px 0px 0px', padding: 5 }} src={imageUrl} /> : uploadButton}
          </ButtonAntd>
          <Form.Item name="imageName" initialValue={imageName} rules={[{ required: true }]}>
            <Input hidden />
          </Form.Item>
        </Col> */}

        <Col span={24} style={{ display: 'flex', flexDirection: 'column' }}>
          <Row gutter={[0, 10]}>
            <Form.Item
              name="quizAccess"
              initialValue={data?.quizAccess || null}
              hidden
            />

            <Col span={24}>
              <Form.Item
                name="permissionType"
                initialValue={data?.permissionType || 1}
                hidden
              />
              <div style={{ display: 'flex', alignItems: 'center' }}>
                <Text>Este quiz é? </Text>
                <Select
                  defaultValue={data?.permissionType || 1}
                  style={{ width: 120, marginLeft: 10 }}
                  onChange={onChangePermission}
                  options={[
                    { value: 1, label: 'Publico' },
                    { value: 2, label: 'Privado' },
                    { value: 3, label: 'Temporário' },
                  ]}
                />
              </div>
            </Col>

            {['PRIVATE', 'TEMPORARY'].includes(permissionType) && (
              <Col span={15}>
                <Form.Item
                  style={{ margin: 0 }}
                  name={["quizAccess", 'accessCode']}
                  initialValue={data?.quizAccess?.accessCode || ''}
                >
                  <InputWrapper placeholder="Senha do quiz" />
                </Form.Item>
              </Col>
            )}

            {permissionType === 'TEMPORARY' && !loading && (
              <Col span={10} style={{ display: 'flex', flexDirection: 'column', margin: 0, padding: 0 }}>
                <Text>Data que o quiz será realizado</Text>
                <Form.Item name={["quizAccess", 'initialDate']} initialValue={data?.quizAccess?.initialDate || moment(new Date())} hidden />
                <Form.Item name={["quizAccess", 'endDate']} initialValue={data?.quizAccess?.endDate || moment(new Date()).add(1, 'month')} hidden />

                <RangePicker
                  defaultValue={period}
                  format={dateFormat}
                  onChange={onChangeQuizAccessDate}
                />
              </Col>
            )}
          </Row>
        </Col>
      </Row>

      {/* <ModalQuizLogo
        visible={showModalLogo}
        onClose={() => setShowModalLogo(false)}
        onAdd={onAddLogo}
        initialValue={imageName}
      /> */}
    </Form>
  )
}

export default StepForm;