import React from 'react';
import { StyleSheet, View } from 'react-native';

export default function Spacer(props) {
  return (
    <View style={[styles.default, props.style, styles[`${props.size}`]]}>
      {props.children}
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
