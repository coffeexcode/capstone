import React from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '../core/CAText';
import CAButton from '../core/CAButton';
import Spacer from '../core/Spacer';

export default function SelectView() {
  return (
    <View style={styles.container}>
      <CAText appColor size="lg">View as</CAText>
      <Spacer size="lg"/>
      <CAButton style={styles.select} title="Organizer"/>
      <Spacer size="lg"/>
      <CAButton style={styles.select} title="Sponsor"/>
      <Spacer size="lg"/>
      <CAButton style={styles.select} title="Attendee"/>
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
