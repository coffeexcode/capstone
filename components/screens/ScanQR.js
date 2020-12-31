import React from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';

export default function ScanQR() {
  const scanMsg = `Use this to scan attendee's QR Codes.`
  
  return (
    <View style={styles.container}>
      <CAText appColor size="xlg">Scan QR Code</CAText>
      <View style={styles.msgContainer}>
        <CAText style={{ color: '#A9A9A9'}} size="xsm">
          {scanMsg}
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
  },
  msgContainer: {
    width: "65%"
  }
})
