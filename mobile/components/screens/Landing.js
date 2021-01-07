import React from 'react';
import { StyleSheet, Image, View } from 'react-native';

// Fix relative imports
import CAButton from '../core/CAButton';
import CAText from '../core/CAText';
import Spacer from '../core/Spacer';
import landingImg from '../../assets/images/undraw_conference_speaker.png';


export default function Landing() {
  return (
    <View style={styles.container}>
        <CAText size="xlg">ConAssist</CAText>
        <Image source={landingImg} style={styles.splash} />
        <Spacer size="xlg" />
        <CAButton style={styles.getStarted} title="Get Started"/>
    </View>

  );
}

const styles = StyleSheet.create({
  getStarted: {
    padding: 24
  },
  splash: {
    height: "40%",
    resizeMode: 'contain'
  },
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
});
