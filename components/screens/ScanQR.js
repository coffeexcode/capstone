import React, { useEffect, useState } from 'react';
import { StyleSheet, View, Modal } from 'react-native';
import { BarCodeScanner } from 'expo-barcode-scanner';
import * as Permissions from 'expo-permissions';

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';
import CAButton from '../core/CAButton';

export default function ScanQR() {
  const [hasScanned, setHasScanned] = useState(false);
  const [hasCameraPermission, setHasCameraPermission] = useState(false);
  const [postScanMsg, setPostScanMsg] = useState('');
  const [modalVisible, setModalVisible] = useState(false);

  useEffect(() => {
    async function askCameraPermissions() {
      const { status } = await Permissions.askAsync(Permissions.CAMERA);
      setHasCameraPermission(status === 'granted');
    }
    askCameraPermissions();
  }, [])

  const handleScan = ({ type, data }) => {
    setPostScanMsg(`You have signed in a user\nTYPE: ${type}\nDATA: ${data}`);
    setModalVisible(true);
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

  const renderPromptModal = () => (
    <Modal
        animationType="slide"
        visible={modalVisible}
        transparent={true}
        onRequestClose={() => setModalVisible(false)}
      >
        <View style={styles.container}>
          <View style={styles.modalContainer}>
            <CAText size="sm">{ postScanMsg }</CAText>
            <Spacer size="sm"/>
            <CAButton title="Dismiss" onPress={() => setModalVisible(!modalVisible)}/>
          </View>
        </View>
      </Modal>
  );
  
  return (
    <View style={styles.container}>
        {renderPromptModal()}
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
  modalContainer: {
    margin: 20, 
    backgroundColor: 'white',
    borderRadius: 20,
    padding: 35,
    alignItems: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 3
    },
    shadowOpacity: 0.5,
    shadowRadius: 4,
    elevation: 3
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
