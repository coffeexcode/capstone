import React, { useState, useEffect } from 'react';
import { StyleSheet, View, Image, TouchableOpacity, SafeAreaView } from 'react-native';
import { Agenda } from 'react-native-calendars';
import { Entypo, FontAwesome, FontAwesome5, Ionicons } from '@expo/vector-icons'; 

import {
  agendaFormatDate,
  agendaFormattedEvents,
  categorizeAgenda
} from '@utils/dateHelpers';

import CAText from '@core/CAText';
import Spacer from '@core/Spacer';
import noEventsImg from '@images/undraw_no_events.png';
import appText from '@utils/text';

import data from '@data/data.json';

const APP_THEME_COLOR = '#9892fe';

/**
 * Returns the Schedule screen
 * 
 * @param {object} props.navigation React Navigation navigation obtaining allowing for traversal to different screens
 * 
 * This screen is used to view view all of the events of a conference with an Agenda view
 * Allows navigation to see additional Event information
 */
export default function Schedule({ navigation }) {
  const [events, setEvents] = useState({});
  const [currentDate, setCurrentDate] = useState('');

  useEffect(() => {
    const now = agendaFormatDate(new Date());
    setCurrentDate(now);
    const agendaEvents = agendaFormattedEvents(data['events']);
    setEvents(categorizeAgenda(agendaEvents));
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
      <CAText appColor size='xsm' style={styles.register}>{appText.registerButton}</CAText>
    </TouchableOpacity>
  );

  const renderEmptyDate = () => (
    <View style={styles.emptyDate}>
       <CAText size='sm'>{appText.emptyDateMessage}</CAText>
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