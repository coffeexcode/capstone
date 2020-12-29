import React from 'react';
import { StyleSheet, Text } from 'react-native';

export default function CAText(props) {
  return (
    <Text style={[styles.default, props.style, styles[`${props.size}`]]}>
      {props.children}
    </Text>
  )
}

const styles = StyleSheet.create({
  default: {
    fontSize: 26,
    fontWeight: "500"
  },
  sm: { fontSize: 18 },
  md: { fontSize: 26 },
  lg: { fontSize: 34 },
  xlg: { fontSize: 42 }
});
