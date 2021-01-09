import React from 'react';
import { StyleSheet, TouchableOpacity } from 'react-native';
import CAText from './CAText';

export default function CAButton({ onPress, style, title }) {
  return (
  <TouchableOpacity 
    onPress={onPress}
    style={[styles.default, style]}>
      <CAText style={{ color: '#fff' }} size='sm'>
        {title}
      </CAText>
    </TouchableOpacity>
  )
}

const styles = StyleSheet.create({
  default: {
    alignItems: 'center',
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
