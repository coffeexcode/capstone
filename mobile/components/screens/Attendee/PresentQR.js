import React from 'react';
import { Image, StyleSheet, View } from 'react-native';

import CAText from '@core/CAText';
import Spacer from '@core/Spacer';
import appText from '@utils/text';
import testQR from '@images/testQR.png';

export default function PresentQR() {
  return (
    <View style={styles.container}>
      <CAText appColor size='xlg'>{appText.qrHeader}</CAText>
      <Spacer size='xlg'/>
      <Image source={testQR} style={styles.displayQR}/>
      <Spacer size='xlg'/>
      <View style={styles.msgContainer}>
        <CAText style={{ color: '#A9A9A9' }} size='xsm'>
          {appText.qrMessage}
        </CAText>
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  displayQR: {
    height: '36%',
    resizeMode: 'contain'
  },
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'
  },
  msgContainer: {
    width: '80%'
  }
});
