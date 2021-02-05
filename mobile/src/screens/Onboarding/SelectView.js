import React from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '@core/CAText';
import CAButton from '@core/CAButton';
import Spacer from '@core/Spacer';

/**
 * Returns the SelectView screen
 * 
 * @param {object} props.navigation React Navigation navigation object allowing for traversal to different screens
 * 
 * For POC Purposes, the type of view is selected from the selection made on the screen
 * This will make it easier for us to display the different role's use cases for the app
 * This allows navigation into Attendee/Sponsor/Organizer Home
 */
export default function SelectView({ navigation }) {
  const navigateAsAttendee = () => navigation.navigate('AttendeeHome')
  const navigateAsOrganizer = () => navigation.navigate('OrganizerHome')

  return (
    <View style={styles.container}>
      <CAText appColor size='lg'>View as</CAText>
      <Spacer size='lg'/>
      <CAButton testID='organizerBtn' style={styles.select} title="Organizer" onPress={navigateAsOrganizer} />
      <Spacer size='lg'/>
      <CAButton testID='sponsorBtn' style={styles.select} title="Sponsor" onPress={navigateAsOrganizer} />
      <Spacer size='lg'/>
      <CAButton testID='attendeeBtn' style={styles.select} title="Attendee" onPress={navigateAsAttendee} />
    </View>
  )
}

const styles = StyleSheet.create({
  select: {
    width: '70%' ,
    justifyContent: 'center',
    alignContent: 'center',
    textAlign: 'center'
  },
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'
  }
});
