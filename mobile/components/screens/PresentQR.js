import React from 'react';
import { Image, StyleSheet, View } from 'react-native';

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';
import testQR from '../../assets/images/testQR.png';

const text = {
  qrHeader: 'Your QR Code',
  qrMessage: 'Expect to be asked to present your QR Code when checking in, getting food/snacks, and winning prizes!'
};

export default function PresentQR() {
  
  return (
    <View style={styles.container}>
      <CAText appColor size='xlg'>{text.qrHeader}</CAText>
      <Spacer size='xlg'/>
      {/* TODO: Get QR Code from API based on current user */}
      <Image source={testQR} style={styles.displayQR}/>
      <Spacer size='xlg'/>
      <View style={styles.msgContainer}>
        <CAText style={{ color: '#A9A9A9' }} size='xsm'>
          {text.qrMessage}
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
