import React from 'react';
import { StyleSheet, View } from 'react-native';

/**
 * Returns a resusable Spacer component used by screens
 * @param {string} props.size specified size of the spacer
 */
export default function Spacer({ size }) {
  return (
    <View style={[styles.default, styles[`${size}`]]}>
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
