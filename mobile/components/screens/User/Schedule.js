import React, { useState, useEffect } from 'react';
import { StyleSheet, View, Image, TouchableOpacity, SafeAreaView } from 'react-native';
import { Agenda } from 'react-native-calendars';
import { Entypo, FontAwesome, FontAwesome5, Ionicons } from '@expo/vector-icons'; 

import CAText from '@core/CAText';
import Spacer from '@core/Spacer';
import noEventsImg from '@images/undraw_no_events.png';

// import data from '@data/schedule.json';

import data from '@data/data.json';

const APP_THEME_COLOR = '#9892fe';
const text = {
  emptyDateMessage: 'There are no events scheduled for this day',
  registerButton: 'Click to view status of registration'
}

export default function Schedule({ navigation }) {
  const [events, setEvents] = useState({});
  const [currentDate, setCurrentDate] = useState('');

  // Move into a new helpers/ folder
  const sanitizeEvents = (eventData) => {
    return eventData.map(event => {
      const { name, description, roomId, type, status, start, end } = event;
      
      const startDate = new Date(start);
      const endDate = new Date(end);
      const startDay = startDate.toISOString().split('T')[0];
      const endDay = endDate.toISOString().split('T')[0];
      const startTime = startDate.toLocaleString('en-US', { hour: 'numeric', hour12: true });
      const endTime = endDate.toLocaleString('en-US', { hour: 'numeric', hour12: true });

      return {
        name,
        description,
        roomId,
        type,
        status,
        start,
        startDay,
        startTime,
        endDay,
        endTime
      }
    });
  };

  // Move into a new helpers/ folder
  const categorizeEvents = (eventData) => {
    const categories = {};
    
    for (let i = 0; i < eventData.length; i++) {
      if (eventData[i].startDay in categories) {
        categories[eventData[i].startDay].push(eventData[i]);
      }
      else {
        categories[eventData[i].startDay] = [eventData[i]];
      }
    }
    return categories;
  }

  useEffect(() => {
    const now = (new Date()).toISOString().split('T')[0];
    setCurrentDate(now);
    const sanitizedEvents = sanitizeEvents(data['events']);
    setEvents(categorizeEvents(sanitizedEvents));
  }, []);

  const renderIcon = type => {
    switch (type) {
      case 'opening':
        return <FontAwesome5 name="door-open" size={36} color='black' />
      case 'speaker':
        return <Entypo name="megaphone" size={36} color="black" />
      case 'food':
        return <Ionicons name="fast-food" size={36} color="black" />;
      case 'meeting':
        return <FontAwesome name="group" size={36} color="black" />
      default:
        return <FontAwesome5 name="calendar" size={36} color="black" />
    }
  }

  const renderItem = item => (
    <TouchableOpacity
      onPress={() => navigation.navigate('Event', { item: item })} 
      style={[styles.item]}
    >
      <CAText style={{ color: '#A9A9A9' }} size="sm">
        {item.startTime} - {item.endTime}
      </CAText>
      <CAText size='md'>{item.name}</CAText>
      <View
        style={styles.descriptionContainer}>
        <CAText
          style={styles.description} size='xsm'
          >
          {item.description}
        </CAText>
        <CAText>{renderIcon(item.type)}</CAText>
      </View>
      <CAText appColor size='xsm' style={styles.register}>{text.registerButton}</CAText>
    </TouchableOpacity>
  );

  const renderEmptyDate = () => (
    <View style={styles.emptyDate}>
       <CAText size='sm'>{text.emptyDateMessage}</CAText>
        <Image source={noEventsImg} style={styles.splash} />
    </View>
  );

  return (
    <SafeAreaView style={styles.container}>
      <Spacer size='sm'/>
      <Agenda
        items={events}
        selected={currentDate}
        renderItem={renderItem}
        renderEmptyDate={renderEmptyDate}
        pastScrollRange={1}
        futureScrollRange={1}
        renderEmptyData={renderEmptyDate}
        rowHasChanged={(r1, r2) => { return r1.id !== r2.id }}
        pastScrollRange={2}
        futureScrollRange={2}
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
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#fff',
    flex: 1
  },
  descriptionContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between'
  },
  description: {
    width: '80%',
    color: '#A9A9A9'
  },
  item: {
    backgroundColor: 'white',
    flex: 1,
    borderRadius: 5,
    paddingLeft: 15,
    paddingRight: 30,
    paddingTop: 20,
    paddingBottom: 10,
    marginRight: 10,
    marginTop: 17
  },
  emptyDate: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 15,
    flex: 1,
    paddingTop: 30
  },
  register: {
    paddingTop: 20
  },
  splash: {
    height: "40%",
    resizeMode: 'contain',
    marginTop: 30
  },
});