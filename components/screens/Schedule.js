import React, { useEffect, useState } from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';

export default function Schedule() {

  return (
    <View style={styles.container}>
      <CAText appColor size="xlg">Schedule</CAText>
      <View style={styles.msgContainer}>
        <CAText style={{ color: '#A9A9A9'}} size="xsm">
          {`View upcoming events for your conference here!`}
        </CAText>
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'
  }
})
