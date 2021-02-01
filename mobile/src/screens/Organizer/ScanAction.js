import React, { useEffect, useState } from 'react';
import { StyleSheet, View } from 'react-native';

import CAText from '@core/CAText';
import CAButton from '@core/CAButton';
import Spacer from '@core/Spacer';

import appText from '@utils/text';

import data from '@data/data.json';

/**
 * Returns the ScanAction screen
 * 
 * @param {object} props.navigation React Navigation navigation object allowing for traversal to different screens
 * @param {object} props.route React Navigation route object containing information passed from previous screen
 * 
 * This screen presents selected the user with the choice of submitting a scanned QR Code action
 */
export default function ScanAction({ navigation }) {
  const [profileData, setProfileData] = useState({});

  useEffect(() => {
    setProfileData(data["user"][0]);
  }, []);

  const navigateBack = () => navigation.navigate('ScanQR');
  
  return (
    <View style={styles.container}>
      <CAText size='md' style={styles.text}>{appText.scanPrompt}</CAText>
      <CAText size='xlg' style={styles.text}>{profileData.name}</CAText>
      <CAText size='lg' style={styles.text}>{profileData.email}</CAText>
      <View style={styles.action}>
        <CAButton testID='scanSignBtn' style={styles.select} title="Sign In" onPress={navigateBack} />
        <Spacer size='lg'/>
        <CAButton testID='scanClaimMealBtn' style={styles.select} title="Claim Meal" onPress={navigateBack} />
        <Spacer size='lg'/>
        <CAButton testID='scanClaimPrizeBtn' style={styles.select} title="Claim Prize" onPress={navigateBack} />
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 40,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#fff'
  },
  action: {
    width: '100%',
    marginTop: 20
  },
  text: {
    paddingBottom: 20
  },
  select: {
    width: '70%' ,
    justifyContent: 'center',
    alignContent: 'center',
    textAlign: 'center'
  },
});
