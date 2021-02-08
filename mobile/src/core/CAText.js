import React from 'react';
import { StyleSheet, Text } from 'react-native';

/**
 * Returns a resusable Text component used by screens
 * @param {boolean} props.appColor if text is to be displayed in app's color theme
 * @param {object} props.style style object to be applied to button
 * @param {string} props.size specified size of the text
 * @param {string} props.children actual text to be rendered
 */
export default function CAText({ appColor, style, size, children, testID }) {
  const applyAppColor = appColor ? styles.appColor : null;
  return (
    <Text testID={testID} style={[styles.default, applyAppColor, style, styles[`${size}`]]}>
      {children}
    </Text>
  )
}

const styles = StyleSheet.create({
  default: {
    fontSize: 26,
    fontWeight: '300'
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
