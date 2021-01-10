import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Image, View } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';

import CAButton from '@core/CAButton';
import CAText from '@core/CAText';
import Spacer from '@core/Spacer';
import landingImg from '@images/undraw_conference_speaker.png';

export default function Landing({ navigation }) {
  return (
    <View style={styles.container}>
      <StatusBar style='auto'/>
      <CAText size='xlg'><MaterialIcons name="donut-small" size={28} color="black" /> ConAssist</CAText>
      <Image source={landingImg} style={styles.splash} />
      <Spacer size='xlg' />
      <CAButton 
        style={styles.getStarted}
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
