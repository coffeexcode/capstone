import React from 'react';
import { StyleSheet, TouchableOpacity } from 'react-native';
import CAText from '@core/CAText';

/**
 * Returns a reusable Button component used by screens
 * 
 * @param {function} props.onPress onPress callback function
 * @param {object} props.style style object to be applied to button
 * @param {title} props.title text title to be displayed on button
 */
export default function CAButton({ onPress, style, title }) {
  return (
  <TouchableOpacity 
    onPress={onPress}
    style={[styles.default, style]}>
      <CAText style={styles.text} size='sm'>
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
  text: {
    color: '#fff'
  }
});
