import React from 'react';
import { StyleSheet, Text } from 'react-native';

export default function CAText({ appColor, style, size, children }) {
  const applyAppColor = appColor ? styles.appColor : null;
  return (
    <Text style={[styles.default, applyAppColor, style, styles[`${size}`]]}>
      {children}
    </Text>
  )
}

const styles = StyleSheet.create({
  default: {
    fontSize: 26,
    fontWeight: '500'
  },
  appColor: {
    color: '#4F49BB'
  },
  xsm: { fontSize: 14 },
  sm: { fontSize: 18 },
  md: { fontSize: 22 },
  lg: { fontSize: 34 },
  xlg: { fontSize: 42 }
});
