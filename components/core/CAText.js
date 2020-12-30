import React from 'react';
import { StyleSheet, Text } from 'react-native';

export default function CAText(props) {
  const appColor = props.appColor ? styles.appColor : null;
  return (
    <Text style={[styles.default, appColor, props.style, styles[`${props.size}`]]}>
      {props.children}
    </Text>
  )
}

const styles = StyleSheet.create({
  default: {
    fontSize: 26,
    fontWeight: "500"
  },
  appColor: {
    color: '#4F49BB'
  },
  xsm: { fontSize: 14 },
  sm: { fontSize: 18 },
  md: { fontSize: 26 },
  lg: { fontSize: 34 },
  xlg: { fontSize: 42 }
});
