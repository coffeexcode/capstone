import React, { useState, useEffect } from 'react';
import { StyleSheet, TouchableOpacity, View } from 'react-native';
import { Entypo, FontAwesome, FontAwesome5, Ionicons } from '@expo/vector-icons'; 

import CAText from '@core/CAText';

const days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
const months = ['January','February','March','April','May','June','July','August','September','October','November','December'];

const text = {
  status: 'Your registration status: ',
  registerToggle: 'Click to register/unregister',
  REGISTERED: 'REGISTERED',
  UNREGISTERED: 'NOT REGISTERED',
  ended: 'THIS EVENT IS ENDED'
}
export default function Event({ route }) {
  const [eventData, setEventData] = useState({});
   
  const eventHasEnded = startDate => {
    const now = new Date();
    const eventDate = new Date(startDate);
    return eventDate < now;
  };
  useEffect(() => {
    setEventData({...route.params.item});
  },[]);

  // Move into a new helpers/ folder
  const getFormattedDate = (date, startTime, endTime) => {
    const convDate = new Date(date);
    const dayNum = convDate.getDay();
    const monthNum = convDate.getMonth();
    return `${months[monthNum]}, ${days[dayNum]} ${startTime} - ${endTime}`
  }

  const toggleRegistration = () => {
    if (eventHasEnded(eventData.start)) return;
    const newStatus = eventData.status === text.REGISTERED ? text.UNREGISTERED : text.REGISTERED;
    setEventData({...eventData, status: newStatus });
  }

  // Move into a new helpers/ folder
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
          {getFormattedDate(eventData.start, eventData.startTime, eventData.endTime)}
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
        <CAText style={styles.text} appColor>{text.status}</CAText>
        <TouchableOpacity
          onPress={toggleRegistration}
          style={[styles.status, 
            eventData.status === text.REGISTERED ? styles.registered : styles.unregistered
          ]}>
          <CAText style={styles.statusText}>
            {!eventHasEnded(eventData.start) ? eventData.status : text.ended}
          </CAText>
        </TouchableOpacity>
        <CAText style={styles.registerToggle} size='sm'>
          {text.registerToggle}
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
