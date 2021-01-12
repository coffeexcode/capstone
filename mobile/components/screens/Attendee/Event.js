import React from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '@core/CAText';

export default function Event({ route }) {
  const {
    name
  } = route.params.item;

  return (
    <View style={styles.container}>
      <CAText size='lg' style={styles.text}>{name}</CAText>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#fff'
  },
  text: {
    paddingBottom: 20
  },
});
