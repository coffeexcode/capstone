import React from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '@core/CAText';

export default function Contact({ route }) {
  const { 
    name,
    contactFirstName,
    contactLastName,
    contactEmail,
    contactPhone
  } = route.params.item;
  
  return (
    <View style={styles.container}>
      <CAText size='lg' style={styles.text}>{name}</CAText>
      <CAText size='md' style={styles.text}>{contactFirstName} {contactLastName}</CAText>
      <CAText size='md' style={styles.text}>{contactEmail}</CAText>
      <CAText size='md' style={styles.text}>{contactPhone}</CAText>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center'
  },
  text: {
    paddingBottom: 20
  },
});
