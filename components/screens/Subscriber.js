import React from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '../core/CAText';

export default function Subscriber(props) {
  return (
    <View style={styles.container}>
      <CAText appColor size="xlg">Subscriber Screen</CAText>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'
  }
});
