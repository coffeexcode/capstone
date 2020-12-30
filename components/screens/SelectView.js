import React from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';

export default function SelectView(props) {
  return (
    <View style={styles.container}>
      <CAText appColor size="xlg">Select View</CAText>
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
