import React, { useState } from 'react';
import { KeyboardAvoidingView, StyleSheet, Image, TextInput, View, Platform, TouchableWithoutFeedback, Keyboard } from 'react-native';

import CAText from '@core/CAText';
import CAButton from '@core/CAButton';
import Spacer from '@core/Spacer';
import appText from '@utils/text';

import logInImg from '@images/drawkit_login.jpg';

/**
 * Returns the SignIn screen
 * 
 * @param {object} props.navigation React Navigation navigation obtaining allowing for traversal to different screens
 * 
 * Screen to authenticate the user
 */
export default function SignIn({ navigation }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  return (
    <KeyboardAvoidingView
      behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
      style={{ flex: 1 }}
    >
      <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
        <View style={styles.container}>
          <Image source={logInImg} style={styles.splash}/>
          <Spacer size='lg'/>
          <CAText size='xlg'>Sign In</CAText>
          <Spacer size='md'/>
          <View style={styles.inputContainer}>
            <TextInput
              style={styles.input}
              placeholderTextColor='#A9A9A9'
              placeholder='Username'
              onChangeText={text => setUsername(text)}/>
          </View>
          <View style={styles.inputContainer}>
            <TextInput
              secureTextEntry
              style={styles.input}
              placeholderTextColor='#A9A9A9'
              text
              placeholder='Password'
              onChangeText={text => setPassword(text)}/>
          </View>
          <CAButton
            size='sm'
            title='Log in'
            onPress={() => navigation.navigate('SelectView')}
          />
          <Spacer size='md' />
          <CAText style={{ color: '#A9A9A9' }} size='xsm'>
            {appText.createAccountMessage}
            <CAText
              style={{ textDecorationLine: 'underline'}}
              size='xsm'>here</CAText>
            </CAText>
        </View>
      </TouchableWithoutFeedback>
    </KeyboardAvoidingView>
  )
}

const styles = StyleSheet.create({
  input: {
    height: 45,
    fontSize: 16,
    color: 'black'
  },
  inputContainer: {
    width: '70%',
    borderRadius:15,
    borderBottomColor: '#6C63FF',
    borderBottomWidth: 1,
    height:55,
    marginBottom:20,
    justifyContent: 'center',
    padding:20
  },
  splash: {
    height: '18%',
    resizeMode: 'contain'
  },
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center'
  }
});
