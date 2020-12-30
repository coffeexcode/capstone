import React from 'react';
import { StyleSheet, TouchableOpacity } from 'react-native';
import CAText from './CAText';

export default function CAButton(props) {
  return (
  <TouchableOpacity 
    onPress={props.onPress}
    style={[styles.default, props.style]}>
      <CAText style={{ color: '#fff' }} size="sm">
        {props.title}
      </CAText>
    </TouchableOpacity>
  )
}

const styles = StyleSheet.create({
  default: {
    borderRadius: 10,
    backgroundColor: '#6C63FF',
    padding: 18,
    alignSelf: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 3
    },
    shadowOpacity: 0.5,
    shadowRadius: 4,
    elevation: 3
  },
});
