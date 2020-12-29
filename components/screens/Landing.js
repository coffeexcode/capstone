import React from 'react';
import { StyleSheet, Image, Text, View } from 'react-native';
import { Button } from 'native-base';

// Fix relative imports

import CAText from '../core/CAText';
import Spacer from '../core/Spacer';
import logo from '../../assets/images/undraw_conference_speaker.png';


export default function Landing() {
  return (
    <View style={styles.container}>
        <CAText size="xlg">ConAssist</CAText>
        <Image source={logo} style={styles.splash} />
        <Spacer size="xlg" />
        <Button large bordered success style={styles.button}>
          <CAText size="sm"> Get Started</CAText>
        </Button>
    </View>

  );
}

const styles = StyleSheet.create({
  button: {
    padding: 24,
    alignSelf: 'center'
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
