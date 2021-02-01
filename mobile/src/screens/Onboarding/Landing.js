import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Image, View } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';

import CAButton from '@core/CAButton';
import CAText from '@core/CAText';
import Spacer from '@core/Spacer';
import landingImg from '@images/undraw_conference_speaker.png';

/**
 * Returns the Landing screen
 * 
 * @param {object} props.navigation React Navigation navigation object allowing for traversal to different screens
 * 
 * This is the first screen that is presented when the app is opened
 * Logo, App name, splash art are displayed here
 * Allows navigation to sign in
 */
export default function Landing({ navigation }) {
  return (
    <View style={styles.container}>
      <StatusBar style='auto'/>
      <CAText testID='title' size='xlg'><MaterialIcons name="donut-small" size={28} color="#3f51b5" /> ConAssist</CAText>
      <Image testID='splash' source={landingImg} style={styles.splash} />
      <Spacer size='xlg' />
      <CAButton 
        style={styles.getStarted}
        testID='getStartedBtn'
        title='Get Started'
        onPress={() => navigation.navigate('SignIn')}
        />
    </View>

  );
}

const styles = StyleSheet.create({
  getStarted: {
    padding: 24
  },
  splash: {
    height: '40%',
    resizeMode: 'contain'
  },
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
