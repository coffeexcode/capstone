import React, { useState, useEffect } from 'react';
import { Alert, StyleSheet, TouchableOpacity, View } from 'react-native';
import { Ionicons } from '@expo/vector-icons';

import CAText from '@core/CAText';

import appText from '@utils/text';
import { eventHasEnded, formatDate } from '@utils/dateHelpers';
import { renderEventIcon } from '@utils/iconSelector';

/**
 * Returns the Event screen
 * 
 * @param {object} props.route React Navigation route object containing information passed from previous screen
 * 
 * This screen is used to view full event information as well as register/withdraw from the event
 */
export default function Event({ route }) {
  const [eventData, setEventData] = useState({});
   
  useEffect(() => {
    setEventData({...route.params.item});
  }, []);

  const confirmRegistration = () => {
    Alert.alert(
      "Event",
      "Confirm registration?",
      [
        {
          text: "Cancel",
          onPress: () => {},
          style: 'cancel'
        },
        {
          text: "OK",
          onPress: () => toggleRegistration()
        }
      ]
    )
  }

  const toggleRegistration = () => {
    if (eventHasEnded(eventData.start)) return;
    const newStatus = eventData.status === appText.REGISTERED ? appText.UNREGISTERED : appText.REGISTERED;
    setEventData({...eventData, status: newStatus });
  }

  return (
    <View style={styles.container}>
      <View style={styles.headingContainer}>
        <CAText testID='eventName' size='lg' style={styles.heading}>{eventData.name}</CAText>
        <CAText style={styles.icon}>{renderEventIcon(eventData.type, 48)}</CAText>
      </View>
      <View style={styles.descriptionContainer}>
        <CAText size='sm' style={[styles.text, styles.line]}>
          <Ionicons name="time-outline" size={24} color="black" />
          {formatDate(eventData.start, eventData.startTime, eventData.endTime)}
        </CAText>
        <CAText size='sm' style={[styles.text, styles.line]}>
          <Ionicons name="location-outline" size={24} color="black" />
          {eventData.roomId}
        </CAText>
        <CAText size='xsm' testID='eventDescription' style={styles.text}>
          {eventData.description}
        </CAText>
      </View>
      <View style={styles.registrationContainer}>
        <CAText size='sm' style={styles.text} appColor>{appText.status}</CAText>
        <TouchableOpacity
          testID='toggleRegistration'
          onPress={confirmRegistration}
          style={[styles.status, 
            eventData.status === appText.REGISTERED ? styles.registered : styles.unregistered
          ]}>
          <CAText size='sm' testID='registrationStatus' style={styles.statusText}>
            {!eventHasEnded(eventData.start) ? eventData.status : appText.ended}
          </CAText>
        </TouchableOpacity>
        <CAText style={styles.registerToggle} size='xsm'>
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
    textAlign: 'center',
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
