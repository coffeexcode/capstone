import React, { useEffect, useState } from 'react';
import { StyleSheet, View } from 'react-native';
import { BarCodeScanner } from 'expo-barcode-scanner';
import * as Permissions from 'expo-permissions';

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';
import CAButton from '../core/CAButton';

export default function ScanQR() {
  const [hasScanned, setHasScanned] = useState(false);
  const [hasCameraPermission, setHasCameraPermission] = useState(false);

  useEffect(() => {
    async function askCameraPermissions() {
      const { status } = await Permissions.askAsync(Permissions.CAMERA);
      setHasCameraPermission(status === 'granted');
    }
    askCameraPermissions();
  }, [])

  const handleScan = ({ type, data }) => {
    alert(`${hasScanned} => Bar code with type ${type} and data ${data} has been scanned!`);
    setHasScanned(true);
  }

  const QRCodeScanner = (
    <>
      <BarCodeScanner style={styles.scanner} onBarCodeScanned={hasScanned ? undefined : handleScan} />
      {hasScanned && (<><CAButton title="Tap to scan again" onPress={() => setHasScanned(false)}/><Spacer/></>)}
    </>
  )

  const renderQRCodeScanner = () => {
    switch (hasCameraPermission) {
      case undefined:
        return <CAText>Requesting for camera permissions</CAText>;
      case false:
        return <CAText>Camera permissions denied</CAText>;
      default:
        return QRCodeScanner;
    }
  }
  
  return (
    <View style={styles.container}>
      <CAText appColor size="xlg">Scan QR Code</CAText>
      {renderQRCodeScanner()}
      <View style={styles.msgContainer}>
        <CAText style={{ color: '#A9A9A9'}} size="xsm">
          {`Use this to scan attendee's QR Codes.`}
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
  },
  scanner: {
    width: '90%',
    height: '50%',
    resizeMode: 'contain',
    marginVertical: 40
  }
})
