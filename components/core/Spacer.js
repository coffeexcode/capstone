import React from 'react';
import { StyleSheet, View } from 'react-native';

export default function Spacer({ size, style }) {
  return (
    <View style={[styles.default, style, styles[`${size}`]]}>
    </View>
  )
}

const styles = StyleSheet.create({
  default: {
      height: 25
  },
  sm: { height: 10 },
  md: { height: 25 },
  lg: { height: 40 },
  xlg: { height: 60 },
});
