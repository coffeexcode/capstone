import React, { useState, useEffect } from 'react';
import { StyleSheet, View, TouchableOpacity } from 'react-native';
import { Agenda } from 'react-native-calendars';

import { Entypo, FontAwesome, FontAwesome5, Ionicons } from '@expo/vector-icons'; 

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';

import mockData from '../../assets/testData/schedule.json';

const APP_THEME_COLOR = '#9892fe';

export default function Schedule() {
  const [items, setItems] = useState({});
  const [currentDate, setCurrentDate] = useState('');

  useEffect(() => {
    const now = (new Date()).toISOString().split('T')[0];
    setCurrentDate(now);
    setItems(mockData[0]);
  }, []);

  const renderIcon = type => {
    switch (type) {
      case "opening":
        return <FontAwesome5 name="door-open" size={36} color='black' />
      case "speaker":
        return <Entypo name="megaphone" size={36} color="black" />
      case "food":
        return <Ionicons name="fast-food" size={36} color="black" />;
      case "meeting":
        return <FontAwesome name="group" size={36} color="black" />
      default:
        return <FontAwesome5 name="calendar" size={36} color="black" />
    }
  }
  const renderItem = item => (
    <TouchableOpacity onPress={() => alert(item.startTime)} style={[styles.item]}>
      {item.startTime ?
        <CAText style={{ color: '#A9A9A9' }} size="sm">
          {item.startTime} - {item.endTime}
        </CAText>
      : null}
      <CAText appColor size="xsm">{item.location}</CAText>
      <CAText size="md">{item.name}</CAText>
      {item.blurb ? 
        <View
          style={{ flexDirection: 'row', justifyContent: 'space-between'}}>
          <CAText
            style={{ width: '80%', color: '#A9A9A9' }} size="xsm"
          >
            {item.blurb}
          </CAText>
          <CAText>{renderIcon(item.type)}</CAText>
        </View>
      : null}
    </TouchableOpacity>
  );

  const renderEmptyDate = () => (
    <View style={styles.emptyDate}>
      <CAText size="sm">{`There are no events scheduled for this day`}</CAText>
    </View>
  );

  return (
    <View style={{ flex: 1, marginTop: '15%'}}>
    <CAText style={{ alignSelf: 'center'}} size="lg">Schedule</CAText>
    <Spacer size="sm"/>
    <Agenda
      items={items}
      selected={currentDate}
      renderItem={renderItem}
      renderEmptyDate={(renderEmptyDate)}
      renderEmptyData={renderEmptyDate}
      rowHasChanged={(r1, r2) => r1.name !== r2.name}
      pastScrollRange={1}
      futureScrollRange={1}
      theme={{
        agendaDayNumColor: 'black',
        agendaDayTextColor: 'black',
        agendaKnobColor: APP_THEME_COLOR,
        dotColor: APP_THEME_COLOR,
        selectedDotColor: 'white',
        selectedDayBackgroundColor: APP_THEME_COLOR,
        todayTextColor: APP_THEME_COLOR,
        agendaTodayColor: APP_THEME_COLOR
      }}
    />
    </View>
  );
}

const styles = StyleSheet.create({
  item: {
    backgroundColor: 'white',
    flex: 1,
    borderRadius: 5,
    paddingLeft: 15,
    paddingRight: 30,
    paddingTop: 20,
    paddingBottom: 40,
    marginRight: 10,
    marginTop: 17
  },
  emptyDate: {
    alignItems: 'center',
    height: 15,
    flex: 1,
    paddingTop: 30
  }
});
