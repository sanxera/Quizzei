import React from 'react';
import { Tabs } from 'antd';

const { TabPane } = Tabs;

const List = () => {

  return (
    <Tabs tabPosition="left" style={{ padding: 100}}>
      <TabPane tab="Informações" key='1'>

      </TabPane>
      <TabPane tab="Informações" key='1'>

      </TabPane>
      <TabPane tab="Informações" key='1'>

      </TabPane>
    </Tabs>
  )
}

export default List;