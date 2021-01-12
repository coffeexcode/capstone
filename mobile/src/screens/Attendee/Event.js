import React, { useState, useEffect } from 'react';
import { StyleSheet, TouchableOpacity, View } from 'react-native';
import { Entypo, FontAwesome, FontAwesome5, Ionicons } from '@expo/vector-icons'; 

import { eventHasEnded, formatDate } from '@utils/dateHelper';
import appText from '@utils/text';

import CAText from '@core/CAText';

export default function Event({ route }) {
  const [eventData, setEventData] = useState({});
   
  useEffect(() => {
    setEventData({...route.params.item});
  },[]);

  const toggleRegistration = () => {
    if (eventHasEnded(eventData.start)) return;
    const newStatus = eventData.status === appText.REGISTERED ? appText.UNREGISTERED : appText.REGISTERED;
    setEventData({...eventData, status: newStatus });
  }

  const renderIcon = type => {
    switch (type) {
      case 'opening':
        return <FontAwesome5 name="door-open" size={64} color='black' />
      case 'speaker':
        return <Entypo name="megaphone" size={64} color="black" />
      case 'food':
        return <Ionicons name="fast-food" size={64} color="black" />;
      case 'meeting':
        return <FontAwesome name="group" size={64} color="black" />
      default:
        return <FontAwesome5 name="calendar" size={64} color="black" />
    }
  }

  return (
    <View style={styles.container}>
      <View style={styles.headingContainer}>
        <CAText size='lg' style={styles.heading}>{eventData.name}</CAText>
        <CAText style={styles.icon}>{renderIcon(eventData.type)}</CAText>
      </View>
      <View style={styles.descriptionContainer}>
        <CAText size='md' style={[styles.text, styles.line]}>
          <Ionicons name="time-outline" size={24} color="black" />
          {formatDate(eventData.start, eventData.startTime, eventData.endTime)}
        </CAText>
        <CAText size='md' style={[styles.text, styles.line]}>
          <Ionicons name="location-outline" size={24} color="black" />
          {eventData.roomId}
        </CAText>
        <CAText style={styles.text}>
          {eventData.description}
        </CAText>
      </View>
      <View style={styles.registrationContainer}>
        <CAText style={styles.text} appColor>{appText.status}</CAText>
        <TouchableOpacity
          onPress={toggleRegistration}
          style={[styles.status, 
            eventData.status === appText.REGISTERED ? styles.registered : styles.unregistered
          ]}>
          <CAText style={styles.statusText}>
            {!eventHasEnded(eventData.start) ? eventData.status : appText.ended}
          </CAText>
        </TouchableOpacity>
        <CAText style={styles.registerToggle} size='sm'>
          {appText.registerToggle}
        </CAText>
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff'
  },
  line: {
    fontSize: 28
  },
  descriptionContainer: {
    paddingTop: 20,
    paddingHorizontal: 30
  },
  headingContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between'
  },
  registrationContainer: {
    flex: 1,
    justifyContent: 'flex-end',
    paddingBottom: 30,
    paddingHorizontal: 30
  },
  unregistered: {
    backgroundColor: '#cdcdcd',
  },
  registered: {
    backgroundColor: '#90ee90'
  },
  registerToggle: {
    fontStyle: 'italic'
  },
  status: {
    borderRadius: 10,
    padding: 30,
    marginBottom: 20,
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 5
    },
    shadowOpacity: 0.4,
    shadowRadius: 8,
    elevation: 2
  },
  statusText: {
    fontWeight: '500'
  },
  heading: {
    fontWeight: '500',
    width: '75%',
    padding: 20
  },
  icon: {
    paddingTop: 50,
    paddingRight: 40
  },
  text: {
    paddingBottom: 20
  },
});
