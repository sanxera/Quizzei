import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { Select } from 'antd';
import { RightOutlined } from '@ant-design/icons';
import { filterAll } from '../../services/filter';

const { Option, OptGroup } = Select;

const Filter = ({ navigate, onSelect, dispatch }) => {
  const [data, setData] = useState([]);

  useEffect(() => {
    init();
  }, [])

  async function init() {
    await loadFilter('');
  }

  async function loadFilter(search) {
    const data = await filterAll(search);
    await setData(data);
  }

  async function handleSelect(data) {
    const [type, uuid] = (data || '').split(':');

    switch (type) {
      case 'users':
        await dispatch({
          type: 'PERFIL',
          data: {
            userUuid: uuid,
          }
        })
        await navigate('/perfil');
        break;

      default:
        onSelect(uuid);
    }
  }

  return (
    <Select
      size="large"
      style={{ backgroundColor: '#FFFF', borderRadius: 50, width: '100%' }}
      suffixIcon={<RightOutlined />}
      placeholder="Buscar Quizzes, Usuarios & Instituições"
      showSearch
      filterOption={(input, option) => (option.children || "").toString().toLowerCase().includes((input || "").toLowerCase())}
      onSearch={value => loadFilter(value)}
      onSelect={handleSelect}
    >
      {Object.keys(data).map(key => (
        <OptGroup key={key} label={key}>
          {data[key].map(item => (
            <Option key={item.quizUuid || item.userUuid} value={`${key}:${item.quizUuid || item.userUuid}`}>{item.title || item.name}</Option>
          ))}
        </OptGroup>
      ))}
    </Select>
  )
}

export default connect(state => ({ ...state }))(Filter);