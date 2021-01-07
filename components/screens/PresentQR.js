import React from 'react';
import { Image, StyleSheet, View } from 'react-native';

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';
import exampleQR from '../../assets/images/exampleQR.png';

export default function PresentQR() {
  const QRCodeMsg = 'Expect to be asked to present your QR Code when checking in, getting food/snacks, and winning prizes!';
  
  return (
    <View style={styles.container}>
      <CAText appColor size="xlg">Your QR Code</CAText>
      <Spacer size="xlg"/>
      {/* TODO: Get QR Code from API based on current user */}
      <Image source={exampleQR} style={styles.displayQR}/>
      <Spacer size="xlg"/>
      <View style={styles.msgContainer}>
        <CAText style={{ color: '#A9A9A9' }} size="xsm">
          {QRCodeMsg}
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
    width: "80%"
  }
});
