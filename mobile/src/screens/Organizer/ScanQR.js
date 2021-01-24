import React, { useEffect, useState } from 'react';
import { StyleSheet, View } from 'react-native';
import { BarCodeScanner } from 'expo-barcode-scanner';
import * as Permissions from 'expo-permissions';

import CAText from '@core/CAText';
import Spacer from '@core/Spacer';
import CAButton from '@core/CAButton';

import appText from '@utils/text';

/**
 * Returns the ScanQR screen
 * 
 * @param {object} props.navigation React Navigation navigation object allowing for traversal to different screens
 * 
 * This screen is used to scan attendee's QR Codes for the purpose of verifying identification, resource consumption
 */
export default function ScanQR({ navigation }) {
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
    setHasScanned(true);
    navigation.navigate('ScanAction', { item: { type, data }})
  }

  const QRCodeScanner = (
    <>
      <BarCodeScanner style={styles.scanner} onBarCodeScanned={hasScanned ? undefined : handleScan} />
      {hasScanned && (<><CAButton title='Tap to scan again' onPress={() => setHasScanned(false)}/><Spacer/></>)}
    </>
  )

  const renderQRCodeScanner = () => {
    switch (hasCameraPermission) {
      case undefined:
        return <CAText>{appText.requestPermissionsMessage}</CAText>;
      case false:
        return <CAText>{appText.deniedPermissionsMessage}</CAText>;
      default:
        return QRCodeScanner;
    }
  }
  
  return (
    <View style={styles.container}>
        <CAText appColor size='xlg'>{appText.qrTitle}</CAText>
        {renderQRCodeScanner()}
        <View style={styles.msgContainer}>
          <CAText style={{ color: '#A9A9A9'}} size='xsm'>
            {appText.qrMessage}
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
    width: "75%"
  },
  scanner: {
    width: '90%',
    height: '50%',
    resizeMode: 'contain',
    marginVertical: 40
  }
})
