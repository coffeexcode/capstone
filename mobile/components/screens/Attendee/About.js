import React, { useEffect, useState } from 'react';
import { StyleSheet, View } from 'react-native';
import { Ionicons } from '@expo/vector-icons';

import CAText from '@core/CAText';
import CAButton from '@core/CAButton';

import data from '@data/data.json';

const text = {
  numAttendees: ' Attendee count: ',
  sponsorButton: 'View our Sponsors'
};

export default function About({ navigation }) {
  const [conferenceData, setConferenceData] = useState({});

  useEffect(() => {
    setConferenceData(data["conference"][0]);
  });

  return (
    <View style={styles.container}>
      <View style={styles.heading}>
        <CAText size='lg' style={[styles.text, styles.header]}>{conferenceData.name}</CAText>
        <CAText size='md' style={styles.text}>{conferenceData.description}</CAText>
        <CAText size='md'>
          <Ionicons name="people-sharp" size={24} color="black" /> 
          {text.numAttendees}
          <CAText size='md' style={styles.header}>
            {conferenceData.numAttendees}</CAText>
          </CAText>
      </View>
        <CAButton
          title={text.sponsorButton}
          onPress={() => navigation.navigate('Sponsors')}
        />
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  text: {
    paddingBottom: 20
  },
  header: {
    fontWeight: '500'
  },
  heading: {
    paddingHorizontal: 20,
    paddingVertical: 40
  },
});
