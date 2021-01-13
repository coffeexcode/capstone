import React, { useEffect, useState } from 'react';
import { StyleSheet, View } from 'react-native';
import { Ionicons } from '@expo/vector-icons';

import CAText from '@core/CAText';
import CAButton from '@core/CAButton';
import appText from '@utils/text';

import data from '@data/data.json';

/**
 * Returns the About screen
 * 
 * @param {object} props.navigation React Navigation navigation object allowing for traversal to different screens
 * 
 * This screen presents conference information provided by the conference organizer
 * Allows navigation to view sponsors
 */
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
          {appText.numAttendees}
          <CAText size='md' style={styles.header}>
            {conferenceData.numAttendees}</CAText>
          </CAText>
      </View>
        <CAButton
          title={appText.sponsorButton}
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
